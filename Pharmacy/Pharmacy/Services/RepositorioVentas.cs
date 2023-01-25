using Dapper;
using Pharmacy.Models;
using Microsoft.Data.SqlClient;

namespace Pharmacy.Services
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

        Task<int> Registra_Venta(Venta venta)
    }
    
    public class RepositorioVenta:IRepositorioVenta
    {
        private readonly string connectionString;

        public RepositorioVenta(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");      
        }
        public async Task<int> Registra_Venta(Venta venta)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QuerySingleAsync<int>(@" PA_WEB_ReqCompra_Inserta  ", rQCompra);
        }
    }
}
