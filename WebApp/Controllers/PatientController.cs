using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PatientController : Controller
    {
        public ActionResult Index()
        {
            var model = new PatientModel();
            return View("Index", model.ObtenerPacientes());
        }

        public ActionResult Create()
        {
            var model = new ClientModel();
            var clients = model.ObtenerClientes();
            ViewBag.Clients = new SelectList(clients, "Id", "Name");

            var genders = Enum.GetValues(typeof(Gender)).Cast<Gender>();
            ViewBag.Genders = new SelectList(genders);

            return View();
        }

        private IEnumerable<SelectListItem> GetSelectClientItems(IEnumerable<Client> clients)
        {
            var selectList = new List<SelectListItem>();

            foreach (var client in clients)
            {
                selectList.Add(new SelectListItem
                {
                    Value = client.Id.ToString(),
                    Text = client.Name
                });
            }

            return selectList;
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            try
            {
                var model = new PatientModel();
                model.AgregarPaciente(patient);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            var model = new PatientModel();
            var patient = model.ObtenerPacienteById(id);
            return View("Edit", patient);
        }


        [HttpPost]
        public ActionResult Edit(Doctor entity)
        {
            try
            {
                var model = new PatientModel();
                var patient = model.ObtenerPacienteById(entity.Id);

                patient.Name = entity.Name;

                model.ActualizarPaciente(patient);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var model = new PatientModel();
            model.EliminarPaciente(id);

            return RedirectToAction("Index");
        }
    }
}