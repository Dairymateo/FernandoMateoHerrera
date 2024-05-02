using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FernandoMateoHerrera.Data;
using FernandoMateoHerrera.Models;

//

namespace FernandoMateoHerrera.Controllers
{
    public class MHerrerasController : Controller
    {
        private readonly FernandoMateoHerreraContext _context;

        public MHerrerasController(FernandoMateoHerreraContext context)
        {
            _context = context;
        }

        // GET: MHerreras
        public async Task<IActionResult> Index()
        {
            var fernandoMateoHerreraContext = _context.MHerrera.Include(m => m.Carrera);
            return View(await fernandoMateoHerreraContext.ToListAsync());
        }

        // GET: MHerreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mHerrera = await _context.MHerrera
                .Include(m => m.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mHerrera == null)
            {
                return NotFound();
            }

            return View(mHerrera);
        }

        // GET: MHerreras/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "CarreraId");
            return View();
        }

        // POST: MHerreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Ecuatoriano,TimpoPromedio,FechaNacimiento,CarreraId")] MHerrera mHerrera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mHerrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "CarreraId", mHerrera.CarreraId);
            return View(mHerrera);
        }

        // GET: MHerreras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mHerrera = await _context.MHerrera.FindAsync(id);
            if (mHerrera == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "CarreraId", mHerrera.CarreraId);
            return View(mHerrera);
        }

        // POST: MHerreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Ecuatoriano,TimpoPromedio,FechaNacimiento,CarreraId")] MHerrera mHerrera)
        {
            if (id != mHerrera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mHerrera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MHerreraExists(mHerrera.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "CarreraId", mHerrera.CarreraId);
            return View(mHerrera);
        }

        // GET: MHerreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mHerrera = await _context.MHerrera
                .Include(m => m.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mHerrera == null)
            {
                return NotFound();
            }

            return View(mHerrera);
        }

        // POST: MHerreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mHerrera = await _context.MHerrera.FindAsync(id);
            if (mHerrera != null)
            {
                _context.MHerrera.Remove(mHerrera);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MHerreraExists(int id)
        {
            return _context.MHerrera.Any(e => e.Id == id);
        }
    }
}
