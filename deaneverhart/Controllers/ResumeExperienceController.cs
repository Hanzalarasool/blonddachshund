using System;
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
    public class ResumeExperienceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResumeExperienceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResumeExperience
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ResumeExperience.Include(r => r.Experience).Include(r => r.Resume);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ResumeExperience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ResumeExperience == null)
            {
                return NotFound();
            }

            var resumeExperience = await _context.ResumeExperience
                .Include(r => r.Experience)
                .Include(r => r.Resume)
                .FirstOrDefaultAsync(m => m.ResumeExperienceID == id);
            if (resumeExperience == null)
            {
                return NotFound();
            }

            return View(resumeExperience);
        }

        // GET: ResumeExperience/Create
        public IActionResult Create()
        {
            ViewData["ExperienceID"] = new SelectList(_context.Experience, "Id", "Company");
            ViewData["ResumeID"] = new SelectList(_context.Resume, "Id", "Item");
            return View();
        }

        // POST: ResumeExperience/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResumeExperienceID,ResumeID,ExperienceID")] ResumeExperience resumeExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resumeExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExperienceID"] = new SelectList(_context.Experience, "Id", "Company", resumeExperience.ExperienceID);
            ViewData["ResumeID"] = new SelectList(_context.Resume, "Id", "Item", resumeExperience.ResumeID);
            return View(resumeExperience);
        }

        // GET: ResumeExperience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ResumeExperience == null)
            {
                return NotFound();
            }

            var resumeExperience = await _context.ResumeExperience.FindAsync(id);
            if (resumeExperience == null)
            {
                return NotFound();
            }
            ViewData["ExperienceID"] = new SelectList(_context.Experience, "Id", "Id", resumeExperience.ExperienceID);
            ViewData["ResumeID"] = new SelectList(_context.Resume, "Id", "Id", resumeExperience.ResumeID);
            return View(resumeExperience);
        }

        // POST: ResumeExperience/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResumeExperienceID,ResumeID,ExperienceID")] ResumeExperience resumeExperience)
        {
            if (id != resumeExperience.ResumeExperienceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resumeExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResumeExperienceExists(resumeExperience.ResumeExperienceID))
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
            ViewData["ExperienceID"] = new SelectList(_context.Experience, "Id", "Id", resumeExperience.ExperienceID);
            ViewData["ResumeID"] = new SelectList(_context.Resume, "Id", "Id", resumeExperience.ResumeID);
            return View(resumeExperience);
        }

        // GET: ResumeExperience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ResumeExperience == null)
            {
                return NotFound();
            }

            var resumeExperience = await _context.ResumeExperience
                .Include(r => r.Experience)
                .Include(r => r.Resume)
                .FirstOrDefaultAsync(m => m.ResumeExperienceID == id);
            if (resumeExperience == null)
            {
                return NotFound();
            }

            return View(resumeExperience);
        }

        // POST: ResumeExperience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ResumeExperience == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ResumeExperience'  is null.");
            }
            var resumeExperience = await _context.ResumeExperience.FindAsync(id);
            if (resumeExperience != null)
            {
                _context.ResumeExperience.Remove(resumeExperience);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResumeExperienceExists(int id)
        {
          return (_context.ResumeExperience?.Any(e => e.ResumeExperienceID == id)).GetValueOrDefault();
        }
    }
}
