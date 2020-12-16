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
    }
}
