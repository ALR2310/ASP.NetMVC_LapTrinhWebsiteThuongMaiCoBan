using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Data;
using ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Models;

namespace ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Controllers
{
    public class ProductDescController : Controller
    {
        private readonly MyDbContext _context;

        public ProductDescController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ProductDesc
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.ProductDesc.Include(p => p.Product);
            return View(await myDbContext.ToListAsync());
        }

        // GET: ProductDesc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductDesc == null)
            {
                return NotFound();
            }

            var productDesc = await _context.ProductDesc
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDesc == null)
            {
                return NotFound();
            }

            return View(productDesc);
        }

        // GET: ProductDesc/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
            return View();
        }

        // POST: ProductDesc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Title,Details,ImgUrl")] ProductDesc productDesc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productDesc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", productDesc.ProductId);
            return View(productDesc);
        }

        // GET: ProductDesc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductDesc == null)
            {
                return NotFound();
            }

            var productDesc = await _context.ProductDesc.FindAsync(id);
            if (productDesc == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", productDesc.ProductId);
            return View(productDesc);
        }

        // POST: ProductDesc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Title,Details,ImgUrl")] ProductDesc productDesc)
        {
            if (id != productDesc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productDesc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDescExists(productDesc.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name", productDesc.ProductId);
            return View(productDesc);
        }

        // GET: ProductDesc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductDesc == null)
            {
                return NotFound();
            }

            var productDesc = await _context.ProductDesc
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDesc == null)
            {
                return NotFound();
            }

            return View(productDesc);
        }

        // POST: ProductDesc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductDesc == null)
            {
                return Problem("Entity set 'MyDbContext.ProductDesc'  is null.");
            }
            var productDesc = await _context.ProductDesc.FindAsync(id);
            if (productDesc != null)
            {
                _context.ProductDesc.Remove(productDesc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDescExists(int id)
        {
          return (_context.ProductDesc?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
