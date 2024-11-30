using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Haskill_project.Data;
using Haskill_project.Models;

namespace Haskill_project.Controllers
{
    public class MonthsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonthsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Months
        public async Task<IActionResult> Index()
        {
            return View(await _context.Month.ToListAsync());
        }

        // GET: Months/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var month = await _context.Month
                .FirstOrDefaultAsync(m => m.Id == id);
            if (month == null)
            {
                return NotFound();
            }

            return View(month);
        }

        // GET: Months/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Months/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Month month)
        {
            if (ModelState.IsValid)
            {
                _context.Add(month);
                List<Food> list = _context.Food.Where(x => x.Quantity > 0).ToList();
                foreach(var prod in list)
                {
                    prod.MonthId = month.Id;
                    prod.Wasted = 0;
                    prod.Sold = 0;
                    prod.Bought = 0;
                    _context.Add(prod);
                }
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(month);
        }

        // GET: Months/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var month = await _context.Month.FindAsync(id);
            if (month == null)
            {
                return NotFound();
            }
            return View(month);
        }

        // POST: Months/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gains,Losses")] Month month)
        {
            if (id != month.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(month);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthExists(month.Id))
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
            return View(month);
        }

        // GET: Months/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var month = await _context.Month
                .FirstOrDefaultAsync(m => m.Id == id);
            if (month == null)
            {
                return NotFound();
            }

            return View(month);
        }

        // POST: Months/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var month = await _context.Month.FindAsync(id);
            if (month != null)
            {
                _context.Month.Remove(month);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonthExists(int id)
        {
            return _context.Month.Any(e => e.Id == id);
        }
    }
}
