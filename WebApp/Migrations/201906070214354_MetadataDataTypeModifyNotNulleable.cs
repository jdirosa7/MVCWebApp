namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MetadataDataTypeModifyNotNulleable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Rooms", "Location", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "Location", c => c.String(maxLength: 50));
            AlterColumn("dbo.Rooms", "Name", c => c.String(maxLength: 50));
        }
    }
}
