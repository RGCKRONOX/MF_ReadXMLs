using ReadXMLPremium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConfiguracionLecturaXML
{
    public partial class CreaDocumento : Form
    {
        public CreaDocumento()
        {
            InitializeComponent();
            getDocumentosPremium();
            getDocumentosApp();
        }

        private void CreaDocumento_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void getDocumentosPremium()
        {
            Globales.SQLSRVManager.Conecta();
            string getTable = $"SELECT CCODIGOCONCEPTO, CNOMBRECONCEPTO FROM admConceptos WHERE CIDDOCUMENTODE in (4, 7, 9, 13 ) AND CCODIGOCONCEPTO <> 39 AND CESTATUS = 1";
            List<string[]> resultadosDoc = Globales.SQLSRVManager.EjecutaQuery(getTable);

            cboBoxPremium.DisplayMember = "Value";
            cboBoxPremium.ValueMember = "Key";

            List<KeyValuePair<int, string>> items = new List<KeyValuePair<int, string>>();

            foreach (var resultado in resultadosDoc)
            {

                int idDocumento = int.Parse(resultado[0]);
                string nombreConcepto = resultado[1];

                items.Add(new KeyValuePair<int, string>(idDocumento, nombreConcepto));
            }
            cboBoxPremium.DataSource = items;
        }

        private void getDocumentosApp()
        {
            Globales.SQLSRVManager.Conecta();
            string getTable = $"SELECT Id, tipoDocumento FROM Documentos";
            List<string[]> resultadosDoc = Globales.SQLSRVManager.EjecutaQuery(getTable);

            cboBoxTipoDoc.DisplayMember = "Value";
            cboBoxTipoDoc.ValueMember = "Key";

            List<KeyValuePair<int, string>> items = new List<KeyValuePair<int, string>>();

            foreach (var resultado in resultadosDoc)
            {

                int idDocumento = int.Parse(resultado[0]);
                string nombreConcepto = resultado[1];

                items.Add(new KeyValuePair<int, string>(idDocumento, nombreConcepto));
            }
            cboBoxTipoDoc.DataSource = items;
        }


        private int ValidateData()
        {
            int bandera = 0;
            if (txtBoxAlias.Text.Length == 0)
            {
                // Asignar 'Sin Descripción' si está vacío
                txtBoxAlias.Text = "Sin Descripción";
            }

            if (txtBoxUrlFIleXML.Text.Length == 0)
            {
                MessageBox.Show("El campo 'Direccion Carpeta' no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = 1;
            }

            return bandera;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int Bandera = ValidateData();
            if (Bandera == 0)
            {
                int conceptoPremium = (int)cboBoxPremium.SelectedValue;  // ID del primer ComboBox
                int tipoDocumentoXML = (int)cboBoxTipoDoc.SelectedValue; // ID del segundo ComboBox


                try
                {
                    Globales.SQLSRVManager.Conecta();
                    string query = $"INSERT INTO ConfiguracionXML (Alias, ConceptoPremium, DireccionArchivo, TipoDocumentoXML, Bandera, Timbrado) " +
                                   $"VALUES ('{txtBoxAlias.Text}', {conceptoPremium}, '{txtBoxUrlFIleXML.Text}', {tipoDocumentoXML}, 0, {(checkBox1.Checked ? 1 : 0)})";

                    // Usar EjecutaSimpleQuery para la consulta de inserción
                    int filasAfectadas = Globales.SQLSRVManager.EjecutaSimpleQuery(query);

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Configuración guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar la configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la configuración: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
