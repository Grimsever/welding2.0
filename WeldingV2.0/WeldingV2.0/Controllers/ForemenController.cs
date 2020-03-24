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
    public class ForemenController : Controller
    {
        private readonly WeldingContext _context;

        public ForemenController(WeldingContext context)
        {
            _context = context;
        }

        // GET: Foremen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Foremen.ToListAsync());
        }

        // GET: Foremen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foremen = await _context.Foremen
                .FirstOrDefaultAsync(m => m.ForemenId == id);
            if (foremen == null)
            {
                return NotFound();
            }

            return View(foremen);
        }

        // GET: Foremen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foremen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ForemenId,FirstName,SecondName")] Foremen foremen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foremen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foremen);
        }

        // GET: Foremen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foremen = await _context.Foremen.FindAsync(id);
            if (foremen == null)
            {
                return NotFound();
            }
            return View(foremen);
        }

        // POST: Foremen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ForemenId,FirstName,SecondName")] Foremen foremen)
        {
            if (id != foremen.ForemenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foremen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForemenExists(foremen.ForemenId))
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
            return View(foremen);
        }

        // GET: Foremen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foremen = await _context.Foremen
                .FirstOrDefaultAsync(m => m.ForemenId == id);
            if (foremen == null)
            {
                return NotFound();
            }

            return View(foremen);
        }

        // POST: Foremen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foremen = await _context.Foremen.FindAsync(id);
            _context.Foremen.Remove(foremen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForemenExists(int id)
        {
            return _context.Foremen.Any(e => e.ForemenId == id);
        }
    }
}
