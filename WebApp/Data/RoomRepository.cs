﻿using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientPatientManagement.Core.Data
{
    public class RoomRepository : IRepository<Room>
    {
        public static RoomRepository Instancia = new RoomRepository();

        private RoomRepository()
        {
            //Instancia = new RepositoryRoom();
        }

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
        }

        public Room GetById(int id)
        {
            var db = new VetDbContext();
            var room = db.Rooms.Find(id);
            return room;
        }

        public void Insert(Room entity)
        {
            var db = new VetDbContext();
            db.Rooms.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Room> List()
        {   
            var db = new VetDbContext();
            IList<Room> rooms = db.Rooms.ToList();
            return rooms;
        }

        public void Update(Room entity)
        {
            var db = new VetDbContext();
            var room = db.Rooms.Find(entity.Id);

            if(room != null)
            {
                room.Name = entity.Name;
                room.Location = entity.Location;

                db.SaveChanges();
            }
        }
    }
}