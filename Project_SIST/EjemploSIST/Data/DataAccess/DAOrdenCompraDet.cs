using EjemploSIST.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploSIST.Data.DataAccess
{
    public class DAOrdenCompraDet
    {
        public IEnumerable<OrdenCompraDet> getOrdenCompraDet()
        {
            var Listado = new List<OrdenCompraDet>();
            using (var db = new ApplicationDbContext())
            {
                Listado = db.OrdenCompraDet.Include(item => item.OrdenCompraCab).ToList();
            }
            return Listado;
        }

        public OrdenCompraDet GetIdCompraDet(int id)
        {
            var resultado = new OrdenCompraDet();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.OrdenCompraDet.Where(item => item.idOrdenCompraDet == id).FirstOrDefault();
            }
            return resultado;
        }
            
        public int InsertOrdenCompraDet(OrdenCompraDet Entidad)
        {
            var result = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(Entidad);
                db.SaveChanges(); //Guardamos en la base de datos el registro ingresado
                result = Entidad.idOrdenCompraDet;
            }
            return result;
        }

        public Boolean UpdateOrdenCompraDet(OrdenCompraDet EntidadActualizar)
        {
            var resultadoActualiza = false;
            using (var db = new ApplicationDbContext())
            {
                db.OrdenCompraDet.Attach(EntidadActualizar);//Referenciamos a la entidad
                db.Entry(EntidadActualizar).State = EntityState.Modified;
              //db.Entry(EntidadActualizar).State = EntityState.Modified;//Marcamos la fila para actualizar
                db.Entry(EntidadActualizar).Property(item => item.FechaCreacion).IsModified = false;
                resultadoActualiza = db.SaveChanges() != 0;//Guardamos en la base de datos
            }
            return resultadoActualiza;
        }
    }
}
