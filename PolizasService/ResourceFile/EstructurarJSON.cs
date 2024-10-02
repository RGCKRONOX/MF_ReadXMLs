using PolizasService.DTO;
using ReadXMLPremium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaXMLPremium.ResourceFile
{
    public class EstructurarJSON
    {
        Helpers helpers = new Helpers();
        public JsonCLIDocumentos CrearJSONDocumento(ComprobanteXML comprobante, DataXMLs dataXML)
        {
            return new JsonCLIDocumentos
            {
                Id = 0,
                Folio = comprobante.Folio,
                Serie = comprobante.Serie,
                NumMoneda = comprobante.Moneda == "USD" ? "2" : "1",
                TipoCambio = $"{comprobante.TipoCambio}",
                Referencia = $"{comprobante.Addenda.FELE.NbrOrden}",
                DescuentoDoc1 = "0",
                Importe = $"{comprobante.Total}",
                CodConcepto = $"{dataXML.ConceptoPremium}",
                Fecha = comprobante.Fecha.ToString("yyyy-MM-ddTHH:mm:ss"),
                CodigoCteProv = helpers.RemoveDashes(comprobante.Receptor.Rfc),
                Observaciones = $"{comprobante.Addenda.FELE.NbrOrden}",
                TimbrarCFDI = $"{dataXML.Timbrado}", // 1 es Timbrar, 0 es No timbrar
                LugarExp = $"{comprobante.LugarExpedicion}",
                FormaPago = $"{comprobante.FormaPago}",
                CondicionPago = $"{comprobante.CondicionesDePago}",
                UsoCFDI = $"{comprobante.Receptor.UsoCFDI}",
                MetodoPago = comprobante.MetodoPago == "PUE" ? "1" : "2",
                RegimenFiscal = comprobante.Receptor.RegimenFiscalReceptor,
                FileName = comprobante.nameFile,
                Procesado = "", //Bandera que usa el CLI
                Movimientos = comprobante.Conceptos.Select(c => new Movimiento
                {
                    Id = 0,
                    Consecutivo = "",
                    Unidades = $"{c.Cantidad}",
                    Precio = $"{c.ValorUnitario}",
                    Costo = $"{c.Importe}",
                    CodProdSer = c.NoIdentificacion,
                    CodAlmacen = "1",
                    Referencia = "",
                    CtextoExtra1 = ""
                }).ToList()
            };
        }

        public JsonOutput EstructuraJsoFinally(List<JsonCLIDocumentos> documentos)
        {
            return new JsonOutput
            {
                UserSDK = App.config.userSDK,
                PassSDK = App.config.passSDK,
                Instancia = App.config.dbInstance,
                UserSQL = App.config.dbUser,
                PassSQL = App.config.dbPass,
                EmpresaDB = App.config.dbDatabase,
                RutaEmpresa = App.config.rutaEmpresa,
                PassCSD = App.config.pssCSD,
                Documentos = documentos,
            };
        }

        public JsonCLIDocumentos CrearJSONPagos(ComprobanteXML comprobante, DataXMLs dataXML)
        {
            return new JsonCLIDocumentos
            {
                Id = 0,
                Folio = comprobante.Folio,
                Serie = comprobante.Serie,
                NumMoneda = comprobante.Pagos.Pago[0].MonedaP.ToString() == "USD" ? "2" : "1",
                TipoCambio = comprobante.Pagos?.Pago?.FirstOrDefault()?.TipoCambioP.ToString("F6") ?? "1.000000",
                Referencia = comprobante.Addenda?.FELE?.NbrOrden ?? "",
                DescuentoDoc1 = "0",
                Importe = comprobante.Pagos.Pago[0].Monto.ToString(),
                CodConcepto = dataXML.ConceptoPremium,
                Fecha = comprobante.Pagos?.Pago?.FirstOrDefault()?.FechaPago.ToString("yyyy-MM-ddTHH:mm:ss"),
                CodigoCteProv = helpers.RemoveDashes(comprobante.Receptor.Rfc),
                Observaciones = comprobante.Addenda?.FELE?.NbrOrden ?? "",
                TimbrarCFDI = dataXML.Timbrado, // 1 es Timbrar, 0 es No timbrar
                LugarExp = comprobante.LugarExpedicion,
                FormaPago = comprobante.Pagos?.Pago?.FirstOrDefault()?.FormaDePagoP,
                CondicionPago = "",
                UsoCFDI = comprobante.Receptor.UsoCFDI,
                MetodoPago = comprobante.MetodoPago == "PUE" ? "1" : "2",
                RegimenFiscal = comprobante.Receptor.RegimenFiscalReceptor,
                FileName = comprobante.nameFile,
                Procesado = "", //Bandera que usa el CLI
                Movimientos = new List<Movimiento>(), // Inicializar como lista vacía
                docRelacionados = comprobante.Pagos.Pago.SelectMany(p => p.DoctoRelacionado).Select(dr => new DocRelacionado
                {
                    UUID = dr.IdDocumento,
                    Serie = dr.Serie,
                    Folio = dr.Folio,
                    MonedaDR = dr.MonedaDR ?? "", // Opcional
                    NumParcialidad = dr.NumParcialidad, // Asegúrate de manejar correctamente los valores nulos
                    ImpPagado = dr.ImpPagado, // Asegúrate de manejar correctamente los valores nulos
                    ImpSaldoAnt = dr.ImpSaldoAnt // Asegúrate de manejar correctamente los valores nulos
                }).ToList() ?? new List<DocRelacionado>() // Si no hay, devolvemos una lista vacía

            };
        }

    }
}
