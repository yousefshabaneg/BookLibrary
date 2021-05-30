namespace LibraryProject_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.publishers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.publishers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.publishers", "Name", c => c.String());
            AlterColumn("dbo.publishers", "Address", c => c.String());
        }
    }
}
