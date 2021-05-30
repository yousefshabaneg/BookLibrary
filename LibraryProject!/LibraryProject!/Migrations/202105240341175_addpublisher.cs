namespace LibraryProject_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpublisher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "publisherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "publisherId");
            AddForeignKey("dbo.Books", "publisherId", "dbo.publishers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "publisherId", "dbo.publishers");
            DropIndex("dbo.Books", new[] { "publisherId" });
            DropColumn("dbo.Books", "publisherId");
        }
    }
}
