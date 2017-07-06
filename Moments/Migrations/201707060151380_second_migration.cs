namespace Moments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second_migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "path", c => c.String());
            DropColumn("dbo.Photos", "price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Photos", "path");
        }
    }
}
