using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace litclassicbot.Controllers.ParticleControllers
{
    public class ParticleController : Controller
    {
        // GET: Particle
        public ActionResult Index()
        {
            // Particle particle = new Particle(true);
            // DataView["body"] = particle.Body;
            // DataView["title"] = particle.Title;
            // можно всё это сделать в формате JSON (или он уже делает это в т.ч. и в виде JSON?)
            return View();
        }

        // GET: Particle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Particle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Particle/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Particle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Particle/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Particle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Particle/Delete/5
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
