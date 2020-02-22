using CodeFirst_EF.SearchEng;
using System;
using System.Collections.Generic;

namespace CodeFirst_EF.Utils
{
    class Printer : IPrinter
    {
        public void Print(List<Result> results)
        {
            Console.WriteLine("Search Results: \n");
            if (results == null)
                Console.WriteLine("nothing was found !!!");
            else
            {
                foreach (var result in results)
                {
                    Console.WriteLine($@"{result.Score}          {result.Document.Text}" );
                }
            }

        }

        public void PrintTop(List<Result> results, int number)
        {
            Console.WriteLine("Search Results:\n");
            if (results == null)
                Console.WriteLine("nothing was found !!!");
            else
            {
                int counter = 1;
                foreach (var result in results)
                {
                    Console.WriteLine($@"{counter}-  {result.Document.Text}");
                    if (counter == number)
                        return;
                    counter++;
                }
            }
        }
    }
}
