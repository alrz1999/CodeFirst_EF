using CodeFirst_EF.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_EF
{
    class Program
    {
        private const string Path = "C://Users//Asus//source//repos//ConsoleApp1//ConsoleApp1//English.csv";

        static void Main(string[] args)
        {
            var records = ReadCsvFile();

            using (IndexedContext context = new IndexedContext())
            {

            }
        }


        private static IEnumerable<Document> ReadCsvFile()
        {
            using (var reader = new StreamReader(Path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<DocumentMap>();
                var records = csv.GetRecords<Document>();
                return records;
            }
            
        }
    }
}
