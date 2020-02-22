using CodeFirst_EF.SearchEng;
using System;
using System.Collections.Generic;

namespace CodeFirst_EF.Utils
{
    class Printer : IPrinter
    {
        public void Print(List<Result> results)
        {
            if (results == null)
                Console.WriteLine("nothing was found !!!");
            else
            {
                foreach (var result in results)
                {
                    Console.WriteLine("Results:");
                    Console.WriteLine($@"{result.Score}          {result.Document.Text}" );
                }
            }

        }

        public void PrintTop(List<Result> results, int number)
        {
            if (results == null)
                Console.WriteLine("nothing was found !!!");
            else
            {
                int counter = 1;
                foreach (var result in results)
                {
                    Console.WriteLine("Results:");
                    Console.WriteLine($@"{result.Score}          {result.Document.Text}");
                    if (counter == number)
                        return;
                    counter++;
                }
            }
        }
    }
}
