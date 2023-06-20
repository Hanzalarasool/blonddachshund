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
    public class ResumeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResumeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resume
        public async Task<IActionResult> Index()
        {
              return _context.Resume != null ? 
                          View(await _context.Resume.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Resume'  is null.");
        }

        // GET: Resume
        public async Task<IActionResult> Index1()
        {
            return _context.Resume != null ?
                        View(await _context.Resume.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Resume'  is null.");
        }



        // GET: Resume/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resume == null)
            {
                return NotFound();
            }

            var resume = await _context.Resume
                .Include(s => s.ResumeExperiences)
                .ThenInclude(e => e.Experience)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);


            //var resume = await _context.Resume
            //    .FirstOrDefaultAsync(m => m.Id == id);


            if (resume == null)
            {
                return NotFound();
            }

            return View(resume);
        }

        // GET: Resume/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resume/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Version,Type1,Type2,Company,Address1,Address2,CityTown,State,Zip,Title,From,To,From1,To1,Item,Tag,Sort1,Sort2,Publish,Inactive")] Resume resume)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resume);
        }

        // GET: Resume/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resume == null)
            {
                return NotFound();
            }

            var resume = await _context.Resume.FindAsync(id);
            if (resume == null)
            {
                return NotFound();
            }
            return View(resume);
        }

        // POST: Resume/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Version,Type1,Type2,Company,Address1,Address2,CityTown,State,Zip,Title,From,To,From1,To1,Item,Tag,Sort1,Sort2,Publish,Inactive")] Resume resume)
        {
            if (id != resume.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResumeExists(resume.Id))
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
            return View(resume);
        }

        // GET: Resume/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resume == null)
            {
                return NotFound();
            }

            var resume = await _context.Resume
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resume == null)
            {
                return NotFound();
            }

            return View(resume);
        }

        // POST: Resume/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resume == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Resume'  is null.");
            }
            var resume = await _context.Resume.FindAsync(id);
            if (resume != null)
            {
                _context.Resume.Remove(resume);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResumeExists(int id)
        {
          return (_context.Resume?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
