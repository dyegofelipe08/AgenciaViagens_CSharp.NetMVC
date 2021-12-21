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
    public class PedidoPromoController : Controller
    {
        private readonly AgenciaViagensRcdDbContext _context;

        public PedidoPromoController(AgenciaViagensRcdDbContext context)
        {
            _context = context;
        }

        // GET: PedidoPromo
        public async Task<IActionResult> Index()
        {
            var agenciaViagensRcdDbContext = _context.PedidoPromo.Include(p => p.Cliente).Include(p => p.DestinoPromo);
            return View(await agenciaViagensRcdDbContext.ToListAsync());
        }

        // GET: PedidoPromo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoPromo = await _context.PedidoPromo
                .Include(p => p.Cliente)
                .Include(p => p.DestinoPromo)
                .FirstOrDefaultAsync(m => m.IdPedidoPromo == id);
            if (pedidoPromo == null)
            {
                return NotFound();
            }

            return View(pedidoPromo);
        }

        // GET: PedidoPromo/Create
        public IActionResult Create()
        {
            ViewData["ClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Cpf");
            ViewData["DestinoPromoIdDestinoPromo"] = new SelectList(_context.DestinoPromo, "IdDestinoPromo", "NomeDestinoPromo");
            return View();
        }

        // POST: PedidoPromo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedidoPromo,ClienteIdCliente,DestinoPromoIdDestinoPromo")] PedidoPromo pedidoPromo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoPromo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Cpf", pedidoPromo.ClienteIdCliente);
            ViewData["DestinoPromoIdDestinoPromo"] = new SelectList(_context.DestinoPromo, "IdDestinoPromo", "NomeDestinoPromo", pedidoPromo.DestinoPromoIdDestinoPromo);
            return View(pedidoPromo);
        }

        // GET: PedidoPromo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoPromo = await _context.PedidoPromo.FindAsync(id);
            if (pedidoPromo == null)
            {
                return NotFound();
            }
            ViewData["ClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Cpf", pedidoPromo.ClienteIdCliente);
            ViewData["DestinoPromoIdDestinoPromo"] = new SelectList(_context.DestinoPromo, "IdDestinoPromo", "NomeDestinoPromo", pedidoPromo.DestinoPromoIdDestinoPromo);
            return View(pedidoPromo);
        }

        // POST: PedidoPromo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedidoPromo,ClienteIdCliente,DestinoPromoIdDestinoPromo")] PedidoPromo pedidoPromo)
        {
            if (id != pedidoPromo.IdPedidoPromo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoPromo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoPromoExists(pedidoPromo.IdPedidoPromo))
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
            ViewData["ClienteIdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Cpf", pedidoPromo.ClienteIdCliente);
            ViewData["DestinoPromoIdDestinoPromo"] = new SelectList(_context.DestinoPromo, "IdDestinoPromo", "NomeDestinoPromo", pedidoPromo.DestinoPromoIdDestinoPromo);
            return View(pedidoPromo);
        }

        // GET: PedidoPromo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoPromo = await _context.PedidoPromo
                .Include(p => p.Cliente)
                .Include(p => p.DestinoPromo)
                .FirstOrDefaultAsync(m => m.IdPedidoPromo == id);
            if (pedidoPromo == null)
            {
                return NotFound();
            }

            return View(pedidoPromo);
        }

        // POST: PedidoPromo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoPromo = await _context.PedidoPromo.FindAsync(id);
            _context.PedidoPromo.Remove(pedidoPromo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoPromoExists(int id)
        {
            return _context.PedidoPromo.Any(e => e.IdPedidoPromo == id);
        }
    }
}
