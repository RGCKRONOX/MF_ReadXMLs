using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ReadXMLPremium
{
    class AppConfig
    {

        public string dbInstance { get; set; }
        public string dbDatabase { get; set; }
        public string dbUser { get; set; }
        public string dbPass { get; set; }
        
        public string dnsAPI { get; set; }

        public int syncEvery { get; set; }
        public string appDir { get; set; }
        public string logDir { get; set; }
        public string userSDK { get; set; }
        public string passSDK { get; set; }
        public string rutaEmpresa { get; set; }
        public string pssCSD { get; set; }

    }

    static class App
    {
        public static AppLogs logs;
        public static SQLSRV SQLSRVManager;
        public static FileManager fileManager;
        public static AppConfig config;
        public static VisorEventos visor;

        public static void getConfig()
        {
            try
            {
                App.visor = new VisorEventos();
                App.visor.verificaEventLogs();
                Registro reg = new Registro("SOFTWARE\\KronoxYKairos\\WinServices\\ComercialPremium", "local_machine");
                App.config = new AppConfig()
                {
                    dbInstance = reg.ObtenerValorDeClave("dbInstance"),
                    dbDatabase = reg.ObtenerValorDeClave("dbDatabase"),
                    dbUser = reg.ObtenerValorDeClave("dbUser"),
                    dbPass = reg.ObtenerValorDeClave("dbPass"),
                    dnsAPI = reg.ObtenerValorDeClave("endPointAPI"),
                    syncEvery = Convert.ToInt32(reg.ObtenerValorDeClave("syncEvery")),
                    appDir = reg.ObtenerValorDeClave("appDir"),
                    userSDK = reg.ObtenerValorDeClave("UserSDK"),
                    passSDK = reg.ObtenerValorDeClave("PassSDK"),
                    rutaEmpresa = reg.ObtenerValorDeClave("RutaEmpresa"),
                    pssCSD = reg.ObtenerValorDeClave("pssCSD"),
                };

                App.SQLSRVManager = new SQLSRV();
            }
            catch (Exception ex)
            {
                App.logs.add(ex.Message);
            }
        }

        public static void checkAppDirs()
        {
            string appDir = App.config.appDir;
            string logsDir = Path.Combine(appDir, "logs");

            if (!Directory.Exists(logsDir))
                Directory.CreateDirectory(logsDir);

            App.config.logDir = logsDir;
        }
    }

    static class Program
    {
        static void Main()
        {

            App.getConfig();
            App.checkAppDirs();
            App.logs = new AppLogs();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);

//#if DEBUG
//            //While debugging this section is used.
//            Service1 myService = new Service1();
//                        myService.onDebug();
//                        System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
//#else
//            ServiceBase[] ServicesToRun;
//            ServicesToRun = new ServiceBase[]
//            {
//                                                                                                                                                                                                                                       new Service1()
//            };
//            ServiceBase.Run(ServicesToRun);
//#endif
        }
    }
}
