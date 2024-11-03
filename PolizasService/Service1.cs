using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.ServiceProcess;
using System.Timers;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading.Tasks;
using PolizasService.ResourceDB;
using PolizasService.ResourceFile;
using PolizasService.DTO;
using System.IO;
using LecturaXMLPremium.ResourceFile;

namespace ReadXMLPremium
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();     
        GetDataBaseConfiguracionXML xmlData = new GetDataBaseConfiguracionXML();
        ReadFiles readFiles = new ReadFiles();  
        Helpers helpers = new Helpers();
        ConsumirAPI consumirAPI = new ConsumirAPI();
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStop()
        {
        }

        public void onDebug()
        {
            OnStart(null);
        }

        private async Task ServiceReadXML()
        {
            try
            {
                App.logs.add($"*********INICIA SERVICIO**********");
                List<string[]> resultadosDoc = xmlData.getConfigTipoDocumentos(); 
                if (resultadosDoc != null && resultadosDoc.Count > 0)
                {
                    foreach (var fila in resultadosDoc)
                    {
                        if (fila.Length >= 3) 
                        {
                            string conceptoPremium = fila[0];  
                            string tipoDocumentoXML = fila[1];  
                            string timbrado = fila[2];          
                            string FileURL = fila[3]; 

                            DataXMLs documentoXML = new DataXMLs
                            {
                                ConceptoPremium = conceptoPremium,
                                TipoDocumentoXML = tipoDocumentoXML,
                                Timbrado = timbrado,
                                FileURL = FileURL
                            };

                            switch (tipoDocumentoXML)
                            {
                                case "1": // Factura
                                
                                    helpers.createFile(documentoXML.FileURL); //Reviso que existan las carpetas de Procesado y Errores
                                    int CountXMLDir = helpers.readDirXML(documentoXML.FileURL);
                                    if (CountXMLDir > 0)
                                    {
                                        helpers.deleteFile(FileURL, "CLI.json"); //Elimino archivos JSON.
                                        bool resFile = readFiles.ReadXML(documentoXML); //Logica de lectura
                                        Task<ApiResponse> resultTask = resFile ? consumirAPI.PreparaConsumoAPIAsync(FileURL, "CLI", App.config.dnsAPI) : null;
                                        if (resultTask != null)
                                        {
                                            ApiResponse result = await resultTask;
                                            if (result.Success && result.Data != null && result.Data.Count > 0)
                                            {
                                                App.logs.add($"Api consumida correctamente----------");
                                                helpers.FileMoved(result, FileURL); //Muevo los archivos
                                            }
                                            else
                                            {
                                                string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
                                                App.logs.add($"No pudo ingresar los documentos correctamente, revisa JSON: {jsonResult}");
                                            }
                                        }
                                    }
                                    break;
                                case "2": // Nota de Cargo
                                case "3": // Nota de Crédito
                                    helpers.createFile(documentoXML.FileURL); //Reviso que existan las carpetas de Procesado y Errores
                                    int CountXMLDirNC = helpers.readDirXML(documentoXML.FileURL);
                                    if (CountXMLDirNC > 0)
                                    {
                                        helpers.deleteFile(FileURL, "CLI.json"); //Elimino archivos JSON.
                                        bool resFile = readFiles.ReadXML(documentoXML); //Logica de lectura
                                        Task<ApiResponse> resultTask = resFile ? consumirAPI.PreparaConsumoAPIAsync(FileURL, "CLI", $"{App.config.dnsAPI}/NC") : null;
                                        if (resultTask != null)
                                        {
                                            ApiResponse result = await resultTask;
                                            if (result.Success && result.Data != null && result.Data.Count > 0)
                                            {
                                                helpers.FileMoved(result, FileURL); //Muevo los archivos
                                            }
                                            else
                                            {
                                                string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
                                                App.logs.add($"No pudo ingresar los documentos correctamente, revisa JSON: {jsonResult}");
                                            }
                                        }
                                    }
                                    break;
                                case "4": // Complemento de pago
                                    helpers.createFile(documentoXML.FileURL); //Reviso que existan las carpetas de Procesado y Errores
                                    int CountXMLDirPay = helpers.readDirXML(documentoXML.FileURL);
                                    if (CountXMLDirPay > 0)
                                    {
                                        helpers.deleteFile(FileURL, "CLI.json"); //Elimino archivos JSON.
                                        bool resFile = readFiles.ReadXMLPagos(documentoXML); //Logica de lectura
                                        Task<ApiResponse> resultTask = resFile ? consumirAPI.PreparaConsumoAPIAsync(FileURL, "CLI", $"{App.config.dnsAPI}/Pago") : null;
                                        if (resultTask != null)
                                        {
                                            ApiResponse result = await resultTask;
                                            if (result.Success && result.Data != null && result.Data.Count > 0)
                                            {
                                                helpers.FileMoved(result, FileURL); //Muevo los archivos
                                            }
                                            else
                                            {
                                                string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
                                                App.logs.add($"No pudo ingresar los documentos correctamente, revisa JSON: {jsonResult}");
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    App.logs.add($"Tipo desconocido: {tipoDocumentoXML}");
                                    break;
                            }
                        }
                        else
                        {
                            App.logs.add("Error: La fila no contiene suficientes elementos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.logs.add(ex.Message);
            }
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            this.ServiceReadXML();
        }

        protected override void OnStart(string[] args)
        {
            App.logs.add($"Servicio inicializado");
            ServiceReadXML();

            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = App.config.syncEvery; //number in milisecinds  
            timer.Enabled = true;
        }
       
    }
}
