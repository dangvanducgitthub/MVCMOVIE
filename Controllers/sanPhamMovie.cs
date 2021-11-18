using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class sanPhamMovie : Controller
    {
        private readonly MvcMovieContext _context;

        public sanPhamMovie(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: sanPhamMovie
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.sanPham.Include(s => s.Categories);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: sanPhamMovie/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.sanPham
                .Include(s => s.Categories)
                .FirstOrDefaultAsync(m => m.sanPhamId == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: sanPhamMovie/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId");
            return View();
        }

        // POST: sanPhamMovie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sanPhamId,sanPhamName,CategoryId")] sanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", sanPham.CategoryId);
            return View(sanPham);
        }

        // GET: sanPhamMovie/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.sanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", sanPham.CategoryId);
            return View(sanPham);
        }

        // POST: sanPhamMovie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("sanPhamId,sanPhamName,CategoryId")] sanPham sanPham)
        {
            if (id != sanPham.sanPhamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sanPhamExists(sanPham.sanPhamId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", sanPham.CategoryId);
            return View(sanPham);
        }

        // GET: sanPhamMovie/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.sanPham
                .Include(s => s.Categories)
                .FirstOrDefaultAsync(m => m.sanPhamId == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: sanPhamMovie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sanPham = await _context.sanPham.FindAsync(id);
            _context.sanPham.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sanPhamExists(string id)
        {
            return _context.sanPham.Any(e => e.sanPhamId == id);
        }
    }
}
