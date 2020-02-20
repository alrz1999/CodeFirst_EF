using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_EF.Models
{
    public class Word
    {
        [Key]
        public int ID { get; set; }

        public string Str { get; set; }

        public ICollection<Match> matches { get; set; }


    }
}
