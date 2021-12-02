using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Models.Process;
namespace MvcMovie.Controllers
{
    public class MVCMOVIEsinhVien : Controller
    {
        private readonly MvcMovieContext _context;
        private readonly StringProcess _strPro ;
        public MVCMOVIEsinhVien(MvcMovieContext context, StringProcess strPro)
        {
            _context = context;
            _strPro = strPro;
        }

        // GET: MVCMOVIEsinhVien
        public async Task<IActionResult> Index()
        {
            return View(await _context.sinhVien.ToListAsync());
        }

        // GET: MVCMOVIEsinhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.sinhVien
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: MVCMOVIEsinhVien/Create
        public IActionResult Create()
        {
            
            
            return View();
        }

        // POST: MVCMOVIEsinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,Address,University,PersonId,PersonName")] sinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sinhVien);
        }

        // GET: MVCMOVIEsinhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.sinhVien.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            return View(sinhVien);
        }

        // POST: MVCMOVIEsinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentID,Address,University,PersonId,PersonName")] sinhVien sinhVien)
        {
            if (id != sinhVien.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sinhVienExists(sinhVien.PersonId))
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
            return View(sinhVien);
        }

        // GET: MVCMOVIEsinhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.sinhVien
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: MVCMOVIEsinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhVien = await _context.sinhVien.FindAsync(id);
            _context.sinhVien.Remove(sinhVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sinhVienExists(string id)
        {
            return _context.sinhVien.Any(e => e.PersonId == id);
        }
    }
}
