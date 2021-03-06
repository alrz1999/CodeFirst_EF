﻿using CodeFirst_EF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst_EF.SearchEng
{
    class Processor
    {
        public List<Result> Process(string query)
        {
            List<Result> results;
            string[] queryWords = Splitter.Split(query);
            results = GetResults(queryWords);
            results = ProximityFilter(queryWords, results);
            results = GetSortedResults(results);
            return results;
        }

        private List<Result> ProximityFilter(string[] queryWords, List<Result> results)
        {
            using (IndexedContext context = new IndexedContext())
            {
                foreach (var result in results)
                {
                    for (int i = 0; i < queryWords.Length-1; i++)
                    {
                         UpdateScore(context, result, queryWords[i],queryWords[i+1]);
                    }
                }
            }
            return results;
        }

        private void UpdateScore(IndexedContext context, Result result, string firstWord, string secondWord)
        {
            var firstIndexes = context.Matches.Where(x => x.Word.Str == firstWord && x.Document.ID == result.Document.ID).Select(x => x.IndexInDoc).ToList();
            var secondIndexes = context.Matches.Where(x => x.Word.Str == secondWord && x.Document.ID == result.Document.ID).Select(x => x.IndexInDoc).ToList();
            if (firstIndexes.Count() == 0 || secondIndexes.Count() == 0)
                return;
            var firstMean = firstIndexes.Sum() / firstIndexes.Count();
            var secondMean = secondIndexes.Sum() / secondIndexes.Count();
            result.Score -= Math.Abs(secondMean - firstMean);
        }

        private List<Result> GetSortedResults(List<Result> results)
        {
            if (results == null)
                return null;
            return results.OrderByDescending(x => x.Score * x.VarietyCount) .ToList();
        }

        private List<Result> GetResults(string[] queryWords)
        {
            Dictionary<int, Result> results = null;
            using (IndexedContext context = new IndexedContext())
            {
                foreach (var word in queryWords)
                {
                    if (context.Words.Any(x => x.Str.ToLower() == word))
                    {
                        var wordResults = GetWordResults(context, word);
                        if (results == null)
                            results = wordResults;
                        else
                            SetResultsScore(results, wordResults);

                    }
                }
            }
            if (results == null)
                return null;
            return results.Values.ToList();
        }

        private void SetResultsScore(Dictionary<int, Result> results, Dictionary<int, Result> wordResults)
        {
            foreach (var wordResult in wordResults)
            {
                if (results.ContainsKey(wordResult.Key))
                {
                    results[wordResult.Key].Score += wordResult.Value.Score;
                    results[wordResult.Key].VarietyCount++;
                }
                else
                    results.Add(wordResult.Key, wordResult.Value);
            }
        }

        private Dictionary<int, Result> GetCommonResults(Dictionary<int, Result> results, Dictionary<int,Result> wordResults)
        {
            if (results == null)
                return wordResults;
            var temp = new Dictionary<int, Result>(results);
            foreach (var wordResult in wordResults)
            {
                if (results.ContainsKey(wordResult.Key))
                    temp[wordResult.Key].Score += wordResult.Value.Score;
               
            }
            return temp;
        }

        private Dictionary<int,Result> GetWordResults(IndexedContext context, string word)
        {
            var wordResults = new Dictionary<int,Result>();
            var wordMatches = context.Words.Where(x => x.Str.ToLower() == word).Select(x => x.Matches).FirstOrDefault();
            var docMatches = wordMatches.GroupBy(x => x.Document).Select(x => new { Document = x.Key, Count = x.Count() });
            foreach (var docMatch in docMatches)
            {
                var result = new Result() { Document = docMatch.Document, Score = docMatch.Count*word.Length };
                wordResults.Add(result.Document.ID,result);
            }
            return wordResults;
        }
    }
}
