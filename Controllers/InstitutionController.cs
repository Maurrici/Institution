using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicoes.Models;
using Instituicoes.Models.Data;

namespace Instituicoes.Controllers
{
    public class InstitutionController : Controller
    {
        private readonly EFContext _context;

        public InstitutionController(EFContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Institutions.OrderBy(i => i.Nome).ToListAsync());
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Institution institution)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Institutions.Add(institution);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }

            return View(institution);
        }

        //GET: Update
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institution = await _context.Institutions.SingleOrDefaultAsync(i => i.InstitutionID == id);
            if (institution == null)
            {
                return NotFound();
            }

            return View(institution);
        }

        //POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("InstitutionID, Nome, Endereco")] Institution institution)
        {
            if (id != institution.InstitutionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Institutions.Update(institution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Institutions.Any(i => i.InstitutionID == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(institution);
        }

        //GET: Read
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institution = await _context.Institutions.SingleOrDefaultAsync(i => i.InstitutionID == id);
            if (institution == null)
            {
                return NotFound();
            }

            return View(institution);
        }

        //GET: Delete
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var institution = await _context.Institutions.SingleOrDefaultAsync(i => i.InstitutionID == id);
            if (institution == null)
            {
                return NotFound();
            }
            return View(institution);
        }

        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var institution = await _context.Institutions.SingleOrDefaultAsync(i => i.InstitutionID == id);
            _context.Institutions.Remove(institution);
            await _context.SaveChangesAsync();
            TempData["Message"] = $"Instituição {institution.Nome.ToUpper()} foi removida com sucesso!";
            return RedirectToAction(nameof(Index));
        }


    }
}
