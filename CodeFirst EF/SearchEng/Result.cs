using CodeFirst_EF.Models;

namespace CodeFirst_EF.SearchEng
{
    class Result
    {
        public int Score { get; set; }

        public Document Document { get; set; }
    }
}
