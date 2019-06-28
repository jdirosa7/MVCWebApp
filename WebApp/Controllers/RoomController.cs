using ClientPatientManagement.Core.Data;
using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class RoomController : Controller
    {
        // GET: Rom
        public ActionResult Index()
        {
            var model = new RoomModel();
            return View("Index", model.TraerSalas());
        }

        // GET: Rom/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rom/Create
        public ActionResult Create()
        {
            int a = 2;

            return View();
        }

        // POST: Rom/Create
        [HttpPost]
        public ActionResult Create(string Nombre, string Localidad)
        {
            try
            {
                // TODO: Add insert logic here
                var model = new RoomModel();
                model.AgregarRoom(Nombre, Localidad);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rom/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new RoomModel();
            var room = model.ObtenerRoomById(id);
            return View("Edit", room);
        }

        // POST: Rom/Edit/5
        [HttpPost]
        public ActionResult Edit(Room entity)
        {
            try
            {
                var model = new RoomModel();
                var room = model.ObtenerRoomById(entity.Id);

                room.Name = entity.Name;
                room.Location = entity.Location;

                model.ActualizarRoom(room);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Rom/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new RoomModel();
            model.EliminarRoom(id);

            return RedirectToAction("Index");
        }

        // POST: Rom/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
