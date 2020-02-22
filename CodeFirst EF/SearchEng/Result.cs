using CodeFirst_EF.Models;
using System.Collections.Generic;

namespace CodeFirst_EF.SearchEng
{
    class Result
    {
        private const int DEFAULT_VARIETY_COUNT = 1;
        private const int DEFAULT_MATCH_COUNT = 0;

        public int Score { get; set; }

        public Document Document { get; set; }

        public int VarietyCount { get; set; } = DEFAULT_VARIETY_COUNT;


    }
}
