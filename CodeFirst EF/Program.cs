using CodeFirst_EF.Utils;

namespace CodeFirst_EF
{
    class Program
    {
        private const string Path = "C://Users//Asus//source//repos//ConsoleApp1//ConsoleApp1//English.csv";

        static void Main(string[] args)
        {
            CsvToDB csvToDB = new CsvToDB(Path);
            csvToDB.InsertToDB();
        }   
    }
}
