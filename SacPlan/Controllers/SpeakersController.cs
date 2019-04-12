using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacPlan.Data;
using SacPlan.Models;

namespace SacPlan.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly SacPlanContext _context;

        public SpeakersController(SacPlanContext context)
        {
            _context = context;
        }


            // GET: Speakers
            public async Task<IActionResult> Index(int? mid)
        {
            //var speakersList = await _context.Speakers.ToListAsync();


            ViewData["MeetingID"] = mid;

            var speakers = from s in _context.Speakers
                           select s;
            if (mid != null)
            {
                speakers = speakers.Where(s => s.MeetingID == mid);
            }

            return View(await speakers.AsNoTracking().ToListAsync());



        }

        // GET: Speakers/Details/5
        public async Task<IActionResult> Details(int? id, int? mid)
        {

            ViewData["MeetingID"] = mid;

            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speakers
                .FirstOrDefaultAsync(m => m.SpeakerID == id);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // GET: Speakers/Create
        public IActionResult Create(int? mid)
        {
            ViewData["MeetingID"] = mid;
            return View();
        }

        // POST: Speakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpeakerID,FirstName,LastName,Topic,Order,MeetingID")] Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { mid = speaker.MeetingID });
            }
            return View(speaker);
        }

        // GET: Speakers/Edit/5
        public async Task<IActionResult> Edit(int? id, int? mid)
        {
            ViewData["MeetingID"] = mid;

            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speakers.FindAsync(id);
            if (speaker == null)
            {
                return NotFound();
            }
            return View(speaker);
        }

        // POST: Speakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpeakerID,FirstName,LastName,Topic,Order,MeetingID")] Speaker speaker)
        {
            if (id != speaker.SpeakerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeakerExists(speaker.SpeakerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { mid = speaker.MeetingID });
            }
            return View(speaker);
        }

        // GET: Speakers/Delete/5
        public async Task<IActionResult> Delete(int? id, int? mid)
        {
            ViewData["MeetingID"] = mid;

            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speakers
                .FirstOrDefaultAsync(m => m.SpeakerID == id);
            if (speaker == null)
            {
                return NotFound();
            }

            return View(speaker);
        }

        // POST: Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int? mid)
        {
            ViewData["MeetingID"] = mid;
            var speaker = await _context.Speakers.FindAsync(id);
            _context.Speakers.Remove(speaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { mid = speaker.MeetingID });
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speakers.Any(e => e.SpeakerID == id);
        }
    }
}
