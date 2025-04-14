using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Task_Manager.DataBase;
using Task_Manager.Models;

namespace Task_Manager.Controllers
{
    public class TaskInManagesController : Controller
    {
        private readonly AppDbContext _context;

        public TaskInManagesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TaskInManages
        public async Task<IActionResult> Index()
        {
            var dataBase = _context.Tasks.Include(t => t.User);
            return View(await dataBase.ToListAsync());
        }

        // GET: TaskInManages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskInManage = await _context.Tasks
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskInManage == null)
            {
                return NotFound();
            }

            return View(taskInManage);
        }

        // GET: TaskInManages/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: TaskInManages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Deadline,IsCompleted,UserId")] TaskInManage taskInManage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskInManage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", taskInManage.UserId);
            return View(taskInManage);
        }

        // GET: TaskInManages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskInManage = await _context.Tasks.FindAsync(id);
            if (taskInManage == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", taskInManage.UserId);
            return View(taskInManage);
        }

        // POST: TaskInManages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Deadline,IsCompleted,UserId")] TaskInManage taskInManage)
        {
            if (id != taskInManage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskInManage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskInManageExists(taskInManage.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", taskInManage.UserId);
            return View(taskInManage);
        }

        // GET: TaskInManages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskInManage = await _context.Tasks
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskInManage == null)
            {
                return NotFound();
            }

            return View(taskInManage);
        }

        // POST: TaskInManages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskInManage = await _context.Tasks.FindAsync(id);
            if (taskInManage != null)
            {
                _context.Tasks.Remove(taskInManage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskInManageExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
