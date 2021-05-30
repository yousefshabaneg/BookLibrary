namespace LibraryProject_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addValidation1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Url", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Url");
        }
    }
}
