using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetFragrant_Test.Data;
using petsFragrant.Models;

namespace PetFragrant_Test.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PetContext _context;

        public ProductsController(PetContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var petContext = _context.Products.Include(p => p.Categories);
            return View(await petContext.ToListAsync());
        }

        public async Task<IActionResult> ProductList()
        {
            return View(await _context.Products.ToListAsync());
        }

        public async Task<IActionResult> ProductDetail(string? id)
        {
            var product = await _context.Products
                .Include(p => p.Categories)
                .Include(p => p.ProductSpecs)
                    .ThenInclude(ps => ps.Spec)
                .FirstOrDefaultAsync(m => m.ProdcutId == id);
       
            return View(product);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.ProdcutId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Policy = "IsAdmin")]
        public IActionResult Create()
        {
            ViewData["CategoriesID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdcutId,CategoriesID,ProductName,ProductDescription,Price,Inventory")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriesID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", product.CategoriesID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoriesID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", product.CategoriesID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProdcutId,CategoriesID,ProductName,ProductDescription,Price,Inventory")] Product product)
        {
            if (id != product.ProdcutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProdcutId))
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
            ViewData["CategoriesID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", product.CategoriesID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.ProdcutId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "IsAdmin")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewData["CategoriesID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct([Bind("ProdcutId,CategoriesID,ProductName,ProductDescription,Price,Inventory")] Product product, [Bind("SpecName")] string[] specName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                if (specName != null && specName.Length > 0)
                {
                    foreach(var spec in specName)
                    {
                        Spec specValue = new Spec{ SpecName = spec };
                        _context.Add(specValue);
                        await _context.SaveChangesAsync();
                        
                        ProductSpec ps = new ProductSpec { ProdcutId = product.ProdcutId, SpecID = specValue.SpecID};
                        _context.Add(ps);
                        _context.SaveChanges();
                    }
                }
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriesID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", product.CategoriesID);
            return View(product);
        }
        private bool ProductExists(string id)
        {
            return _context.Products.Any(e => e.ProdcutId == id);
        }
    }
}
