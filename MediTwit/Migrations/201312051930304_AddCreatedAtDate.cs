namespace MediTwit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedAtDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Twits", "CreatedAt", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Twits","CreatedAt");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Twits", "CreatedAt");
            DropColumn("dbo.Twits", "CreatedAt");
        }
    }
}
