namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataBase : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Appointments", name: "Doctor_Id", newName: "DoctorId");
            RenameColumn(table: "dbo.Appointments", name: "Patient_Id", newName: "PatientId");
            RenameColumn(table: "dbo.Appointments", name: "Room_Id", newName: "RoomId");
            RenameIndex(table: "dbo.Appointments", name: "IX_Doctor_Id", newName: "IX_DoctorId");
            RenameIndex(table: "dbo.Appointments", name: "IX_Patient_Id", newName: "IX_PatientId");
            RenameIndex(table: "dbo.Appointments", name: "IX_Room_Id", newName: "IX_RoomId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Appointments", name: "IX_RoomId", newName: "IX_Room_Id");
            RenameIndex(table: "dbo.Appointments", name: "IX_PatientId", newName: "IX_Patient_Id");
            RenameIndex(table: "dbo.Appointments", name: "IX_DoctorId", newName: "IX_Doctor_Id");
            RenameColumn(table: "dbo.Appointments", name: "RoomId", newName: "Room_Id");
            RenameColumn(table: "dbo.Appointments", name: "PatientId", newName: "Patient_Id");
            RenameColumn(table: "dbo.Appointments", name: "DoctorId", newName: "Doctor_Id");
        }
    }
}
