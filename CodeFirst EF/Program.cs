using CodeFirst_EF.Models;
using CodeFirst_EF.Utils;
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

            CsvToDB csvToDB = new CsvToDB(Path);
            csvToDB.InsertDocuments();

            using (IndexedContext context = new IndexedContext())
            {

            }
        }


        
    }
}
