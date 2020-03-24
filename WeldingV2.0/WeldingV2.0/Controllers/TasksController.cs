using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WeldingV2._0.Models;
using Task = WeldingV2._0.Models.Task;

namespace WeldingV2._0.Controllers
{
    public class TasksController : Controller
    {
        private readonly WeldingContext _context;

        public TasksController(WeldingContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var weldingContext = _context.Tasks
                .Include(t => t.Machine)
                .Include(t => t.TechMap)
                .Include(t => t.Worker);

            return View(await weldingContext.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.Machine)
                .Include(t => t.TechMap)
                .Include(t => t.Worker)
                .FirstOrDefaultAsync(m => m.TaskId == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["MachineId"] = new SelectList(_context.Machines, "Id", "Id");
            ViewData["TechMapId"] = new SelectList(_context.TechMaps, "TechMapId", "TechMapId");
            ViewData["WorkerId"] = new SelectList(_context.Workers, "WorkerId", "WorkerId");

            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TechMapId,MachineId,WorkerId")] Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MachineId"] = new SelectList(_context.Machines, "Id", "Id", task.MachineId);
            ViewData["TechMapId"] = new SelectList(_context.TechMaps, "TechMapId", "TechMapId", task.TechMapId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "WorkerId", "WorkerId", task.WorkerId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["MachineId"] = new SelectList(_context.Machines, "Id", "Id", task.MachineId);
            ViewData["TechMapId"] = new SelectList(_context.TechMaps, "TechMapId", "TechMapId", task.TechMapId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "WorkerId", "WorkerId", task.WorkerId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TechMapId,MachineId,WorkerId")] Task task)
        {
            if (id != task.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.TaskId))
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
            ViewData["MachineId"] = new SelectList(_context.Machines, "Id", "Id", task.MachineId);
            ViewData["TechMapId"] = new SelectList(_context.TechMaps, "TechMapId", "TechMapId", task.TechMapId);
            ViewData["WorkerId"] = new SelectList(_context.Workers, "WorkerId", "WorkerId", task.WorkerId);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.Machine)
                .Include(t => t.TechMap)
                .Include(t => t.Worker)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.TaskId == id);
        }
    }
}
