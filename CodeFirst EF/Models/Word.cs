﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst_EF.Models
{
    public class Word
    {
        [Key]
        public int ID { get; set; }

        public string Str { get; set; }

        public ICollection<Match> Matches { get; set; }


    }
}
