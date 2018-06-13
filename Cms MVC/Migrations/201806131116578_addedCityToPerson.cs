namespace Cms_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCityToPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "CityId", c => c.Int(nullable: true));
            CreateIndex("dbo.People", "CityId");
            AddForeignKey("dbo.People", "CityId", "dbo.Cities", "CityId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "CityId", "dbo.Cities");
            DropIndex("dbo.People", new[] { "CityId" });
            DropColumn("dbo.People", "CityId");
        }
    }
}
