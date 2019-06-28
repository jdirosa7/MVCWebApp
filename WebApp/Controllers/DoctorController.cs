using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            var model = new DoctorModel();
            return View("Index", model.ObtenerDoctores());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            try
            {
                var model = new DoctorModel();
                model.AgregarDoctor(doctor);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            var model = new DoctorModel();
            var doctor = model.ObtenerDoctorById(id);
            return View("Edit", doctor);
        }

        
        [HttpPost]
        public ActionResult Edit(Doctor entity)
        {
            try
            {
                var model = new DoctorModel();
                var doctor = model.ObtenerDoctorById(entity.Id);

                doctor.Name = entity.Name;
                doctor.LastName = entity.LastName;
                doctor.Phone = entity.Phone;
                doctor.Email = entity.Email;

                model.ActualizarDoctor(doctor);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            var model = new DoctorModel();
            model.EliminarDoctor(id);

            return RedirectToAction("Index");
        }
    }
}