using Dapper;
using HDProjectWeb.Models;
using HDProjectWeb.Models.Detalles;
using Microsoft.Data.SqlClient;

namespace HDProjectWeb.Services
{
    public interface IRepositorioVenta
    {
        Task<RQCompra> ObtenerporCodigo(string Rco_numero);
        Task Actualizar(RQCompra rQCompraEd);       
        Task<IEnumerable<RQCompraCab>> Obtener(string periodo, PaginacionViewModel paginacion, int EpkUser, string orden, string estado1, string estado2);
        Task<int> ContarRegistros(string periodo, int EpkUser, string estado1, string estado2);  
        Task<int> ContarRegistrosBusqueda(string periodo, int EpkUser, string busqueda, string estado1, string estado2);
        Task<IEnumerable<RQCompraCab>> BusquedaMultiple(string periodo, PaginacionViewModel paginacion, int EpkUser, string busqueda, string estado1, string estado2);
        Task<RQCompra> ObtenerporEpk(int Rco_codepk);
        Task<int> AprobarReq(int cia, int suc, int epk, int uap);
        Task<int> RechazaReq(int cia, int suc, int epk, int uap, string mot);
        Task<int> DevuelveReq(int cia, int suc, int epk, int uap);
        Task<string> ObtenerMaxRCO();
        Task<int> Registra_Req(RQCompra rQCompra);
    }
    public class RepositorioRQCompra:IRepositorioRQCompra
    {
        private readonly string connectionString;

        public RepositorioRQCompra(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");      
        }
    }
}
