using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainIT.Data;
using TrainIT.Models.DataModels;

namespace TrainIT.Controllers
{
    public class DustTestsController : Controller
    {
        private readonly TrainITContext _context;

        public DustTestsController(TrainITContext context)
        {
            _context = context;
        }

        // GET: DustTests
        
        public async Task<IActionResult> Index()
        {
            var trainITContext = _context.DustTest
                .Include(d => d.Arena)
                .Include(d => d.Sport)
                .Include(d => d.TestedPerson);
            return View(await trainITContext.ToListAsync());
        }

        // GET: DustTests
        
        public async Task<IActionResult> IndexSearch
            ( string searchString, string searchString1 )
        {
            var dustTests = from d in _context.DustTest
                .Include(d => d.Arena)
                .Include(d => d.Sport)
                .Include(d => d.TestedPerson)

                            select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                dustTests = dustTests
                 .Include(d => d.Arena)
                .Include(d => d.Sport)
                .Include(d => d.TestedPerson)
                .Where(s => s.TestedPerson.FirstName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                dustTests = dustTests
                 .Include(d => d.Arena)
                .Include(d => d.Sport)
                .Include(d => d.TestedPerson)
                .Where(s => s.TestedPerson.LastName.Contains(searchString));
            }
            return View(await dustTests.ToListAsync());
        }

        // GET: DustTests/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dustTest = await _context.DustTest
                .Include(d => d.Arena)
                .Include(d => d.Sport)
                .Include(d => d.TestedPerson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dustTest == null)
            {
                return NotFound();
            }

            return View(dustTest);
        }

        // GET: DustTests/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["SportId"] = new SelectList(_context.Set<Sport>(), "Id", "SportName");
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            return View();
        }

        // POST: DustTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTimePreformed,ArenaId,SportId,PersonId,TimeSet1,TimeSet2,TimeSet3,TimeSet4,TimeTotal,Approved")] DustTest dustTest)
        {
            if (ModelState.IsValid)
            {
                var applicationContext = _context.DustTest
                .Include(d => d.Arena)
                .Include(d => d.Sport)
                .Include(d => d.TestedPerson);
                dustTest.TimeTotal = dustTest.TimeSet1 + dustTest.TimeSet2 + dustTest.TimeSet3 + dustTest.TimeSet4;


                _context.Add(dustTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSearch));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", dustTest.ArenaId);
            ViewData["SportId"] = new SelectList(_context.Set<Sport>(), "Id", "SportName", dustTest.SportId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", dustTest.PersonId);
            return View(dustTest);
        }

        // GET: DustTests/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dustTest = await _context.DustTest.FindAsync(id);
            if (dustTest == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", dustTest.ArenaId);
            ViewData["SportId"] = new SelectList(_context.Set<Sport>(), "Id", "SportName", dustTest.SportId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", dustTest.PersonId);
            return View(dustTest);
        }

        // POST: DustTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTimePreformed,ArenaId,SportId,PersonId,TimeSet1,TimeSet2,TimeSet3,TimeSet4,TimeTotal,Approved")] DustTest dustTest)
        {
            if (id != dustTest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationContext = _context.DustTest
                      .Include(d => d.Arena)
                      .Include(d => d.Sport)
                      .Include(d => d.TestedPerson);
                    dustTest.TimeTotal = dustTest.TimeSet1 + dustTest.TimeSet2 + dustTest.TimeSet3 + dustTest.TimeSet4;

                    _context.Update(dustTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DustTestExists(dustTest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexSearch));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", dustTest.ArenaId);
            ViewData["SportId"] = new SelectList(_context.Set<Sport>(), "Id", "SportName", dustTest.SportId);
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", dustTest.PersonId);
            return View(dustTest);
        }

        // GET: DustTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dustTest = await _context.DustTest
                .Include(d => d.Arena)
                .Include(d => d.Sport)
                .Include(d => d.TestedPerson)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dustTest == null)
            {
                return NotFound();
            }

            return View(dustTest);
        }

        // POST: DustTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dustTest = await _context.DustTest.FindAsync(id);
            _context.DustTest.Remove(dustTest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexSearch));
        }

        private bool DustTestExists(int id)
        {
            return _context.DustTest.Any(e => e.Id == id);
        }
    }
}
