using CodeFirst_EF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_EF.SearchEng
{
    class SearchEngine
    {
        private Processor processor;
        private IPrinter printer;

        public SearchEngine(Processor processor, IPrinter printer)
        {
            this.processor = processor;
            this.printer = printer;
        }

        public void Query()
        {
            while (true)
            {
                var query = Console.ReadLine().ToLower();
                var result  = processor.Process(query);
                printer.Print(result);

            }
        }
    }

    
}
