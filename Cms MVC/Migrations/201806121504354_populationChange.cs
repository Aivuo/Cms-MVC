namespace Cms_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populationChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Population", c => c.Int(nullable: false));
            AddColumn("dbo.Countries", "Population", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Countries", "Population");
            DropColumn("dbo.Cities", "Population");
        }
    }
}
