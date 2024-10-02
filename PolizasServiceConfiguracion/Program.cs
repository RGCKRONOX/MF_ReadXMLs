using ReadXMLPremium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadXMLPremium
{
    class ServiceConfig
    {
        // config SQL SERVER
        public string dbInstance { get; set; }
        public string dbDatabase { get; set; }
        public string dbUser { get; set; }
        public string dbPass { get; set; }
        public string endPointAPI { get; set; }
        public string logDir { get; set; }
        public string userSDK { get; set; }
        public string passSDK { get; set; }
        public string rutaEmpresa { get; set; }
        public string pssCSD { get; set; }
        public int syncEvery { get; set; }

    }

    static class Globales
    {

        public static Registro regManager;
        public static ServiceConfig serviceConfig;
        public static AppLogs logs;
        public static SQLSRV SQLSRVManager;
        public static FileManager fileManager;

        public static void getServiceConfig()
        {
            Globales.regManager = new Registro();
            Globales.serviceConfig = new ServiceConfig()
            {
                dbInstance = Globales.regManager.ObtenerValorDeClave("dbInstance"),
                dbDatabase = Globales.regManager.ObtenerValorDeClave("dbDatabase"),
                dbUser = Globales.regManager.ObtenerValorDeClave("dbUser"),
                dbPass = Globales.regManager.ObtenerValorDeClave("dbPass"),
                endPointAPI = Globales.regManager.ObtenerValorDeClave("endPointAPI"),
                syncEvery = Convert.ToInt32(Globales.regManager.ObtenerValorDeClave("syncEvery")),
                logDir = Globales.regManager.ObtenerValorDeClave("appDir"),
                userSDK = Globales.regManager.ObtenerValorDeClave("UserSDK"),
                passSDK = Globales.regManager.ObtenerValorDeClave("PassSDK"),
                rutaEmpresa = Globales.regManager.ObtenerValorDeClave("RutaEmpresa"),
                pssCSD = Globales.regManager.ObtenerValorDeClave("pssCSD"),
            };
            Globales.SQLSRVManager = new SQLSRV();
        }
    }



    static class Program
    {
        [STAThread]
        static void Main()
        {
            Globales.getServiceConfig();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
