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
    public class AlumnosController : Controller
    {
        private readonly NotasContext _context;

        public AlumnosController(NotasContext context)
        {
            _context = context;
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alumnos.ToListAsync());
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnos = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.id == id);
            if (alumnos == null)
            {
                return NotFound();
            }

            return View(alumnos);
        }

        // GET: Alumnos/Create
        public IActionResult Create()
        {
            ViewBag.Estados = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Activo" },
                new SelectListItem { Value = "0", Text = "Inactivo" }
            }, "Value", "Text");

            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,codigo,nombre,apellidos,dui,estado")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumnos);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnos = await _context.Alumnos.FindAsync(id);
            if (alumnos == null)
            {
                return NotFound();
            }

            ViewBag.Estados = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Activo" },
                new SelectListItem { Value = "0", Text = "Inactivo" }
            }, "Value", "Text", alumnos.estado.ToString());

            return View(alumnos);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,codigo,nombre,apellidos,dui,estado")] Alumnos alumnos)
        {
            if (id != alumnos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnosExists(alumnos.id))
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
            return View(alumnos);
        }

        // GET: Alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnos = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.id == id);
            if (alumnos == null)
            {
                return NotFound();
            }

            return View(alumnos);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumnos = await _context.Alumnos.FindAsync(id);
            if (alumnos != null)
            {
                _context.Alumnos.Remove(alumnos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnosExists(int id)
        {
            return _context.Alumnos.Any(e => e.id == id);
        }
    }
}
