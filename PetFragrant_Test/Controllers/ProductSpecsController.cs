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
    public class ProductSpecsController : Controller
    {
        private readonly PetContext _context;

        public ProductSpecsController(PetContext context)
        {
            _context = context;
        }

        // GET: ProductSpecs
        public async Task<IActionResult> Index()
        {
            var petContext = _context.ProductSpecs.Include(p => p.Product).Include(p => p.Spec);
            return View(await petContext.ToListAsync());
        }

        // GET: ProductSpecs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSpec = await _context.ProductSpecs
                .Include(p => p.Product)
                .Include(p => p.Spec)
                .FirstOrDefaultAsync(m => m.ProdcutId == id);
            if (productSpec == null)
            {
                return NotFound();
            }

            return View(productSpec);
        }

        // GET: ProductSpecs/Create
        public IActionResult Create()
        {
            ViewData["ProdcutId"] = new SelectList(_context.Products, "ProdcutId", "ProdcutId");
            ViewData["SpecID"] = new SelectList(_context.Specs, "SpecID", "SpecID");
            return View();
        }

        // POST: ProductSpecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecID,ProdcutId")] ProductSpec productSpec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSpec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdcutId"] = new SelectList(_context.Products, "ProdcutId", "ProdcutId", productSpec.ProdcutId);
            ViewData["SpecID"] = new SelectList(_context.Specs, "SpecID", "SpecID", productSpec.SpecID);
            return View(productSpec);
        }

        // GET: ProductSpecs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSpec = await _context.ProductSpecs.FindAsync(id);
            if (productSpec == null)
            {
                return NotFound();
            }
            ViewData["ProdcutId"] = new SelectList(_context.Products, "ProdcutId", "ProdcutId", productSpec.ProdcutId);
            ViewData["SpecID"] = new SelectList(_context.Specs, "SpecID", "SpecID", productSpec.SpecID);
            return View(productSpec);
        }

        // POST: ProductSpecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SpecID,ProdcutId")] ProductSpec productSpec)
        {
            if (id != productSpec.ProdcutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSpec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSpecExists(productSpec.ProdcutId))
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
            ViewData["ProdcutId"] = new SelectList(_context.Products, "ProdcutId", "ProdcutId", productSpec.ProdcutId);
            ViewData["SpecID"] = new SelectList(_context.Specs, "SpecID", "SpecID", productSpec.SpecID);
            return View(productSpec);
        }

        // GET: ProductSpecs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSpec = await _context.ProductSpecs
                .Include(p => p.Product)
                .Include(p => p.Spec)
                .FirstOrDefaultAsync(m => m.ProdcutId == id);
            if (productSpec == null)
            {
                return NotFound();
            }

            return View(productSpec);
        }

        // POST: ProductSpecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var productSpec = await _context.ProductSpecs.FindAsync(id);
            _context.ProductSpecs.Remove(productSpec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSpecExists(string id)
        {
            return _context.ProductSpecs.Any(e => e.ProdcutId == id);
        }
    }
}
