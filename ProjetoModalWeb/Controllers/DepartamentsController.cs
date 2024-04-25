using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoModalWeb.Models;

namespace ProjetoModalWeb.Controllers
{
    public class DepartamentsController : Controller
    {
        private readonly Context _context;

        public DepartamentsController(Context context)
        {
            _context = context;
        }

        // GET: Departaments
        public async Task<IActionResult> Index()
        {
              return _context.Departaments != null ? 
                          View(await _context.Departaments.ToListAsync()) :
                          Problem("Entity set 'Context.Departaments'  is null.");
        }

        // GET: Departaments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Departaments == null)
            {
                return NotFound();
            }

            var departament = await _context.Departaments
                .FirstOrDefaultAsync(m => m.DeptId == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // GET: Departaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeptId,DeptName,DeptChef,DeptSChef,DeptDataIn")] Departament departament)
        {
            if (ModelState.IsValid)
            {
                departament.DeptId = Guid.NewGuid();
                _context.Add(departament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departament);
        }

        // GET: Departaments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Departaments == null)
            {
                return NotFound();
            }

            var departament = await _context.Departaments.FindAsync(id);
            if (departament == null)
            {
                return NotFound();
            }
            return View(departament);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeptId,DeptName,DeptChef,DeptSChef,DeptDataIn")] Departament departament)
        {
            if (id != departament.DeptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentExists(departament.DeptId))
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
            return View(departament);
        }

        // GET: Departaments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Departaments == null)
            {
                return NotFound();
            }

            var departament = await _context.Departaments
                .FirstOrDefaultAsync(m => m.DeptId == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Departaments == null)
            {
                return Problem("Entity set 'Context.Departaments'  is null.");
            }
            var departament = await _context.Departaments.FindAsync(id);
            if (departament != null)
            {
                _context.Departaments.Remove(departament);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentExists(Guid id)
        {
          return (_context.Departaments?.Any(e => e.DeptId == id)).GetValueOrDefault();
        }
    }
}
