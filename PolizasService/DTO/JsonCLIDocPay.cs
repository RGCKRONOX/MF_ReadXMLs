using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaXMLPremium.DTO
{
    public class JsonCLIHeaderPay
    {
        public string UserSDK { get; set; }
        public string PassSDK { get; set; }
        public string Instancia { get; set; }
        public string UserSQL { get; set; }
        public string PassSQL { get; set; }
        public string EmpresaDB { get; set; }
        public string RutaEmpresa { get; set; }
        public string PassCSD { get; set; }
        public List<JsonCLIDocumentoPay> Documentos { get; set; } // Lista de documentos
    }

    public class JsonCLIDocumentoPay
    {
        public int Id { get; set; } // Cambiado a int para coincidir con el JSON
        public string Folio { get; set; }
        public string Serie { get; set; }
        public string NumMoneda { get; set; }
        public string TipoCambio { get; set; }
        public string Importe { get; set; }
        public string DescuentoDoc1 { get; set; }
        public string CodConcepto { get; set; }
        public string Fecha { get; set; }
        public string CodigoCteProv { get; set; }
        public string CodigoAgente { get; set; } // Agregado según el JSON
        public string Referencia { get; set; }
        public string Observaciones { get; set; }
        public string TimbrarCFDI { get; set; } // Agregado según el JSON
        public string LugarExp { get; set; } // Agregado según el JSON
        public string FormaPago { get; set; } // Agregado según el JSON
        public string CondicionPago { get; set; } // Agregado según el JSON
        public string UsoCFDI { get; set; } // Agregado según el JSON
        public string MetodoPago { get; set; } // Agregado según el JSON
        public string FileName { get; set; } // Agregado según el JSON
        public string RegimenFiscal { get; set; } // Agregado según el JSON
        public List<MovimientoPay> Movimientos { get; set; }
        public List<DocPagoSaldar> DocPagosSaldar { get; set; } // Lista para docPagosSaldar
    }

    public class MovimientoPay
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

    public class DocPagoSaldar
    {
        public string UuidFactura { get; set; }
        public string MonedaDR { get; set; }
        public string ImpPagado { get; set; }
        public string TipoCambio { get; set; }
    }
}
