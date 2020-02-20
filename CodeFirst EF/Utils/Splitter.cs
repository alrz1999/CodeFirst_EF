using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_EF.Utils
{
    public class Splitter
    {
        private static readonly char[] SEPARATOR = { ',', '\"', ' ', '(', ')', '/', '$', '-', ':', '#', '.', '\\', ';', '\'' };

        public static string[] Split(string str)
        {
            return str.Split(SEPARATOR);
        }
    }
}
