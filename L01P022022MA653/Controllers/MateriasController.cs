﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P022022MA653.Models;

namespace L01P022022MA653.Controllers
{
    public class MateriasController : Controller
    {
        private readonly NotasContext _context;

        public MateriasController(NotasContext context)
        {
            _context = context;
        }

        // GET: Materias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materias.ToListAsync());
        }

        // GET: Materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materias = await _context.Materias
                .FirstOrDefaultAsync(m => m.id == id);
            if (materias == null)
            {
                return NotFound();
            }

            return View(materias);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            ViewBag.Estados = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "A", Text = "Activa" },
                new SelectListItem { Value = "I", Text = "Inactiva" },
                new SelectListItem { Value = "P", Text = "Pendiente" }
            }, "Value", "Text");
            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,materia,unidades_valorativas,estado")] Materias materias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materias);
        }

        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materias = await _context.Materias.FindAsync(id);
            if (materias == null)
            {
                return NotFound();
            }

            ViewBag.Estados = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "A", Text = "Activa" },
                new SelectListItem { Value = "I", Text = "Inactiva" },
                new SelectListItem { Value = "P", Text = "Pendiente" }
            }, "Value", "Text");
            return View(materias);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,materia,unidades_valorativas,estado")] Materias materias)
        {
            if (id != materias.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriasExists(materias.id))
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
            return View(materias);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materias = await _context.Materias
                .FirstOrDefaultAsync(m => m.id == id);
            if (materias == null)
            {
                return NotFound();
            }

            return View(materias);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materias = await _context.Materias.FindAsync(id);
            if (materias != null)
            {
                _context.Materias.Remove(materias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriasExists(int id)
        {
            return _context.Materias.Any(e => e.id == id);
        }
    }
}
