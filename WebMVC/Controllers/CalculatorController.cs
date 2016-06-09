using BusinessModule.Interfaces;
using BusinessModule.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        // GET: Calculator/Details/5
        [HttpPost]
        public ActionResult Details(int number)
        {
            ISequenceCalculator calculator = BusinessConstructor.TestCalculator();
            var result = calculator.CalculateSequences(number);
            return View("Index", result);
        }

        // GET: Calculator/Create
        public ActionResult Clean()
        {
            return View("Index", null);
        }

        // POST: Calculator/Create
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

        // GET: Calculator/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calculator/Edit/5
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

        // GET: Calculator/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Calculator/Delete/5
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
