using CodeFirst_EF.Utils;
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
            results = GetSortedResults(results);
            // todo : add proximity filter
            return results;
        }

        private List<Result> GetSortedResults(List<Result> results)
        {
            if (results == null)
                return null;
            return results.OrderByDescending(x => x.Score).ToList();
        }

        private List<Result> GetResults(string[] queryWords)
        {
            List<Result> results = null;
            using (IndexedContext context = new IndexedContext())
            {
                foreach (var word in queryWords)
                {
                    if (context.Words.Any(x => x.Str == word))
                    {
                        var wordResults = GetWordResults(context, word);
                        if (results == null)
                            results = wordResults;
                        else
                            results.Intersect(wordResults);
                    }
                }
            }
            return results;
        }

        private List<Result> GetWordResults(IndexedContext context, string word)
        {
            var wordResults = new List<Result>();
            var wordMatches = context.Words.Where(x => x.Str == word).Select(x => x.Matches).FirstOrDefault();
            var docMatches = wordMatches.GroupBy(x => x.Document).Select(x => new { Document = x.Key, Count = x.Count() });
            foreach (var docMatch in docMatches)
            {
                var result = new Result() { Document = docMatch.Document, Score = docMatch.Count };
                wordResults.Add(result);
            }
            return wordResults;
        }
    }
}
