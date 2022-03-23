using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalJournal.MVCApp;
using PersonalJournal.Models.Models;

namespace PersonalJournal.MVCApp.Controllers
{
    public class SubsectionsController : Controller
    {
        private readonly PersonalJournalDBContext _context;

        public SubsectionsController(PersonalJournalDBContext context)
        {
            _context = context;
        }

        // GET: Subsections
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subsections.ToListAsync());
        }

        // GET: Subsections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsection = await _context.Subsections
                .FirstOrDefaultAsync(m => m.id == id);
            if (subsection == null)
            {
                return NotFound();
            }

            return View(subsection);
        }

        // GET: Subsections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subsections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Title,LongDescription")] Subsection subsection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subsection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subsection);
        }

        // GET: Subsections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsection = await _context.Subsections.FindAsync(id);
            if (subsection == null)
            {
                return NotFound();
            }
            return View(subsection);
        }

        // POST: Subsections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Title,LongDescription")] Subsection subsection)
        {
            if (id != subsection.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subsection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubsectionExists(subsection.id))
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
            return View(subsection);
        }

        // GET: Subsections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsection = await _context.Subsections
                .FirstOrDefaultAsync(m => m.id == id);
            if (subsection == null)
            {
                return NotFound();
            }

            return View(subsection);
        }

        // POST: Subsections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subsection = await _context.Subsections.FindAsync(id);
            _context.Subsections.Remove(subsection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubsectionExists(int id)
        {
            return _context.Subsections.Any(e => e.id == id);
        }
    }
}
