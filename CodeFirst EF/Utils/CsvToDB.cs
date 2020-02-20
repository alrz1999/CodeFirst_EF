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
        private IEnumerable<Document> Documents;
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
    }
}
