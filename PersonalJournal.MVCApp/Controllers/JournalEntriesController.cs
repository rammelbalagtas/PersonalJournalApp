using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalJournal.MVCApp.Data;
using PersonalJournal.Models.Models;

namespace PersonalJournal.MVCApp.Controllers
{
    public class JournalEntriesController : Controller
    {
        private readonly PersonalJournalDBContext _context;

        public JournalEntriesController(PersonalJournalDBContext context)
        {
            _context = context;
        }

        // GET: JournalEntries
        public async Task<IActionResult> Index()
        {
            var personalJournalDBContext = _context.JournalEntries.Where(e => e.CreatedByUser == User.Identity.Name).Include(j => j.Category).Include(j => j.Mood).Include(j => j.Subsection1).Include(j => j.Subsection2).Include(j => j.Subsection3).Include(j => j.Subsection4).Include(j => j.Subsection5);
            return View(await personalJournalDBContext.ToListAsync());
        }

        // GET: JournalEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalEntry = await _context.JournalEntries
                .Include(j => j.Category)
                .Include(j => j.Mood)
                .Include(j => j.Subsection1)
                .Include(j => j.Subsection2)
                .Include(j => j.Subsection3)
                .Include(j => j.Subsection4)
                .Include(j => j.Subsection5)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (journalEntry == null)
            {
                return NotFound();
            }

            return View(journalEntry);
        }

        // GET: JournalEntries/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title");
            ViewData["MoodId"] = new SelectList(_context.Moods.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title");

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "", Value = "" });
            items.AddRange(new SelectList(_context.Subsections.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title"));
            ViewData["SubsectionId1"] = items;
            ViewData["SubsectionId2"] = items;
            ViewData["SubsectionId3"] = items;
            ViewData["SubsectionId4"] = items;
            ViewData["SubsectionId5"] = items;

            return View();
        }

        // POST: JournalEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CategoryId,MoodId,DateTime,Description,SubsectionId1,SubsectionText1,SubsectionId2,SubsectionText2,SubsectionId3,SubsectionText3,SubsectionId4,SubsectionText4,SubsectionId5,SubsectionText5")] JournalEntry journalEntry)
        {
            if (ModelState.IsValid)
            {
                journalEntry.CreatedByUser = User.Identity.Name;
                _context.Add(journalEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title", journalEntry.CategoryId);
            ViewData["MoodId"] = new SelectList(_context.Moods.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title", journalEntry.MoodId);

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "", Value = "" });
            items.AddRange(new SelectList(_context.Subsections.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title"));
            ViewData["SubsectionId1"] = items;
            ViewData["SubsectionId2"] = items;
            ViewData["SubsectionId3"] = items;
            ViewData["SubsectionId4"] = items;
            ViewData["SubsectionId5"] = items;

            //ViewData["SubsectionId1"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId1);
            //ViewData["SubsectionId2"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId2);
            //ViewData["SubsectionId3"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId3);
            //ViewData["SubsectionId4"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId4);
            //ViewData["SubsectionId5"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId5);
            return View(journalEntry);
        }

        // GET: JournalEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalEntry = await _context.JournalEntries.FindAsync(id);
            if (journalEntry == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title", journalEntry.CategoryId);
            ViewData["MoodId"] = new SelectList(_context.Moods.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title", journalEntry.MoodId);

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "", Value = "" });
            items.AddRange(new SelectList(_context.Subsections.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title"));
            ViewData["SubsectionId1"] = items;
            ViewData["SubsectionId2"] = items;
            ViewData["SubsectionId3"] = items;
            ViewData["SubsectionId4"] = items;
            ViewData["SubsectionId5"] = items;

            //ViewData["SubsectionId1"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId1);
            //ViewData["SubsectionId2"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId2);
            //ViewData["SubsectionId3"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId3);
            //ViewData["SubsectionId4"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId4);
            //ViewData["SubsectionId5"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId5);
            return View(journalEntry);
        }

        // POST: JournalEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CategoryId,MoodId,DateTime,Description,SubsectionId1,SubsectionText1,SubsectionId2,SubsectionText2,SubsectionId3,SubsectionText3,SubsectionId4,SubsectionText4,SubsectionId5,SubsectionText5")] JournalEntry journalEntry)
        {
            if (id != journalEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(journalEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalEntryExists(journalEntry.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title", journalEntry.CategoryId);
            ViewData["MoodId"] = new SelectList(_context.Moods.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title", journalEntry.MoodId);

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "", Value = "" });
            items.AddRange(new SelectList(_context.Subsections.Where(e => e.CreatedByUser == User.Identity.Name), "Id", "Title"));
            ViewData["SubsectionId1"] = items;
            ViewData["SubsectionId2"] = items;
            ViewData["SubsectionId3"] = items;
            ViewData["SubsectionId4"] = items;
            ViewData["SubsectionId5"] = items;

            //ViewData["SubsectionId1"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId1);
            //ViewData["SubsectionId2"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId2);
            //ViewData["SubsectionId3"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId3);
            //ViewData["SubsectionId4"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId4);
            //ViewData["SubsectionId5"] = new SelectList(_context.Subsections, "Id", "Title", journalEntry.SubsectionId5);
            return View(journalEntry);
        }

        // GET: JournalEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalEntry = await _context.JournalEntries
                .Include(j => j.Category)
                .Include(j => j.Mood)
                .Include(j => j.Subsection1)
                .Include(j => j.Subsection2)
                .Include(j => j.Subsection3)
                .Include(j => j.Subsection4)
                .Include(j => j.Subsection5)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (journalEntry == null)
            {
                return NotFound();
            }

            return View(journalEntry);
        }

        // POST: JournalEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var journalEntry = await _context.JournalEntries.FindAsync(id);
            _context.JournalEntries.Remove(journalEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JournalEntryExists(int id)
        {
            return _context.JournalEntries.Any(e => e.Id == id);
        }
    }
}
