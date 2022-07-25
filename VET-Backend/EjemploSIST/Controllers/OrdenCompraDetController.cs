using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploSIST.Data.DataAccess;
using EjemploSIST.Models.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EjemploSIST.Controllers
{
    public class OrdenCompraDetController : Controller
    {
        
        [Authorize]
        public IActionResult Index()
        {
            var dbOrdenCompraDet = new DAOrdenCompraDet();
            var model = dbOrdenCompraDet.getOrdenCompraDet();
            return View(model);
        }

        public IActionResult Create()
        {
            var DAOCD = new DAOrdenCompraCab();
            ViewBag.OrdenCompra = DAOCD.getOrdenCompraCab();
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrdenCompraDet Entidad)
        {
            Entidad.idOrdenCompraDet = 0;
            Entidad.FechaCreacion = DateTime.Now;
            var OC = new DAOrdenCompraDet();
            var model = OC.InsertOrdenCompraDet(Entidad);
            if (model > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(Entidad);
            }
        }

        public IActionResult Edit(int id)
        {
            var OCCab = new DAOrdenCompraCab();
            ViewBag.ListadoProveedor = OCCab.getOrdenCompraCab();

            var OCDet = new DAOrdenCompraDet();
            var modelo = OCDet.GetIdCompraDet(id);
            return View(modelo);
        }

        [HttpPost]
        public IActionResult Edit(OrdenCompraDet entidadOCD)
        {
            entidadOCD.FechaModificacion = DateTime.Now;
            var ControllerOCD = new DAOrdenCompraDet();
            var model = ControllerOCD.UpdateOrdenCompraDet(entidadOCD);
            if (model)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}