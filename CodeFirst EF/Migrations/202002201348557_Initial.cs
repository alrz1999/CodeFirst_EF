namespace CodeFirst_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IndexInDoc = c.Int(nullable: false),
                        Document_ID = c.Int(),
                        Word_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Documents", t => t.Document_ID)
                .ForeignKey("dbo.Words", t => t.Word_ID)
                .Index(t => t.Document_ID)
                .Index(t => t.Word_ID);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Str = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Word_ID", "dbo.Words");
            DropForeignKey("dbo.Matches", "Document_ID", "dbo.Documents");
            DropIndex("dbo.Matches", new[] { "Word_ID" });
            DropIndex("dbo.Matches", new[] { "Document_ID" });
            DropTable("dbo.Words");
            DropTable("dbo.Matches");
            DropTable("dbo.Documents");
        }
    }
}
