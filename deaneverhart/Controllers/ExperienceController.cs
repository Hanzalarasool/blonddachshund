﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using deaneverhart.Data;
using deaneverhart.Models;

namespace deaneverhart.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperienceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Experience
        public async Task<IActionResult> Index()
        {
              return _context.Experience != null ? 
                          View(await _context.Experience.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Experience'  is null.");
        }

        // GET: Experience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Experience == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // GET: Experience/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Experience/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Item,Tag,Sort1,Sort2,Publish,Inactive")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experience);
        }

        // GET: Experience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Experience == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }
            return View(experience);
        }

        // POST: Experience/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Item,Tag,Sort1,Sort2,Publish,Inactive")] Experience experience)
        {
            if (id != experience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceExists(experience.Id))
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
            return View(experience);
        }

        // GET: Experience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Experience == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // POST: Experience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Experience == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Experience'  is null.");
            }
            var experience = await _context.Experience.FindAsync(id);
            if (experience != null)
            {
                _context.Experience.Remove(experience);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceExists(int id)
        {
          return (_context.Experience?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
