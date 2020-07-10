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
    public class WorkoutsController : Controller
    {
        private readonly TrainITContext _context;

        public WorkoutsController(TrainITContext context)
        {
            _context = context;
        }

        // GET: Workouts
        public async Task<IActionResult> Index()
        {
            var trainITContext = _context.Workout
                .Include(w => w.Arena)
                .Include(w => w.Owner)
                .Include(w => w.Sport);
            return View(await trainITContext.ToListAsync());
        }

        public async Task<IActionResult> IndexSearch
            (string searchString, string searchString1
             , string searchString2)
        {
            var workouts = from w in _context.Workout
                .Include(w => w.Arena)
                .Include(w => w.Owner)
                .Include(w => w.Sport)

                           select w;
            if (!String.IsNullOrEmpty(searchString))
            {
                workouts = workouts
                .Include(w => w.Arena)
                .Include(w => w.Owner)
                .Include(w => w.Sport)
                .Where(s => s.Owner.FirstName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                workouts = workouts
                .Include(w => w.Arena)
                .Include(w => w.Owner)
                .Include(w => w.Sport)
                .Where(s => s.Owner.LastName.Contains(searchString1));
            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                workouts = workouts
                .Include(w => w.Arena)
                .Include(w => w.Owner)
                .Include(w => w.Sport)
                .Where(s => s.Sport.SportName.Contains(searchString2));
            }
            return View(await workouts.ToListAsync());
        }

        // GET: Workouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _context.Workout
                .Include(w => w.Arena)
                .Include(w => w.Owner)
                .Include(w => w.Sport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        // GET: Workouts/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["SportId"] = new SelectList(_context.Sport, "Id", "SportName");
            return View();
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTimeStarted,DateTimeEnded,ArenaId,SportId,PersonId,Duration,Distance,Kcal,Status")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSearch));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", workout.ArenaId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", workout.PersonId);
            ViewData["SportId"] = new SelectList(_context.Sport, "Id", "SportName", workout.SportId);
            return View(workout);
        }

        // GET: Workouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _context.Workout.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", workout.ArenaId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", workout.PersonId);
            ViewData["SportId"] = new SelectList(_context.Sport, "Id", "SportName", workout.SportId);
            return View(workout);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTimeStarted,DateTimeEnded,ArenaId,SportId,PersonId,Duration,Distance,Kcal,Status")] Workout workout)
        {
            if (id != workout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutExists(workout.Id))
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
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", workout.ArenaId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", workout.PersonId);
            ViewData["SportId"] = new SelectList(_context.Sport, "Id", "SportName", workout.SportId);
            return View(workout);
        }

        // GET: Workouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _context.Workout
                .Include(w => w.Arena)
                .Include(w => w.Owner)
                .Include(w => w.Sport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workout = await _context.Workout.FindAsync(id);
            _context.Workout.Remove(workout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexSearch));
        }

        private bool WorkoutExists(int id)
        {
            return _context.Workout.Any(e => e.Id == id);
        }
    }
}
