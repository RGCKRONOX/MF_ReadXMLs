using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace ReadXMLPremium
{

    public class Registro
    {
        private string gNombreClave = "SOFTWARE\\KronoxYKairos\\WinServices\\ComercialPremium";
        private string regLocation;
        private RegistryKey regKey;

        public Registro(string regPath, string regLocation = "current_user")
        {
            this.gNombreClave = regPath;
            this.regLocation = regLocation;
            this.ConfigRegEdit();
        }

        //public Registro()
        //{
        //    this.regLocation = this.gNombreClave;
        //    this.ConfigRegEdit();
        //    if (VerificaSiExisteClave("dbInstance") == false)
        //    {
        //        this.GuardaListaLlaves(this.ListaClaves());
        //    }
        //}


        //private void ConfigRegEdit()
        //{
        //    RegistryKey rb = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
        //    var key = rb.OpenSubKey(this.gNombreClave, true);
        //    if (key == null)
        //    {
        //        this.regKey = Registry.LocalMachine.CreateSubKey(this.gNombreClave);
        //    }
        //    else
        //    {
        //        this.regKey = key;
        //    }
        //}

        private void ConfigRegEdit()
        {
            try
            {
                RegistryKey rb = null;
                if (this.regLocation == "current_user")
                    rb = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                else if (this.regLocation == "local_machine")
                    rb = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

                //RegistryKey rb = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                var key = rb.OpenSubKey(this.gNombreClave, true);
                if (key == null)
                {
                    if (this.regLocation == "current_user")
                        this.regKey = Registry.CurrentUser.CreateSubKey(this.gNombreClave);
                    else if (this.regLocation == "local_machine")
                        this.regKey = Registry.LocalMachine.CreateSubKey(this.gNombreClave);

                }
                else
                {
                    this.regKey = key;
                }
            }
            catch (Exception e)
            {
                //App.eventLogs.addErrorLog($"Error in ConfigRegEdit - {e.StackTrace}");
            }
        }

        public Dictionary<string, string> ListaClaves()
        {
            Dictionary<string, string> Llaves;
            Llaves = new Dictionary<string, string>();
            //  Configuración para comercial
            Llaves.Add("dbInstance", "");
            Llaves.Add("dbDatabase", "");
            Llaves.Add("dbUser", "");
            Llaves.Add("dbPass", "");
            Llaves.Add("sdkUser", "");
            Llaves.Add("sdkPass", "");
            Llaves.Add("syncEvery", "60000");
            return Llaves;
        }

        public void GuardaListaLlaves(Dictionary<string, string> pListaClaves)
        {
            try
            {
                foreach (var clave in pListaClaves)
                    this.regKey.SetValue(clave.Key, clave.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void guardaLlave(string llave, string valor)
        {
            try
            {
                this.regKey.SetValue(llave, valor);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void guardaLlave(string llave, string[] valor, RegistryValueKind type = RegistryValueKind.MultiString)
        {
            try
            {
                this.regKey.SetValue(llave, valor, type);
            }
            catch (Exception ex)
            {
                //App.eventLogs.addErrorLog(ex.StackTrace);
            }
        }

        public string ObtenerValorDeClave(string pClave)
        {
            try
            {
                return this.regKey.GetValue(pClave).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return String.Empty;
            }
        }

        public bool VerificaSiExisteClave(string pClave)
        {
            try
            {
                if (this.regKey.GetValue(pClave) == null)
                    return false;
                else
                    return true;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }

}
