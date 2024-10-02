using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReadXMLPremium
{

    public class Registro
    {
        private string gNombreClave;
        private RegistryKey regKey; 

        public Registro()
        {
            this.ConfigRegEdit(@"SOFTWARE\KronoxYKairos\WinServices\ComercialPremium", "localMachine");
            if (VerificaSiExisteClave("dbInstance") == false)
            {
                this.GuardaListaLlaves(this.ListaClaves());
            }
        }


        private void ConfigRegEdit(string pNombreClave, string p_tipo_de_registro)
        {
            var key = Registry.LocalMachine.OpenSubKey(pNombreClave, true);
            if (key == null)
            {
               this.regKey = Registry.LocalMachine.CreateSubKey(pNombreClave);
            }
            else
            {
                this.regKey = key;
            }

            this.gNombreClave = pNombreClave;
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
            Llaves.Add("endPointAPI", "");
            Llaves.Add("logDir", "");
            Llaves.Add("UserSDK", "");
            Llaves.Add("PassSDK", "");
            Llaves.Add("RutaEmpresa", "");
            Llaves.Add("pssCSD", "");
            Llaves.Add("syncEvery", "60000");
            Llaves.Add("appDir", Directory.GetCurrentDirectory());
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
