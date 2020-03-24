using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeldingV2._0.Models;

namespace WeldingV2._0.Controllers
{
    public class WorkersController : Controller
    {
        private readonly WeldingContext _context;

        public WorkersController(WeldingContext context)
        {
            _context = context;
        }

        // GET: Workers
        public async Task<IActionResult> Index()
        {
            var weldingContext = _context.Workers.Include(w => w.Foremen);
            return View(await weldingContext.ToListAsync());
        }

        // GET: Workers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workers = await _context.Workers
                .Include(w => w.Foremen)
                .FirstOrDefaultAsync(m => m.WorkerId == id);
            if (workers == null)
            {
                return NotFound();
            }

            return View(workers);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            ViewData["ForemenId"] = new SelectList(_context.Foremen, "ForemenId", "ForemenId");
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkerId,FirstName,SecondName,ForemenId")] Workers workers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ForemenId"] = new SelectList(_context.Foremen, "ForemenId", "ForemenId", workers.ForemenId);
            return View(workers);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workers = await _context.Workers.FindAsync(id);
            if (workers == null)
            {
                return NotFound();
            }
            ViewData["ForemenId"] = new SelectList(_context.Foremen, "ForemenId", "ForemenId", workers.ForemenId);
            return View(workers);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkerId,FirstName,SecondName,ForemenId")] Workers workers)
        {
            if (id != workers.WorkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkersExists(workers.WorkerId))
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
            ViewData["ForemenId"] = new SelectList(_context.Foremen, "ForemenId", "ForemenId", workers.ForemenId);
            return View(workers);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workers = await _context.Workers
                .Include(w => w.Foremen)
                .FirstOrDefaultAsync(m => m.WorkerId == id);
            if (workers == null)
            {
                return NotFound();
            }

            return View(workers);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workers = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(workers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkersExists(int id)
        {
            return _context.Workers.Any(e => e.WorkerId == id);
        }
    }
}
