using CodeFirst_EF.SearchEng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_EF.Utils
{
    interface IPrinter
    {
        void Print(List<Result> results);
    }
}
