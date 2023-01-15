using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using Pharmacy.Models.Entities;

namespace Pharmacy.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IRepositorioRQCompra _repositorioRQCompra;

        public VentasController(ApplicationDbContext context, IRepositorioRQCompra repositorioRQCompra;)
        {
            _context = context;
            _repositorioRQCompra = repositorioRQCompra;
        }
        public async Task<IActionResult> Index()
        {
              return View(await _context.Venta.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta
                .FirstOrDefaultAsync(m => m.Codventa == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrar_Venta(Venta venta)
        {
            int result = await _repositorioRQCompra.Registra_Venta(venta);
            return View(venta);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            return View(venta);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codventa,Descuento,Total,Fecha,TipoPago,CodCliente")] Venta venta)
        {
            if (id != venta.Codventa)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.Codventa))
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
            return View(venta);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta
                .FirstOrDefaultAsync(m => m.Codventa == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Venta == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Venta'  is null.");
            }
            var venta = await _context.Venta.FindAsync(id);
            if (venta != null)
            {
                _context.Venta.Remove(venta);
            }  
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool VentaExists(int id)
        {
          return _context.Venta.Any(e => e.Codventa == id);
        }
    }
}
