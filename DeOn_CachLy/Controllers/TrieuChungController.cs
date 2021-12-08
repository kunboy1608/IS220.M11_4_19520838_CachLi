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
    public class TrieuChungController : Controller
    {
        private readonly CachLyContext _context;

        public TrieuChungController(CachLyContext context)
        {
            _context = context;
        }

        // GET: TrieuChung
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrieuChungs.ToListAsync());
        }

        // GET: TrieuChung/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trieuChungModel = await _context.TrieuChungs
                .FirstOrDefaultAsync(m => m.MaTrieuChung == id);
            if (trieuChungModel == null)
            {
                return NotFound();
            }

            return View(trieuChungModel);
        }

        // GET: TrieuChung/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrieuChung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTrieuChung,TenTrieuChung")] TrieuChungModel trieuChungModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trieuChungModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trieuChungModel);
        }

        // GET: TrieuChung/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trieuChungModel = await _context.TrieuChungs.FindAsync(id);
            if (trieuChungModel == null)
            {
                return NotFound();
            }
            return View(trieuChungModel);
        }

        // POST: TrieuChung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaTrieuChung,TenTrieuChung")] TrieuChungModel trieuChungModel)
        {
            if (id != trieuChungModel.MaTrieuChung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trieuChungModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrieuChungModelExists(trieuChungModel.MaTrieuChung))
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
            return View(trieuChungModel);
        }

        // GET: TrieuChung/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trieuChungModel = await _context.TrieuChungs
                .FirstOrDefaultAsync(m => m.MaTrieuChung == id);
            if (trieuChungModel == null)
            {
                return NotFound();
            }

            return View(trieuChungModel);
        }

        // POST: TrieuChung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var trieuChungModel = await _context.TrieuChungs.FindAsync(id);
            _context.TrieuChungs.Remove(trieuChungModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrieuChungModelExists(string id)
        {
            return _context.TrieuChungs.Any(e => e.MaTrieuChung == id);
        }
    }
}
