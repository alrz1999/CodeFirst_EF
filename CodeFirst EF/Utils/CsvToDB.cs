using CodeFirst_EF.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_EF.Utils
{
    public class CsvToDB
    {
        public IEnumerable<Document> Documents;

        public CsvToDB(string path)
        {
            this.Documents = ReadCsv(path);
        }

        private IEnumerable<Document> ReadCsv(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<DocumentMap>();
                return csv.GetRecords<Document>().ToList();
            }
        }

        public void InsertDocuments()
        {
            using (IndexedContext context = new IndexedContext())
            {
                context.Documents.AddRange(Documents);
                context.SaveChanges();
            }
        }

        public void InsertToDB()
        {
            Dictionary<string, Word> seenWords = new Dictionary<string, Word>();
            List<Match> matches = new List<Match>();
            foreach (var document in Documents)
            {
                var indexInDoc = 0;
                foreach (var word in Splitter.Split(document.Text))
                {
                    Match match = new Match() { Document = document, IndexInDoc = indexInDoc };
                    if (word == "")
                    {
                        indexInDoc += 1;
                        continue;
                    }
                    if (seenWords.ContainsKey(word))
                    {
                        match.Word = seenWords[word];
                    }
                    else
                    {
                        Word str = new Word() { Str = word };
                        seenWords.Add(word, str);
                        match.Word = str;
                    }
                    indexInDoc += 1;
                    matches.Add(match);
                }
            }
            using (IndexedContext context = new IndexedContext())
            {
                context.Matches.AddRange(matches);
                context.SaveChanges();
            }

        }

    }
}
