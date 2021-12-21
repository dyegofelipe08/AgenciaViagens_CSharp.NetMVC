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
    public class SuporteController : Controller
    {
        private readonly AgenciaViagensRcdDbContext _context;

        public SuporteController(AgenciaViagensRcdDbContext context)
        {
            _context = context;
        }

        // GET: Suporte
        public async Task<IActionResult> Index()
        {
            var agenciaViagensRcdDbContext = _context.Suporte.Include(s => s.Cliente);
            return View(await agenciaViagensRcdDbContext.ToListAsync());
        }

        // GET: Suporte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suporte = await _context.Suporte
                .Include(s => s.Cliente)
                .FirstOrDefaultAsync(m => m.IdSuporte == id);
            if (suporte == null)
            {
                return NotFound();
            }

            return View(suporte);
        }

        // GET: Suporte/Create
        public IActionResult Create()
        {
            ViewData["ClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Cpf");
            return View();
        }

        // POST: Suporte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSuporte,Mensagem,ClienteIdCliente")] Suporte suporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Cpf", suporte.ClienteIdCliente);
            return View(suporte);
        }

        // GET: Suporte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suporte = await _context.Suporte.FindAsync(id);
            if (suporte == null)
            {
                return NotFound();
            }
            ViewData["ClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Cpf", suporte.ClienteIdCliente);
            return View(suporte);
        }

        // POST: Suporte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSuporte,Mensagem,ClienteIdCliente")] Suporte suporte)
        {
            if (id != suporte.IdSuporte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuporteExists(suporte.IdSuporte))
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
            ViewData["ClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Cpf", suporte.ClienteIdCliente);
            return View(suporte);
        }

        // GET: Suporte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suporte = await _context.Suporte
                .Include(s => s.Cliente)
                .FirstOrDefaultAsync(m => m.IdSuporte == id);
            if (suporte == null)
            {
                return NotFound();
            }

            return View(suporte);
        }

        // POST: Suporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suporte = await _context.Suporte.FindAsync(id);
            _context.Suporte.Remove(suporte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuporteExists(int id)
        {
            return _context.Suporte.Any(e => e.IdSuporte == id);
        }
    }
}
