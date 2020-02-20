namespace CodeFirst_EF
{
    using CodeFirst_EF.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

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