using System.ComponentModel.DataAnnotations;

namespace CodeFirst_EF.Models
{
    public class Match
    {
        [Key]
        public int ID { get; set; }

        public int IndexInDoc { get; set; }

        public virtual Document Document { get; set; }

        public virtual Word Word { get; set; }


    }
}