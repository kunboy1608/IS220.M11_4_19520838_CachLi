using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeOn_CachLy.Data;
using DeOn_CachLy.Models;

namespace DeOn_CachLy.Controllers
{
    public class DiemCachLyController : Controller
    {
        private readonly CachLyContext _context;

        public DiemCachLyController(CachLyContext context)
        {
            _context = context;
        }

        // GET: DiemCachLy
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiemCachLys.ToListAsync());
        }

        // GET: DiemCachLy/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemCachLyModel = await _context.DiemCachLys
                .FirstOrDefaultAsync(m => m.MaDiemCachLy == id);
            if (diemCachLyModel == null)
            {
                return NotFound();
            }

            return View(diemCachLyModel);
        }

        // GET: DiemCachLy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiemCachLy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDiemCachLy,TenDiemCachLy,DiaChi")] DiemCachLyModel diemCachLyModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diemCachLyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diemCachLyModel);
        }

        // GET: DiemCachLy/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemCachLyModel = await _context.DiemCachLys.FindAsync(id);
            if (diemCachLyModel == null)
            {
                return NotFound();
            }
            return View(diemCachLyModel);
        }

        // POST: DiemCachLy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDiemCachLy,TenDiemCachLy,DiaChi")] DiemCachLyModel diemCachLyModel)
        {
            if (id != diemCachLyModel.MaDiemCachLy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diemCachLyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiemCachLyModelExists(diemCachLyModel.MaDiemCachLy))
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
            return View(diemCachLyModel);
        }

        // GET: DiemCachLy/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemCachLyModel = await _context.DiemCachLys
                .FirstOrDefaultAsync(m => m.MaDiemCachLy == id);
            if (diemCachLyModel == null)
            {
                return NotFound();
            }

            return View(diemCachLyModel);
        }

        // POST: DiemCachLy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var diemCachLyModel = await _context.DiemCachLys.FindAsync(id);
            _context.DiemCachLys.Remove(diemCachLyModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemCachLyModelExists(string id)
        {
            return _context.DiemCachLys.Any(e => e.MaDiemCachLy == id);
        }
    }
}
