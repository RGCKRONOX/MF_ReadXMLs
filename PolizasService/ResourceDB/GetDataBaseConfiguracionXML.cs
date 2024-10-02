using ReadXMLPremium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizasService.ResourceDB
{
    public class GetDataBaseConfiguracionXML
    {
        public List<string[]> getConfigTipoDocumentos()
        {
            try
            {
                App.SQLSRVManager.Conecta();
                string getTable = $"SELECT ConceptoPremium, TipoDocumentoXML, Timbrado, DireccionArchivo FROM ConfiguracionXML WHERE Bandera = 0";
                List<string[]> resultadosDoc = App.SQLSRVManager.EjecutaQuery(getTable);
                return resultadosDoc;
            }
            catch (Exception ex)
            {
                App.logs.add(ex.Message);
                return new List<string[]>(); 
            }
        }
    }
}
