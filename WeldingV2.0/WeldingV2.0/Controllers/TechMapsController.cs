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
    public class TechMapsController : Controller
    {
        private readonly WeldingContext _context;

        public TechMapsController(WeldingContext context)
        {
            _context = context;
        }

        // GET: TechMaps
        public async Task<IActionResult> Index()
        {
            return View(await _context.TechMaps.ToListAsync());
        }

        // GET: TechMaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techMap = await _context.TechMaps
                .FirstOrDefaultAsync(m => m.TechMapId == id);
            if (techMap == null)
            {
                return NotFound();
            }

            return View(techMap);
        }

        // GET: TechMaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TechMaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechMapId,MinValueAmp,MaxValueAmp,MinValueVolt,MaxValueVolt")] TechMap techMap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(techMap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(techMap);
        }

        // GET: TechMaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techMap = await _context.TechMaps.FindAsync(id);
            if (techMap == null)
            {
                return NotFound();
            }
            return View(techMap);
        }

        // POST: TechMaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechMapId,MinValueAmp,MaxValueAmp,MinValueVolt,MaxValueVolt")] TechMap techMap)
        {
            if (id != techMap.TechMapId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(techMap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechMapExists(techMap.TechMapId))
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
            return View(techMap);
        }

        // GET: TechMaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techMap = await _context.TechMaps
                .FirstOrDefaultAsync(m => m.TechMapId == id);
            if (techMap == null)
            {
                return NotFound();
            }

            return View(techMap);
        }

        // POST: TechMaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var techMap = await _context.TechMaps.FindAsync(id);
            _context.TechMaps.Remove(techMap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechMapExists(int id)
        {
            return _context.TechMaps.Any(e => e.TechMapId == id);
        }
    }
}
