using LecturaXMLPremium.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PolizasService.DTO
{
    public class JsonOutput
    {
        public string UserSDK { get; set; }
        public string PassSDK { get; set; }
        public string Instancia { get; set; }
        public string UserSQL { get; set; }
        public string PassSQL { get; set; }
        public string EmpresaDB { get; set; }
        public string RutaEmpresa { get; set; }
        public string PassCSD { get; set; }
        public List<JsonCLIDocumentos> Documentos { get; set; } // Cambiar el tipo de Documento según sea necesario
    }

   
}
