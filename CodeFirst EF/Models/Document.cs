using System.ComponentModel.DataAnnotations;

namespace CodeFirst_EF.Models
{
    public class Document
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

       
    }
}