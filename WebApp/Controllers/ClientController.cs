using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ClientController : Controller
    {
        public ActionResult Index()
        {
            var model = new ClientModel();
            return View("Index", model.ObtenerClientes());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client cliente)
        {
            try
            {
                var model = new ClientModel();
                model.AgregarCliente(cliente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            var model = new ClientModel();
            var cliente = model.ObtenerClienteById(id);
            return View("Edit", cliente);
        }


        [HttpPost]
        public ActionResult Edit(Doctor entity)
        {
            try
            {
                var model = new ClientModel();
                var cliente = model.ObtenerClienteById(entity.Id);

                cliente.Name = entity.Name;
                cliente.LastName = entity.LastName;
                cliente.Email = entity.Email;

                model.ActualizarCliente(cliente);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var model = new ClientModel();
            model.EliminarCliente(id);

            return RedirectToAction("Index");
        }
    }
}