using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploSIST.Data.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace EjemploSIST.Controllers
{
    public class OrdenCompraCabController : Controller
    {
        public IActionResult Index()
        {
            var Listado = new DAOrdenCompraCab();
            var models = Listado.getOrdenCompraCab();

            return View(models);
        }
    }
}