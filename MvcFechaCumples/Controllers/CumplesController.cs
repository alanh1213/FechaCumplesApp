using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcFechaCumples.Data;
using MvcFechaCumples.Models;

namespace MvcFechaCumples.Controllers
{
    public class CumplesController : Controller
    {
        private readonly MvcFechaCumplesContext _context;

        public CumplesController(MvcFechaCumplesContext context)
        {
            _context = context;
        }

        // GET: Cumples
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cumple.ToListAsync());
        }

        // GET: Cumples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cumple = await _context.Cumple
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cumple == null)
            {
                return NotFound();
            }

            return View(cumple);
        }

        // GET: Cumples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cumples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaCumple")] Cumple cumple)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cumple);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cumple);
        }

        // GET: Cumples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cumple = await _context.Cumple.FindAsync(id);
            if (cumple == null)
            {
                return NotFound();
            }
            return View(cumple);
        }

        // POST: Cumples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaCumple")] Cumple cumple)
        {
            if (id != cumple.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cumple);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CumpleExists(cumple.Id))
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
            return View(cumple);
        }

        // GET: Cumples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cumple = await _context.Cumple
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cumple == null)
            {
                return NotFound();
            }

            return View(cumple);
        }

        // POST: Cumples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cumple = await _context.Cumple.FindAsync(id);
            _context.Cumple.Remove(cumple);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CumpleExists(int id)
        {
            return _context.Cumple.Any(e => e.Id == id);
        }
    }
}
