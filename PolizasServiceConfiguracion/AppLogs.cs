using ReadXMLPremium;
using System;
using System.IO;

namespace ReadXMLPremium
{
    public class AppLogs
    {

        private string logsFilePath = $@"{Globales.serviceConfig.logDir}\API_LOGS.txt";

        public AppLogs()
        {
            this.creaArchivo();
        }

        private void creaArchivo()
        {
            try
            {
                if (!System.IO.File.Exists(this.logsFilePath))
                {
                    FileStream fs = System.IO.File.Create(this.logsFilePath);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void agregaLinea(string pLinea)
        {
            try
            {
                using (StreamWriter sw = System.IO.File.AppendText(this.logsFilePath))
                {
                    sw.WriteLine(pLinea);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void add(string pMensaje)
        {
            this.agregaLinea($"{DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") } - " + pMensaje);
        }

    }
}
