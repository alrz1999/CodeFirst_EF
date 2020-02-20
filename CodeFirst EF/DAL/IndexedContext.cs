using CodeFirst_EF.Models;
using System.Data.Entity;

namespace CodeFirst_EF
{
    public class IndexedContext : DbContext
    {
        public IndexedContext() : base("name=IndexedContext")
        {
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Match> Matches { get; set; }
        
    }


}