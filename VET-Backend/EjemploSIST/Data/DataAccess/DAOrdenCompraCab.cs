using EjemploSIST.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploSIST.Data.DataAccess
{
    public class DAOrdenCompraCab
    {
        public IEnumerable<OrdenCompraCab>getOrdenCompraCab()
        {
            var Listado = new List<OrdenCompraCab>();
            using (var db = new ApplicationDbContext())
            {
                Listado = db.OrdenCompraCab.ToList();
            }
            return Listado;
        }

        public OrdenCompraCab GetIdCompraCab(int id)
        {
            var resultado = new OrdenCompraCab();
            using(var db = new ApplicationDbContext())
            {
                resultado = db.OrdenCompraCab.Where(item => item.idOrdenCompraCab == id).FirstOrDefault();
            }
            return resultado;
        }

        public Boolean UpdateOrdenCompraCab(OrdenCompraCab EntidadOCC)
        {
            var resultadoUCC = false;
            using (var db = new ApplicationDbContext())
            {
                db.OrdenCompraCab.Attach(EntidadOCC);//Referenciamos a la Entidad
                db.Entry(EntidadOCC).State = EntityState.Modified;
                resultadoUCC = db.SaveChanges() != 0;//Guardamos en la BD
            }
            return resultadoUCC;
        }
    }
}
