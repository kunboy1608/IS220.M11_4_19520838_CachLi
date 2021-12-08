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
    public class CN_TCController : Controller
    {
        private readonly CachLyContext _context;

        public CN_TCController(CachLyContext context)
        {
            _context = context;
        }

        // GET: CN_TC
        public async Task<IActionResult> Index()
        {
            return View(await _context.CN_TCs.ToListAsync());
        }

        // GET: CN_TC/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cN_TCModel = await _context.CN_TCs
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (cN_TCModel == null)
            {
                return NotFound();
            }

            return View(cN_TCModel);
        }

        // GET: CN_TC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CN_TC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCongNhan,MaTrieuChung")] CN_TCModel cN_TCModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cN_TCModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cN_TCModel);
        }

        // GET: CN_TC/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cN_TCModel = await _context.CN_TCs.FindAsync(id);
            if (cN_TCModel == null)
            {
                return NotFound();
            }
            return View(cN_TCModel);
        }

        // POST: CN_TC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCongNhan,MaTrieuChung")] CN_TCModel cN_TCModel)
        {
            if (id != cN_TCModel.MaCongNhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cN_TCModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CN_TCModelExists(cN_TCModel.MaCongNhan))
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
            return View(cN_TCModel);
        }

        // GET: CN_TC/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cN_TCModel = await _context.CN_TCs
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (cN_TCModel == null)
            {
                return NotFound();
            }

            return View(cN_TCModel);
        }

        // POST: CN_TC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cN_TCModel = await _context.CN_TCs.FindAsync(id);
            _context.CN_TCs.Remove(cN_TCModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CN_TCModelExists(string id)
        {
            return _context.CN_TCs.Any(e => e.MaCongNhan == id);
        }
    }
}
