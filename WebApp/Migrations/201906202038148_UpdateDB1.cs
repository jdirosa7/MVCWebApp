namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Hour = c.Int(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                        Room_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.Room_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id)
                .Index(t => t.Room_Id);
            
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Clients", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Clients", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "Room_Id" });
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            DropIndex("dbo.Appointments", new[] { "Doctor_Id" });
            AlterColumn("dbo.Patients", "Name", c => c.String());
            AlterColumn("dbo.Clients", "Email", c => c.String());
            AlterColumn("dbo.Clients", "LastName", c => c.String());
            AlterColumn("dbo.Clients", "Name", c => c.String());
            DropTable("dbo.Appointments");
        }
    }
}
