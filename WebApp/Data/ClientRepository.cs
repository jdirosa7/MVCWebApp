﻿using ClientPatientManagement.Core.Data;
using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class ClientRepository : IRepository<Client>
    {
        public static ClientRepository Instancia = new ClientRepository();

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
        }

        public Client GetById(int id)
        {
            var db = new VetDbContext();
            var client = db.Clients.Find(id);
            return client;
        }

        public void Insert(Client entity)
        {
            var db = new VetDbContext();
            db.Clients.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Client> List()
        {
            var db = new VetDbContext();
            IList<Client> clients = db.Clients.ToList();
            return clients;
        }

        public void Update(Client entity)
        {
            var db = new VetDbContext();
            var client = db.Clients.Find(entity.Id);

            if (client != null)
            {
                client.Name = entity.Name;
                client.LastName = entity.LastName;
                client.Email = entity.Email;

                db.SaveChanges();
            }
        }
    }
}