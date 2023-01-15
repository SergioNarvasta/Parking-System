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
            return await connection.QuerySingleAsync<int>(@" PA_WEB_ReqCompra_Inserta @cia_codcia = @cia_codcia, @suc_codsuc = @suc_codsuc, @rco_codepk = @Rco_codepk,
              @rco_numrco = @Rco_numero, @tin_codtin = @tin_codtin, @rco_motivo = @rco_motivo, @rco_glorco = @rco_glorco,
              @cco_codepk = @cco_codepk, @rco_sitrco = @rco_sitrco, @rco_codusu = @rco_codusu, @ung_codepk = @ung_codepk, @rco_indval = @rco_indval,
              @rco_indest = @rco_indest, @rco_rembls = @rco_rembls, @rco_presup = @rco_presup, @rco_priori = @rco_priori, @tre_codepk = @tre_codepk,
              @rco_estado = @rco_estado, @dis_codepk = @dis_codepk, @uap_codepk = @uap_codepk, @occ_codepk = @occ_codepk,
              @rcd_corite = @DPrd_item,  @prd_codepk = @DPrd_codigo, @rcd_desprd = @DPrd_descri,@rcd_glorcd = @DPrd_glosa ,@rcd_canate=@DPrd_cantidad,
              @ccr_codepk = @DPrd_codprov,@ume_codepk = @DPrd_unidad ,
              @rcf_corite1= @DFi_item1 ,@rcf_codarc1 = @DFi_cod1 ,@rcf_nomarc1 = @DFi_nom1,@rcf_file1 = @DFi_fil1,
              @rcf_corite2= @DFi_item2 ,@rcf_codarc2 = @DFi_cod2 ,@rcf_nomarc2 = @DFi_nom2,@rcf_file2 = @DFi_fil2 ", rQCompra);
        }
    }
}
