using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalJournal.MVCApp;
using PersonalJournal.Models.Models;
using Microsoft.AspNetCore.Authorization;
using PersonalJournal.MVCApp.Data;

namespace PersonalJournal.MVCApp.Controllers
{
    [Authorize]
    public class MoodsController : Controller
    {
        private readonly PersonalJournalDBContext _context;

        public MoodsController(PersonalJournalDBContext context)
        {
            _context = context;
        }

        // GET: Moods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moods.ToListAsync());
        }

        // GET: Moods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mood = await _context.Moods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mood == null)
            {
                return NotFound();
            }

            return View(mood);
        }

        // GET: Moods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Title")] Mood mood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mood);
        }

        // GET: Moods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mood = await _context.Moods.FindAsync(id);
            if (mood == null)
            {
                return NotFound();
            }
            return View(mood);
        }

        // POST: Moods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Title")] Mood mood)
        {
            if (id != mood.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoodExists(mood.Id))
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
            return View(mood);
        }

        // GET: Moods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mood = await _context.Moods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mood == null)
            {
                return NotFound();
            }

            return View(mood);
        }

        // POST: Moods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mood = await _context.Moods.FindAsync(id);
            _context.Moods.Remove(mood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoodExists(int id)
        {
            return _context.Moods.Any(e => e.Id == id);
        }
    }
}
