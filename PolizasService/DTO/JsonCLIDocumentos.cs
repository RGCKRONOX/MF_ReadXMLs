using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizasService.DTO
{
    public class JsonCLIDocumentos
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public string Serie { get; set; }
        public string NumMoneda { get; set; }
        public string TipoCambio { get; set; }
        public string Referencia { get; set; }
        public string DescuentoDoc1 { get; set; }
        public string Importe { get; set; }
        public string CodConcepto { get; set; }
        public string Fecha { get; set; }
        public string CodigoCteProv { get; set; }
        public string Observaciones { get; set; }
        public string TimbrarCFDI { get; set; } // 1 es Timbrar, 0 es No timbrar
        public string LugarExp { get; set; }
        public string FormaPago { get; set; }
        public string CondicionPago { get; set; }
        public string UsoCFDI { get; set; }
        public string MetodoPago { get; set; }

        public string FileName { get; set; }
        public string RegimenFiscal { get; set; }
        public string Procesado { get; set; }
        // Lista opcional de movimientos
        public List<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

        // Lista opcional de documentos relacionados
        public List<DocRelacionado> docRelacionados { get; set; } = new List<DocRelacionado>();
    }

    public class Movimiento
    {
        public int Id { get; set; }
        public string Consecutivo { get; set; }
        public string Unidades { get; set; }
        public string Precio { get; set; }
        public string Costo { get; set; }
        public string CodProdSer { get; set; }
        public string CodAlmacen { get; set; }
        public string Referencia { get; set; }
        public string CtextoExtra1 { get; set; }
    }

    public class DocRelacionado
    {
        public string UUID { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string MonedaDR { get; set; }
        public decimal? NumParcialidad { get; set; }
        public decimal? ImpPagado { get; set; }
        public decimal? ObjetoImpDR { get; set; }
        public decimal? ImpSaldoAnt { get; set; }
    }
}