using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaViagensRcd.Models;

namespace AgenciaViagensRcd.Controllers
{
    public class DestinoPromoController : Controller
    {
        private readonly AgenciaViagensRcdDbContext _context;

        public DestinoPromoController(AgenciaViagensRcdDbContext context)
        {
            _context = context;
        }

        // GET: DestinoPromo
        public async Task<IActionResult> Index()
        {
            return View(await _context.DestinoPromo.ToListAsync());
        }

        // GET: DestinoPromo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoPromo = await _context.DestinoPromo
                .FirstOrDefaultAsync(m => m.IdDestinoPromo == id);
            if (destinoPromo == null)
            {
                return NotFound();
            }

            return View(destinoPromo);
        }

        // GET: DestinoPromo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DestinoPromo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDestinoPromo,NomeDestinoPromo,Preco,PrecoUnitarioPromo,UrlImagemPromo")] DestinoPromo destinoPromo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinoPromo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinoPromo);
        }

        // GET: DestinoPromo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoPromo = await _context.DestinoPromo.FindAsync(id);
            if (destinoPromo == null)
            {
                return NotFound();
            }
            return View(destinoPromo);
        }

        // POST: DestinoPromo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDestinoPromo,NomeDestinoPromo,Preco,PrecoUnitarioPromo,UrlImagemPromo")] DestinoPromo destinoPromo)
        {
            if (id != destinoPromo.IdDestinoPromo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinoPromo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinoPromoExists(destinoPromo.IdDestinoPromo))
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
            return View(destinoPromo);
        }

        // GET: DestinoPromo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoPromo = await _context.DestinoPromo
                .FirstOrDefaultAsync(m => m.IdDestinoPromo == id);
            if (destinoPromo == null)
            {
                return NotFound();
            }

            return View(destinoPromo);
        }

        // POST: DestinoPromo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinoPromo = await _context.DestinoPromo.FindAsync(id);
            _context.DestinoPromo.Remove(destinoPromo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinoPromoExists(int id)
        {
            return _context.DestinoPromo.Any(e => e.IdDestinoPromo == id);
        }
    }
}
