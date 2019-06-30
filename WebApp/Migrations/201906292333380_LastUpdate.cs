namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Appointments", newName: "Appointment");
            RenameTable(name: "dbo.Doctors", newName: "Doctor");
            RenameTable(name: "dbo.Patients", newName: "Patient");
            RenameTable(name: "dbo.Clients", newName: "Client");
            RenameTable(name: "dbo.Rooms", newName: "Room");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Room", newName: "Rooms");
            RenameTable(name: "dbo.Client", newName: "Clients");
            RenameTable(name: "dbo.Patient", newName: "Patients");
            RenameTable(name: "dbo.Doctor", newName: "Doctors");
            RenameTable(name: "dbo.Appointment", newName: "Appointments");
        }
    }
}
