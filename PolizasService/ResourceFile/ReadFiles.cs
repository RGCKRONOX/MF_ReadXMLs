using LecturaXMLPremium.DTO;
using LecturaXMLPremium.ResourceFile;
using Newtonsoft.Json;
using PolizasService.DTO;
using ReadXMLPremium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PolizasService.ResourceFile
{
    public class ReadFiles
    {
        readonly Helpers helpers = new Helpers();
        readonly EstructurarJSON estructurarJSON = new EstructurarJSON();
        public bool ReadXML(DataXMLs dataXML)
        {
            try
            {
                string[] xmlFiles = Directory.GetFiles(dataXML.FileURL, "*.xml");
                List<JsonCLIDocumentos> documentosJsonList = new List<JsonCLIDocumentos>();

                foreach (string xmlFile in xmlFiles)
                {
                    App.logs.add($"Leyendo el archivo : [{xmlFile}]");
                    try
                    {
                        ComprobanteXML comprobante = ReadXMLs(xmlFile);
                        if (comprobante != null)
                        {
                            JsonCLIDocumentos documentoJson = estructurarJSON.CrearJSONDocumento(comprobante, dataXML);
                            documentosJsonList.Add(documentoJson);
                        }
                        App.logs.add("Se creo bien el archivo JSON Para envio de documento");

                    }
                    catch (Exception ex)
                    {
                        App.logs.add($"Error al leer el archivo {xmlFile} - {ex.Message}");
                    }
                }
                JsonOutput jsonCLI = estructurarJSON.EstructuraJsoFinally(documentosJsonList);
                string jsonComprobanteArray = JsonConvert.SerializeObject(jsonCLI, Formatting.Indented);
                string jsonFilePath = Path.Combine(dataXML.FileURL, "CLI.json");
                File.WriteAllText(jsonFilePath, jsonComprobanteArray);
                App.logs.add($"*******************");
                App.logs.add($"Archivo creado y Guardado : concepto {dataXML.ConceptoPremium} -{dataXML.TipoDocumentoXML} // {jsonFilePath}");
                App.logs.add($"*******************");
                return true;
            }
            catch (Exception ex)
            {
                App.logs.add($"Error al acceder al directorio: {ex.Message}");
                return false;
            }
        }

        public ComprobanteXML ReadXMLs(string xmlFilePath)
        {
            try
            {
                XDocument xmlDocument = XDocument.Load(xmlFilePath);
                XNamespace nsCfdi = "http://www.sat.gob.mx/cfd/4";
                XNamespace nsPago20 = "http://www.sat.gob.mx/Pagos20";

                ComprobanteXML comprobanteXML = new ComprobanteXML
                {
                    Version = (string)xmlDocument.Root.Attribute("Version"),
                    Serie = (string)xmlDocument.Root.Attribute("Serie"),
                    Folio = (string)xmlDocument.Root.Attribute("Folio"),
                    Fecha = DateTime.Parse((string)xmlDocument.Root.Attribute("Fecha")),
                    Sello = (string)xmlDocument.Root.Attribute("Sello"),
                    FormaPago = (string)xmlDocument.Root.Attribute("FormaPago"),
                    NoCertificado = (string)xmlDocument.Root.Attribute("NoCertificado"),
                    Certificado = (string)xmlDocument.Root.Attribute("Certificado"),
                    CondicionesDePago = (string)xmlDocument.Root.Attribute("CondicionesDePago"),
                    SubTotal = Convert.ToDecimal((string)xmlDocument.Root.Attribute("SubTotal") ?? "0"),
                    Moneda = (string)xmlDocument.Root.Attribute("Moneda"),
                    TipoCambio = Convert.ToDecimal((string)xmlDocument.Root.Attribute("TipoCambio") ?? "0"),
                    Total = Convert.ToDecimal((string)xmlDocument.Root.Attribute("Total") ?? "0"),
                    TipoDeComprobante = (string)xmlDocument.Root.Attribute("TipoDeComprobante"),
                    Exportacion = (string)xmlDocument.Root.Attribute("Exportacion"),
                    MetodoPago = (string)xmlDocument.Root.Attribute("MetodoPago"),
                    LugarExpedicion = (string)xmlDocument.Root.Attribute("LugarExpedicion"),
                    nameFile = xmlFilePath,
                    Emisor = new Emisor
                    {
                        Nombre = (string)xmlDocument.Root.Element(nsCfdi + "Emisor")?.Attribute("Nombre"),
                        RegimenFiscal = (string)xmlDocument.Root.Element(nsCfdi + "Emisor")?.Attribute("RegimenFiscal"),
                        Rfc = (string)xmlDocument.Root.Element(nsCfdi + "Emisor")?.Attribute("Rfc")
                    },
                    Receptor = new Receptor
                    {
                        Rfc = (string)xmlDocument.Root.Element(nsCfdi + "Receptor")?.Attribute("Rfc"),
                        Nombre = (string)xmlDocument.Root.Element(nsCfdi + "Receptor")?.Attribute("Nombre"),
                        UsoCFDI = (string)xmlDocument.Root.Element(nsCfdi + "Receptor")?.Attribute("UsoCFDI"),
                        RegimenFiscalReceptor = (string)xmlDocument.Root.Element(nsCfdi + "Receptor")?.Attribute("RegimenFiscalReceptor"),
                        DomicilioFiscalReceptor = (string)xmlDocument.Root.Element(nsCfdi + "Receptor")?.Attribute("DomicilioFiscalReceptor")
                    },
                    Conceptos = new List<Concepto>(),
                    CfdiRelacionadosList = new List<CfdiRelacionados>(),
                    Impuestos = new Impuestos
                    {
                        TotalImpuestosTrasladados = Convert.ToDecimal((string)xmlDocument.Root.Element(nsCfdi + "Impuestos")?.Attribute("TotalImpuestosTrasladados") ?? "0"),
                        Traslados = new List<Traslado>()
                    },
                    Addenda = new Addenda
                    {
                        FELE = new FELE
                        {
                            OCRelac = (string)xmlDocument.Root.Element(nsCfdi + "Addenda")?.Element("FELE")?.Element("noOrdenCompra"),
                            NbrOrden = (string)xmlDocument.Root.Element(nsCfdi + "Addenda")?.Element("FELE")?.Element("noOrdenVenta"),
                            Deposito = (string)xmlDocument.Root.Element(nsCfdi + "Addenda")?.Element("FELE")?.Element("Comentarios")
                        }
                    }
                };
                // **Procesar CfdiRelacionados**
                var cfdiRelacionadosElements = xmlDocument.Root.Elements(nsCfdi + "CfdiRelacionados");
                foreach (var cfdiRelacionadosElement in cfdiRelacionadosElements)
                {
                    var cfdiRelacionados = new CfdiRelacionados
                    {
                        TipoRelacion = (string)cfdiRelacionadosElement.Attribute("TipoRelacion") // Obtiene el TipoRelacion
                    };
                    foreach (var cfdiRelacionado in cfdiRelacionadosElement.Elements(nsCfdi + "CfdiRelacionado"))
                    {
                        cfdiRelacionados.CfdiRelacionado.Add(new CfdiRelacionado
                        {
                            UUID = (string)cfdiRelacionado.Attribute("UUID")
                        });
                    }

                    // Añade el objeto cfdiRelacionados a la lista en comprobanteXML
                    comprobanteXML.CfdiRelacionadosList.Add(cfdiRelacionados);
                }

                // Procesar conceptos
                var conceptosElement = xmlDocument.Root.Element(nsCfdi + "Conceptos");
                if (conceptosElement != null)
                {
                    foreach (var concepto in conceptosElement.Elements(nsCfdi + "Concepto"))
                    {
                        var nuevoConcepto = new Concepto
                        {
                            Cantidad = Convert.ToDecimal((string)concepto.Attribute("Cantidad") ?? "0"),
                            ClaveProdServ = (string)concepto.Attribute("ClaveProdServ"),
                            ClaveUnidad = (string)concepto.Attribute("ClaveUnidad"),
                            Unidad = (string)concepto.Attribute("Unidad"),
                            Descripcion = (string)concepto.Attribute("Descripcion"),
                            Importe = Convert.ToDecimal((string)concepto.Attribute("Importe") ?? "0"),
                            NoIdentificacion = (string)concepto.Attribute("NoIdentificacion"),
                            ValorUnitario = Convert.ToDecimal((string)concepto.Attribute("ValorUnitario") ?? "0"),
                            ObjetoImp = (string)concepto.Attribute("ObjetoImp"),
                            Impuestos = new Impuestos
                            {
                                Traslados = new List<Traslado>()
                            }
                        };

                        // Procesar traslados
                        var impuestosElement = concepto.Element(nsCfdi + "Impuestos");
                        var trasladosElement = impuestosElement?.Element(nsCfdi + "Traslados");
                        if (trasladosElement != null)
                        {
                            foreach (var traslado in trasladosElement.Elements(nsCfdi + "Traslado"))
                            {
                                nuevoConcepto.Impuestos.Traslados.Add(new Traslado
                                {
                                    Base = Convert.ToDecimal((string)traslado.Attribute("Base") ?? "0"),
                                    Importe = Convert.ToDecimal((string)traslado.Attribute("Importe") ?? "0"),
                                    Impuesto = (string)traslado.Attribute("Impuesto"),
                                    TasaOCuota = Convert.ToDecimal((string)traslado.Attribute("TasaOCuota") ?? "0"),
                                    TipoFactor = (string)traslado.Attribute("TipoFactor")
                                });
                            }
                        }
                        comprobanteXML.Conceptos.Add(nuevoConcepto);
                    }
                }

                // Procesar complemento de pagos
                var complementoElement = xmlDocument.Root.Element(nsCfdi + "Complemento");
                var pagosElement = complementoElement?.Element(nsPago20 + "Pagos");
                if (pagosElement != null)
                {
                    comprobanteXML.Pagos = new Pago20
                    {
                        Totales = new PagoTotales
                        {
                            TotalTrasladosBaseIVA16 = Convert.ToDecimal((string)pagosElement.Element(nsPago20 + "Totales")?.Attribute("TotalTrasladosBaseIVA16") ?? "0"),
                            TotalTrasladosImpuestoIVA16 = Convert.ToDecimal((string)pagosElement.Element(nsPago20 + "Totales")?.Attribute("TotalTrasladosImpuestoIVA16") ?? "0"),
                            MontoTotalPagos = Convert.ToDecimal((string)pagosElement.Element(nsPago20 + "Totales")?.Attribute("MontoTotalPagos") ?? "0")
                        },
                        Pago = new List<Pago>()
                    };

                    // Procesar cada pago
                    foreach (var pagoElement in pagosElement.Elements(nsPago20 + "Pago"))
                    {
                        var nuevoPago = new Pago
                        {
                            FechaPago = DateTime.Parse((string)pagoElement.Attribute("FechaPago")),
                            MonedaP = (string)pagoElement.Attribute("MonedaP"),
                            TipoCambioP = Convert.ToDecimal((string)pagoElement.Attribute("TipoCambioP") ?? "0"),
                            FormaDePagoP = (string)pagoElement.Attribute("FormaDePagoP"),
                            Monto = Convert.ToDecimal((string)pagoElement.Attribute("Monto") ?? "0"),
                            DoctoRelacionado = new List<DoctoRelacionado>(),
                            ImpuestosP = new PagoImpuestosP
                            {
                                TrasladosP = new List<PagoTrasladoP>()
                            }
                        };

                        // Procesar documentos relacionados
                        foreach (var docto in pagoElement.Elements(nsPago20 + "DoctoRelacionado"))
                        {
                            nuevoPago.DoctoRelacionado.Add(new DoctoRelacionado
                            {
                                IdDocumento = (string)docto.Attribute("IdDocumento"),
                                Serie = (string)docto.Attribute("Serie"),
                                Folio = (string)docto.Attribute("Folio"),
                                MonedaDR = (string)docto.Attribute("MonedaDR"),
                                NumParcialidad = Convert.ToInt32((string)docto.Attribute("NumParcialidad") ?? "0"),
                                ImpSaldoAnt = Convert.ToDecimal((string)docto.Attribute("ImpSaldoAnt") ?? "0"),
                                ImpPagado = Convert.ToDecimal((string)docto.Attribute("ImpPagado") ?? "0"),
                                ImpSaldoInsoluto = Convert.ToDecimal((string)docto.Attribute("ImpSaldoInsoluto") ?? "0"),
                                ObjetoImpDR = (string)docto.Attribute("ObjetoImpDR")
                            });
                        }

                        comprobanteXML.Pagos.Pago.Add(nuevoPago);
                    }
                }

                return comprobanteXML;
            }
            catch (Exception ex)
            {
                App.logs.add($"Error al leer el archivo XML: {ex.Message}");
                return null;
            }
        }



        public bool ReadXMLPagos(DataXMLs dataXML)
        {
            try
            {
                string[] xmlFiles = Directory.GetFiles(dataXML.FileURL, "*.xml");
                List<JsonCLIDocumentos> documentosJsonList = new List<JsonCLIDocumentos>();

                foreach (string xmlFile in xmlFiles)
                {
                    App.logs.add($"Leyendo el archivo ------------------------------------------------------ [{xmlFile}]");
                    try
                    {
                        ComprobanteXML comprobante = ReadXMLs(xmlFile);
                        if (comprobante != null)
                        {
                            JsonCLIDocumentos documentoJson = estructurarJSON.CrearJSONPagos(comprobante, dataXML);
                            documentosJsonList.Add(documentoJson);
                        }
                    }
                    catch (Exception ex)
                    {
                        App.logs.add($"Error al leer el archivo {xmlFile} - {ex.Message}");
                    }
                }
                JsonOutput jsonCLI = estructurarJSON.EstructuraJsoFinally(documentosJsonList);
                string jsonComprobanteArray = JsonConvert.SerializeObject(jsonCLI, Formatting.Indented);
                string jsonFilePath = Path.Combine(dataXML.FileURL, "CLI.json");
                File.WriteAllText(jsonFilePath, jsonComprobanteArray);
                App.logs.add($"Archivo creado y Guardado : concepto {dataXML.ConceptoPremium} -{dataXML.TipoDocumentoXML} // {jsonFilePath}");
                return true;
            }
            catch (Exception ex)
            {
                App.logs.add($"Error al acceder al directorio: {ex.Message}");
                return false;
            }
        }


    }
}
