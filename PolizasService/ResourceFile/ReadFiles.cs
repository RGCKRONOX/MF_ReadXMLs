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
                    App.logs.add($"Leyendo el archivo ------------------------------------------------------ [{xmlFile}]");
                    try
                    {
                        ComprobanteXML comprobante = ReadXMLs(xmlFile);
                        if (comprobante != null)
                        {
                            JsonCLIDocumentos documentoJson = estructurarJSON.CrearJSONDocumento(comprobante, dataXML);
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

        public ComprobanteXML ReadXMLs(string xmlFilePath)
        {
            try
            {
                XDocument xmlDocument = XDocument.Load(xmlFilePath);
                XNamespace nsCfdi = "http://www.sat.gob.mx/cfd/4";
                XNamespace nsPago20 = "http://www.sat.gob.mx/Pagos20";  // Namespace del complemento de pagos 2.0
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
                    SubTotal = Convert.ToDecimal((string)xmlDocument.Root.Attribute("SubTotal")),
                    Moneda = (string)xmlDocument.Root.Attribute("Moneda"),
                    TipoCambio = Convert.ToDecimal((string)xmlDocument.Root.Attribute("TipoCambio")),
                    Total = Convert.ToDecimal((string)xmlDocument.Root.Attribute("Total")),
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
                    Impuestos = new Impuestos
                    {
                        TotalImpuestosTrasladados = Convert.ToDecimal((string)xmlDocument.Root.Element(nsCfdi + "Impuestos")?.Attribute("TotalImpuestosTrasladados")),
                        Traslados = new List<Traslado>()
                    },
                    Addenda = new Addenda
                    {
                        FELE = new FELE
                        {
                            OCRelac = (string)xmlDocument.Root.Element(nsCfdi + "Addenda")?.Element("FELE")?.Element("noOrdenCompra"),
                            NbrOrden = (string)xmlDocument.Root.Element(nsCfdi + "Addenda")?.Element("FELE")?.Element("noOrdenVenta"),
                            Deposito = (string)xmlDocument.Root.Element(nsCfdi + "Addenda")?.Element("FELE")?.Element("Comentarios"),
                        }
                    }
                };

                // Agregar conceptos
                var conceptosElement = xmlDocument.Root.Element(nsCfdi + "Conceptos");
                if (conceptosElement != null)
                {
                    foreach (var concepto in conceptosElement.Elements(nsCfdi + "Concepto"))
                    {
                        comprobanteXML.Conceptos.Add(new Concepto
                        {
                            Cantidad = Convert.ToDecimal((string)concepto.Attribute("Cantidad")),
                            ClaveProdServ = (string)concepto.Attribute("ClaveProdServ"),
                            ClaveUnidad = (string)concepto.Attribute("ClaveUnidad"),
                            Unidad = (string)concepto.Attribute("Unidad"),
                            Descripcion = (string)concepto.Attribute("Descripcion"),
                            Importe = Convert.ToDecimal((string)concepto.Attribute("Importe")),
                            NoIdentificacion = (string)concepto.Attribute("NoIdentificacion"),
                            ValorUnitario = Convert.ToDecimal((string)concepto.Attribute("ValorUnitario")),
                            ObjetoImp = (string)concepto.Attribute("ObjetoImp"),
                            Impuestos = new Impuestos
                            {
                                Traslados = new List<Traslado>()
                            }
                        });

                        // Agregar traslados si existen
                        var impuestosElement = concepto.Element(nsCfdi + "Impuestos");
                        if (impuestosElement != null)
                        {
                            var trasladosElement = impuestosElement.Element(nsCfdi + "Traslados");
                            if (trasladosElement != null)
                            {
                                foreach (var traslado in trasladosElement.Elements(nsCfdi + "Traslado"))
                                {
                                    comprobanteXML.Conceptos[comprobanteXML.Conceptos.Count - 1].Impuestos.Traslados.Add(new Traslado
                                    {
                                        Base = Convert.ToDecimal((string)traslado.Attribute("Base")),
                                        Importe = Convert.ToDecimal((string)traslado.Attribute("Importe")),
                                        Impuesto = (string)traslado.Attribute("Impuesto"),
                                        TasaOCuota = Convert.ToDecimal((string)traslado.Attribute("TasaOCuota")),
                                        TipoFactor = (string)traslado.Attribute("TipoFactor")
                                    });
                                }
                            }
                        }
                    }
                }

                // Agregar relación de CFDI
                var cfdiRelacionados = xmlDocument.Root.Element(nsCfdi + "CfdiRelacionados");
                if (cfdiRelacionados != null)
                {
                    foreach (var relacionado in cfdiRelacionados.Elements(nsCfdi + "CfdiRelacionado"))
                    {
                        comprobanteXML.CfdiRelacionados.CfdiRelacionadosList.Add(new CfdiRelacionado
                        {
                            UUID = (string)relacionado.Attribute("UUID")
                        });
                    }
                }

                // Obtener el nodo Complemento
                var complementoElement = xmlDocument.Root.Element(nsCfdi + "Complemento");
                if (complementoElement != null)
                {
                    // Obtener el nodo Pagos dentro del Complemento
                    var pagosElement = complementoElement.Element(nsPago20 + "Pagos");
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

                        // Procesar cada elemento de Pago
                        foreach (var pagoElement in pagosElement.Elements(nsPago20 + "Pago"))
                        {
                            Pago pago = new Pago
                            {
                                FechaPago = DateTime.Parse((string)pagoElement.Attribute("FechaPago")),
                                MonedaP = (string)pagoElement.Attribute("MonedaP"),
                                TipoCambioP = Convert.ToDecimal((string)pagoElement.Attribute("TipoCambioP")),
                                FormaDePagoP = (string)pagoElement.Attribute("FormaDePagoP"),
                                Monto = Convert.ToDecimal((string)pagoElement.Attribute("Monto")),
                                DoctoRelacionado = new List<DoctoRelacionado>(),
                                ImpuestosP = new PagoImpuestosP
                                {
                                    TrasladosP = new List<PagoTrasladoP>() // Asegúrate de que esta clase esté definida
                                }
                            };

                            // Agregar documentos relacionados
                            var doctosRelacionadosElement = pagoElement.Elements(nsPago20 + "DoctoRelacionado");
                            foreach (var docto in doctosRelacionadosElement)
                            {
                                DoctoRelacionado doctoRelacionado = new DoctoRelacionado
                                {
                                    IdDocumento = (string)docto.Attribute("IdDocumento"),
                                    Serie = (string)docto.Attribute("Serie"),
                                    Folio = (string)docto.Attribute("Folio"),
                                    MonedaDR = (string)docto.Attribute("MonedaDR"),
                                    NumParcialidad = Convert.ToInt32((string)docto.Attribute("NumParcialidad") ?? "0"),
                                    ImpSaldoAnt = Convert.ToDecimal((string)docto.Attribute("ImpSaldoAnt") ?? "0"),
                                    ImpPagado = Convert.ToDecimal((string)docto.Attribute("ImpPagado") ?? "0"),
                                    ImpSaldoInsoluto = Convert.ToDecimal((string)docto.Attribute("ImpSaldoInsoluto") ?? "0"),
                                    ObjetoImpDR = (string)docto.Attribute("ObjetoImpDR") // Incluido para el nodo "ObjetoImpDR"
                                };
                                pago.DoctoRelacionado.Add(doctoRelacionado);
                            }

                            // Agregar impuestos del pago
                            var impuestosPElement = pagoElement.Element(nsPago20 + "ImpuestosP");
                            if (impuestosPElement != null)
                            {
                                var trasladosPElement = impuestosPElement.Element(nsPago20 + "TrasladosP");
                                if (trasladosPElement != null)
                                {
                                    foreach (var trasladoP in trasladosPElement.Elements(nsPago20 + "TrasladoP"))
                                    {
                                        PagoTrasladoP traslado = new PagoTrasladoP
                                        {
                                            BaseP = Convert.ToDecimal((string)trasladoP.Attribute("BaseP") ?? "0"),
                                            ImpuestoP = (string)trasladoP.Attribute("ImpuestoP"),
                                            TipoFactorP = (string)trasladoP.Attribute("TipoFactorP"),
                                            TasaOCuotaP = Convert.ToDecimal((string)trasladoP.Attribute("TasaOCuotaP") ?? "0"),
                                            ImporteP = Convert.ToDecimal((string)trasladoP.Attribute("ImporteP") ?? "0")
                                        };
                                        pago.ImpuestosP.TrasladosP.Add(traslado);
                                    }
                                }
                            }

                            // Agregar el pago al listado
                            comprobanteXML.Pagos.Pago.Add(pago);
                        }
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
