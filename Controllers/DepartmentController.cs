using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Instituicoes.Models;
using Instituicoes.Models.Data;
using System.Threading.Tasks;

namespace Instituicoes.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly EFContext _context;

        public DepartmentController(EFContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.OrderBy(d => d.Nome).ToArrayAsync());
        }

        //GET: Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Departments.Add(department);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }

            return View(department);
        }

        //GET: Update
        public async Task<IActionResult> Edit(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.SingleOrDefaultAsync(d => d.DepartmentID == id);
            if(department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        //POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id,[Bind("DepartmentID, Nome")] Department department)
        {
            if(id != department.DepartmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Departments.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Departments.Any(department => department.DepartmentID == id))
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
            return View(department);
        }

        //GET: Read
        public async Task<IActionResult> Details(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.SingleOrDefaultAsync(d => d.DepartmentID == id);
            if(department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        //GET: Delete
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.SingleOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var departamento = await _context.Departments.SingleOrDefaultAsync(m => m.DepartmentID == id);
            _context.Departments.Remove(departamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
