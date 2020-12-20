using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicoes.Models;

namespace Instituicoes.Controllers
{
    public class InstitutionController : Controller
    {
        private static IList<Institution> institutions = new List<Institution>() {
            new Institution()
            {
                InstitutionID = 1,
                Nome = "Instituto Federal do Ceará",
                Endereco = "Fortaleza"
            },
            new Institution()
            {
                InstitutionID = 2,
                Nome = "Universidade Federal do Ceará",
                Endereco = "Fortaleza"
            },
            new Institution()
            {
                InstitutionID = 3,
                Nome = "Universidade Estadual do Ceará",
                Endereco = "Fortaleza"
            },

        };

        public IActionResult Index()
        {
            return View(institutions);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Institution institution)
        {
            institution.InstitutionID = institutions.Select(i => i.InstitutionID).Max() + 1;
            institutions.Add(institution);

            return RedirectToAction("Index");
        }

        //GET: Update
        public IActionResult Edit(long id)
        {
            return View(institutions.Where(i => i.InstitutionID == id).First());
        }

        //POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Institution institution)
        {
            institutions.Where(i => i.InstitutionID == institution.InstitutionID).First();
            institutions.Add(institution);

            return RedirectToAction("Index");
        }

        //GET: Read
        public IActionResult Details(long id)
        {
            return View(institutions.Where(i => i.InstitutionID == id).First());
        }

        //GET: Delete
        public ActionResult Delete(long id)
        {
            return View(institutions.Where(i => i.InstitutionID == id).First());
        }

        //POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Institution institution)
        {
            institutions.Remove(institutions.Where(i => i.InstitutionID == institution.InstitutionID).First());
            return RedirectToAction("Index");
        }


    }
}
