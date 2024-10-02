using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizasService.DTO
{
    public class ComprobanteXML
    {
        public string Version { get; set; }
        public string Serie { get; set; } = string.Empty;
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string Sello { get; set; }
        public string FormaPago { get; set; } = "99";
        public string NoCertificado { get; set; }
        public string Certificado { get; set; }
        public string CondicionesDePago { get; set; } = string.Empty;
        public decimal SubTotal { get; set; }
        public string Moneda { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal Total { get; set; }
        public string TipoDeComprobante { get; set; }
        public string Exportacion { get; set; } = "01";
        public string MetodoPago { get; set; }
        public string LugarExpedicion { get; set; } = string.Empty;
        public string nameFile { get; set; }
        public Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
        public List<Concepto> Conceptos { get; set; }
        public Impuestos Impuestos { get; set; }
        public Addenda Addenda { get; set; }
        public CfdiRelacionados CfdiRelacionados { get; set; } = new CfdiRelacionados();
        public Pago20 Pagos { get; set; } = new Pago20(); // Complemento de pagos
    }

    public class Emisor
    {
        public string Nombre { get; set; }
        public string RegimenFiscal { get; set; }
        public string Rfc { get; set; }
    }

    public class Receptor
    {
        public string Rfc { get; set; }
        public string Nombre { get; set; }
        public string UsoCFDI { get; set; }
        public string RegimenFiscalReceptor { get; set; }
        public string DomicilioFiscalReceptor { get; set; }
    }
    public class CfdiRelacionados
    {
        public string TipoRelacion { get; set; } = string.Empty;
        public List<CfdiRelacionado> CfdiRelacionadosList { get; set; } = new List<CfdiRelacionado>();
    }

    public class CfdiRelacionado
    {
        public string UUID { get; set; } = string.Empty;
    }

    public class Concepto
    {
        public decimal Cantidad { get; set; }
        public string ClaveProdServ { get; set; }
        public string ClaveUnidad { get; set; } = string.Empty;
        public string Unidad { get; set; } = string.Empty;
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public string NoIdentificacion { get; set; }
        public decimal ValorUnitario { get; set; }
        public string ObjetoImp { get; set; }
        public Impuestos Impuestos { get; set; } = new Impuestos();
    }

    public class Impuestos
    {
        public decimal TotalImpuestosTrasladados { get; set; } = 0;
        public List<Traslado> Traslados { get; set; } = new List<Traslado>();
    }

    public class Traslado
    {
        public decimal Base { get; set; } = 0; 
        public decimal Importe { get; set; } = 0; 
        public string Impuesto { get; set; } = string.Empty; 
        public decimal TasaOCuota { get; set; } = 0; 
        public string TipoFactor { get; set; } = string.Empty; 
    }

    public class Addenda
    {
        public FELE FELE { get; set; } = new FELE(); 
    }

    public class FELE
    {
        public string OCRelac { get; set; } = string.Empty; 
        public string NbrOrden { get; set; } = string.Empty; 
        public string Deposito { get; set; } = string.Empty; 
    }

    public class Pago20
    {
        public PagoTotales Totales { get; set; } = new PagoTotales();
        public List<Pago> Pago { get; set; } = new List<Pago>();
    }

    public class PagoTotales
    {
        public decimal TotalTrasladosBaseIVA16 { get; set; } = 0.0m;
        public decimal TotalTrasladosImpuestoIVA16 { get; set; } = 0.0m;
        public decimal MontoTotalPagos { get; set; } = 0.0m;
    }

    public class Pago
    {
        public DateTime FechaPago { get; set; } = DateTime.Now;
        public string MonedaP { get; set; } = "MXN";
        public decimal TipoCambioP { get; set; } = 1.0m;
        public string FormaDePagoP { get; set; } = "03"; // Transferencia bancaria
        public decimal Monto { get; set; } = 0.0m;
        public List<DoctoRelacionado> DoctoRelacionado { get; set; } = new List<DoctoRelacionado>();
        public PagoImpuestosP ImpuestosP { get; set; } = new PagoImpuestosP();
    }

    public class DoctoRelacionado
    {
        public string IdDocumento { get; set; } = string.Empty;
        public string Serie { get; set; } = string.Empty;
        public string Folio { get; set; } = string.Empty;
        public string MonedaDR { get; set; } = "MXN";
        public int NumParcialidad { get; set; } = 1;
        public decimal ImpSaldoAnt { get; set; } = 0.0m;
        public decimal ImpPagado { get; set; } = 0.0m;
        public decimal ImpSaldoInsoluto { get; set; } = 0.0m;
        public string ObjetoImpDR { get; set; } = "02"; // Gravado
        public decimal EquivalenciaDR { get; set; } = 1.0m;
        public PagoImpuestosDR ImpuestosDR { get; set; } = new PagoImpuestosDR();
    }

    public class PagoImpuestosDR
    {
        public List<PagoTrasladoDR> TrasladosDR { get; set; } = new List<PagoTrasladoDR>();
    }

    public class PagoTrasladoDR
    {
        public decimal BaseDR { get; set; } = 0.0m;
        public string ImpuestoDR { get; set; } = "002";  // IVA
        public string TipoFactorDR { get; set; } = "Tasa";
        public decimal TasaOCuotaDR { get; set; } = 0.160000m;
        public decimal ImporteDR { get; set; } = 0.0m;
    }

    public class PagoImpuestosP
    {
        public List<PagoTrasladoP> TrasladosP { get; set; } = new List<PagoTrasladoP>();
    }

    public class PagoTrasladoP
    {
        public decimal BaseP { get; set; } = 0.0m;
        public string ImpuestoP { get; set; } = "002";  // IVA
        public string TipoFactorP { get; set; } = "Tasa";
        public decimal TasaOCuotaP { get; set; } = 0.160000m;
        public decimal ImporteP { get; set; } = 0.0m;
    }
}
