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
    public class MVCMOVIEController : Controller
    {
        private readonly MvcMovieContext _context;

        public MVCMOVIEController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: MVCMOVIE
        public async Task<IActionResult> Index()
        {
            return View(await _context.conNguoi.ToListAsync());
        }

        // GET: MVCMOVIE/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conNguoi = await _context.conNguoi
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (conNguoi == null)
            {
                return NotFound();
            }

            return View(conNguoi);
        }

        // GET: MVCMOVIE/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MVCMOVIE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,PersonName")] conNguoi conNguoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conNguoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conNguoi);
        }

        // GET: MVCMOVIE/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conNguoi = await _context.conNguoi.FindAsync(id);
            if (conNguoi == null)
            {
                return NotFound();
            }
            return View(conNguoi);
        }

        // POST: MVCMOVIE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonId,PersonName")] conNguoi conNguoi)
        {
            if (id != conNguoi.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conNguoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!conNguoiExists(conNguoi.PersonId))
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
            return View(conNguoi);
        }

        // GET: MVCMOVIE/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conNguoi = await _context.conNguoi
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (conNguoi == null)
            {
                return NotFound();
            }

            return View(conNguoi);
        }

        // POST: MVCMOVIE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var conNguoi = await _context.conNguoi.FindAsync(id);
            _context.conNguoi.Remove(conNguoi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool conNguoiExists(string id)
        {
            return _context.conNguoi.Any(e => e.PersonId == id);
        }
    }
}
