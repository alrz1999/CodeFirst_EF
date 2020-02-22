using CodeFirst_EF.SearchEng;
using CodeFirst_EF.Utils;

namespace CodeFirst_EF
{
    class Program
    {
        private const string Path = "C://Users//Asus//source//repos//ConsoleApp1//ConsoleApp1//English.csv";

        static void Main(string[] args)
        {
            //CsvToDB csvToDB = new CsvToDB(Path);
            //csvToDB.InsertToDB();
            Processor processor = new Processor();
            IPrinter printer = new Printer();
            SearchEngine searchEngine = new SearchEngine(processor, printer);
            searchEngine.Query();

        }

        
    }
}
