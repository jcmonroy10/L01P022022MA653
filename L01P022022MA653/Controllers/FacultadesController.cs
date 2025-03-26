using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P022022MA653.Models;

namespace L01P022022MA653.Controllers
{
    public class FacultadesController : Controller
    {
        private readonly NotasContext _context;

        public FacultadesController(NotasContext context)
        {
            _context = context;
        }

        // GET: Facultades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facultades.ToListAsync());
        }

        // GET: Facultades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultades = await _context.Facultades
                .FirstOrDefaultAsync(m => m.id == id);
            if (facultades == null)
            {
                return NotFound();
            }

            return View(facultades);
        }

        // GET: Facultades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facultades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,facultad")] Facultades facultades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facultades);
        }

        // GET: Facultades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultades = await _context.Facultades.FindAsync(id);
            if (facultades == null)
            {
                return NotFound();
            }
            return View(facultades);
        }

        // POST: Facultades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,facultad")] Facultades facultades)
        {
            if (id != facultades.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultadesExists(facultades.id))
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
            return View(facultades);
        }

        // GET: Facultades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultades = await _context.Facultades
                .FirstOrDefaultAsync(m => m.id == id);
            if (facultades == null)
            {
                return NotFound();
            }

            return View(facultades);
        }

        // POST: Facultades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultades = await _context.Facultades.FindAsync(id);
            if (facultades != null)
            {
                _context.Facultades.Remove(facultades);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultadesExists(int id)
        {
            return _context.Facultades.Any(e => e.id == id);
        }
    }
}
