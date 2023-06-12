using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetFragrant_Test.Data;
using petsFragrant.Models;

namespace PetFragrant_Test.Controllers
{
    public class SpecsController : Controller
    {
        private readonly PetContext _context;

        public SpecsController(PetContext context)
        {
            _context = context;
        }

        // GET: Specs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Specs.ToListAsync());
        }

        // GET: Specs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spec = await _context.Specs
                .FirstOrDefaultAsync(m => m.SpecID == id);
            if (spec == null)
            {
                return NotFound();
            }

            return View(spec);
        }

        // GET: Specs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecID,SpecName")] Spec spec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spec);
        }

        // GET: Specs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spec = await _context.Specs.FindAsync(id);
            if (spec == null)
            {
                return NotFound();
            }
            return View(spec);
        }

        // POST: Specs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SpecID,SpecName")] Spec spec)
        {
            if (id != spec.SpecID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecExists(spec.SpecID))
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
            return View(spec);
        }

        // GET: Specs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spec = await _context.Specs
                .FirstOrDefaultAsync(m => m.SpecID == id);
            if (spec == null)
            {
                return NotFound();
            }

            return View(spec);
        }

        // POST: Specs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var spec = await _context.Specs.FindAsync(id);
            _context.Specs.Remove(spec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecExists(string id)
        {
            return _context.Specs.Any(e => e.SpecID == id);
        }
    }
}
