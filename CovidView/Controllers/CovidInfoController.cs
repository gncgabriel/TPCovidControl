using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CovidView.Data;
using CovidView.Models;
using Microsoft.AspNetCore.Authorization;

namespace CovidView.Controllers
{
    public class CovidInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CovidInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CovidInfo
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Covid_Info.ToListAsync());
        }

        // GET: CovidInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidInfo = await _context.Covid_Info
                .FirstOrDefaultAsync(m => m.id == id);
            if (covidInfo == null)
            {
                return NotFound();
            }

            return View(covidInfo);
        }

        // GET: CovidInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CovidInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Casos_Confirmados,Mortes,Recuperados,pais,id")] CovidInfo covidInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(covidInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(covidInfo);
        }

        // GET: CovidInfo/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidInfo = await _context.Covid_Info.FindAsync(id);
            if (covidInfo == null)
            {
                return NotFound();
            }
            return View(covidInfo);
        }

        // POST: CovidInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Casos_Confirmados,Mortes,Recuperados,pais,id")] CovidInfo covidInfo)
        {
            if (id != covidInfo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(covidInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CovidInfoExists(covidInfo.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToRoute(new { controller = "Paises", action = "Details", id = covidInfo.pais });
            }
            return View(covidInfo);
        }

        // GET: CovidInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidInfo = await _context.Covid_Info
                .FirstOrDefaultAsync(m => m.id == id);
            if (covidInfo == null)
            {
                return NotFound();
            }

            return View(covidInfo);
        }

        // POST: CovidInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var covidInfo = await _context.Covid_Info.FindAsync(id);
            _context.Covid_Info.Remove(covidInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CovidInfoExists(int id)
        {
            return _context.Covid_Info.Any(e => e.id == id);
        }
    }
}
