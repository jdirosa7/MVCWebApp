namespace WebApp.Migrations
{
    using ClientPatientManagement.Core.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClientPatientManagement.Core.Data.VetDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClientPatientManagement.Core.Data.VetDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            IList<Room> rooms = new List<Room>();

            rooms.Add(new Room()
            {
                Location = "Merlo",
                Name = "Cristian"
            });

            rooms.Add(new Room()
            {
                Location = "Ituzaingo",
                Name = "Adri"
            });

            rooms.Add(new Room()
            {
                Location = "Haedo",
                Name = "Julian"
            });

            rooms.Add(new Room()
            {
                Location = "Ramos",
                Name = "Joe"
            });

            foreach (Room room in rooms)
            {
                context.Rooms.AddOrUpdate(room);
                base.Seed(context);
            }
        }
    }
}
