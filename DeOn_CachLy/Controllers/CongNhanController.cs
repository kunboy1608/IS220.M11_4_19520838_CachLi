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
    public class CongNhanController : Controller
    {
        private readonly CachLyContext _context;

        public CongNhanController(CachLyContext context)
        {
            _context = context;
        }

        // GET: CongNhan
        public async Task<IActionResult> Index()
        {
            return View(await _context.CongNhans.ToListAsync());
        }

        // GET: CongNhan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congNhanModel = await _context.CongNhans
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (congNhanModel == null)
            {
                return NotFound();
            }

            return View(congNhanModel);
        }

        // GET: CongNhan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CongNhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCongNhan,TenCongNhan,GioiTinh,Namsinh,NuocVe,MaDiemCachLy")] CongNhanModel congNhanModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congNhanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(congNhanModel);
        }

        // GET: CongNhan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congNhanModel = await _context.CongNhans.FindAsync(id);
            if (congNhanModel == null)
            {
                return NotFound();
            }
            return View(congNhanModel);
        }

        // POST: CongNhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCongNhan,TenCongNhan,GioiTinh,Namsinh,NuocVe,MaDiemCachLy")] CongNhanModel congNhanModel)
        {
            if (id != congNhanModel.MaCongNhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congNhanModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongNhanModelExists(congNhanModel.MaCongNhan))
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
            return View(congNhanModel);
        }

        // GET: CongNhan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congNhanModel = await _context.CongNhans
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (congNhanModel == null)
            {
                return NotFound();
            }

            return View(congNhanModel);
        }

        // POST: CongNhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var congNhanModel = await _context.CongNhans.FindAsync(id);
            _context.CongNhans.Remove(congNhanModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongNhanModelExists(string id)
        {
            return _context.CongNhans.Any(e => e.MaCongNhan == id);
        }
    }
}
