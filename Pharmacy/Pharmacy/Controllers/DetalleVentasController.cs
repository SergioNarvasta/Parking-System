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
    public class DetalleVentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalleVentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return View(await _context.DetalleVenta.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVenta = await _context.DetalleVenta
                .FirstOrDefaultAsync(m => m.CodDetVenta == id);
            if (detalleVenta == null)
            {
                return NotFound();
            }

            return View(detalleVenta);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodDetVenta,Cantidad,Precio,Subtotal,IGV,CodVenta")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleVenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detalleVenta);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVenta = await _context.DetalleVenta.FindAsync(id);
            if (detalleVenta == null)
            {
                return NotFound();
            }
            return View(detalleVenta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodDetVenta,Cantidad,Precio,Subtotal,IGV,CodVenta")] DetalleVenta detalleVenta)
        {
            if (id != detalleVenta.CodDetVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleVentaExists(detalleVenta.CodDetVenta))
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
            return View(detalleVenta);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVenta = await _context.DetalleVenta
                .FirstOrDefaultAsync(m => m.CodDetVenta == id);
            if (detalleVenta == null)
            {
                return NotFound();
            }

            return View(detalleVenta);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleVenta == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DetalleVenta'  is null.");
            }
            var detalleVenta = await _context.DetalleVenta.FindAsync(id);
            if (detalleVenta != null)
            {
                _context.DetalleVenta.Remove(detalleVenta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool DetalleVentaExists(int id)
        {
          return _context.DetalleVenta.Any(e => e.CodDetVenta == id);
        }
    }
}
