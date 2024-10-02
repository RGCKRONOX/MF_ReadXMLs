using ConfiguracionLecturaXML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ReadXMLPremium
{
    public partial class frmMain : Form
    {
        public string serviceName = "LecturaXMLPremium";
        public ServiceController service = null;
        public Dictionary<string, string> statusMapped = new Dictionary<string, string>() {
            { "Stopped", "Detenido" },
            { "Running", "Corriendo" }
        };

        public frmMain()
        {
            InitializeComponent();
            getTableConceptos();
        }

        private void buscaServicio()
        {
            foreach (ServiceController scTemp in ServiceController.GetServices())
            {
                if (scTemp.ServiceName == this.serviceName)
                {
                    this.service = scTemp;
                    lblServiceStatus.Text = "Estado del servicio: " + statusMapped[service.Status.ToString()];
                }
            }
        }

        public void getService()
        {
            this.buscaServicio();

            if (this.service == null)
            {
                this.createService();
                this.buscaServicio();
                MessageBox.Show("Servicio creado");
            }
        }

        public void createService()
        {
            //MessageBox.Show("ENTRO A CREACION");
            string serviceBinPath = Path.Combine(Directory.GetCurrentDirectory(), "svc", $"{this.serviceName}.exe");
            //string serviceBinPath = @"V:\KronoxDev\Desarrollo\VisualStudio\Conectores\PolizasService\PolizasService\bin\Debug\PolizasService.exe";
            string strCmdText = $"/C sc create \"{this.serviceName}\" binpath=\"{serviceBinPath}\" DisplayName=\"{this.serviceName}\" ";
            Process p = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            p.WaitForExit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            if (this.service == null)
            {
                lblServiceStatus.Text = "Servicio no encontrado";
            }
            else
            {
                lblServiceStatus.Text = "Estado del servicio: " + statusMapped[service.Status.ToString()];
            }
            txtInstancia.Text = Globales.serviceConfig.dbInstance;
            txtDB.Text = Globales.serviceConfig.dbDatabase;
            txtUserSql.Text = Globales.serviceConfig.dbUser;
            txtPassSql.Text = Globales.serviceConfig.dbPass;
            txtEndPointAPI.Text = Globales.serviceConfig.endPointAPI;
            txtSegundos.Value = Globales.serviceConfig.syncEvery / 1000;
            txtBoxDirLog.Text = Globales.serviceConfig.logDir;
            txtUserSDK.Text = Globales.serviceConfig.userSDK;
            txtPassSDK.Text = Globales.serviceConfig.passSDK;
            txtRutaEmpresa.Text = Globales.serviceConfig.rutaEmpresa;
            txtPassCSD.Text = Globales.serviceConfig.pssCSD;

        }

        public Dictionary<string, string> ListaClaves()
        {
            Dictionary<string, string> Llaves;
            Llaves = new Dictionary<string, string>();
            Llaves.Add("dbInstance", txtInstancia.Text);
            Llaves.Add("dbDatabase", txtDB.Text);
            Llaves.Add("dbUser", txtUserSql.Text);
            Llaves.Add("dbPass", txtPassSql.Text);
            Llaves.Add("endPointAPI", txtEndPointAPI.Text);
            Llaves.Add("appDir", txtBoxDirLog.Text);
            Llaves.Add("UserSDK", txtUserSDK.Text);
            Llaves.Add("PassSDK", txtPassSDK.Text);
            Llaves.Add("RutaEmpresa", txtRutaEmpresa.Text);
            Llaves.Add("pssCSD", txtPassCSD.Text);
            Llaves.Add("syncEvery", (txtSegundos.Value * 1000).ToString());
            return Llaves;
        }

        private void btnGuardarConfig_Click(object sender, EventArgs e)
        {
            Globales.regManager.GuardaListaLlaves(this.ListaClaves());
            MessageBox.Show("Configuración guardada", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void getServiceResources()
        {

        }

        public void iniciarServicio()
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(15000);
            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }

        public void detenerServicio()
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(15000);
            service.Stop();
            service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
        }

        private void btnIniciarServicio_Click(object sender, EventArgs e)
        {
            lblServiceStatus.Text = "Cargando estado del servicio";
            if (this.service == null)
            {
                MessageBox.Show("No se ha encontrado el servicio de Envio de Email", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //MessageBox.Show("Servicio creado");
                    this.iniciarServicio();
                    lblServiceStatus.Text = "Estado del servicio: " + statusMapped[service.Status.ToString()];
                }
                catch (Exception ex)
                {
                    lblServiceStatus.Text = "Estado del servicio: " + statusMapped[service.Status.ToString()];
                    MessageBox.Show(ex.Message, "Error al iniciar el servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDetenerServicio_Click(object sender, EventArgs e)
        {
            lblServiceStatus.Text = "Cargando estado del servicio";
            if (this.service == null)
            {
                MessageBox.Show("No se ha encontrado el servicio de polizas", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    this.detenerServicio();
                    lblServiceStatus.Text = "Estado del servicio: " + statusMapped[service.Status.ToString()];
                }
                catch (Exception ex)
                {
                    lblServiceStatus.Text = "Estado del servicio: " + statusMapped[service.Status.ToString()];
                    MessageBox.Show(ex.Message, "Error detener el servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnReiniciarServicio_Click(object sender, EventArgs e)
        {
            lblServiceStatus.Text = "Reiniciando el servicio";
            if (this.service == null)
            {
                MessageBox.Show("No se ha encontrado el servicio de polizas", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (service.Status != ServiceControllerStatus.Stopped)
                    {
                        this.detenerServicio();
                        this.iniciarServicio();
                    }
                    lblServiceStatus.Text = "Estado del servicio: " + statusMapped[service.Status.ToString()];
                }
                catch (Exception ex)
                {
                    lblServiceStatus.Text = "Estado del servicio: " + statusMapped[service.Status.ToString()];
                    MessageBox.Show(ex.Message, "Error detener el servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.getService();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void tabConfigService_Click(object sender, EventArgs e)
        {

        }

        private void btnDocumento_Click(object sender, EventArgs e)
        {

            CreaDocumento creaDocumento = new CreaDocumento();

            // Muestra el formulario como modal (bloquea el formulario actual hasta que se cierre)
            creaDocumento.ShowDialog();
        }

        private void AjustarColumnas()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; // Ajusta al tamaño del contenido
            }
        }

        public void getTableConceptos()
        {
            Globales.SQLSRVManager.Conecta();
            string getTable = "SELECT XMLConf.Id, Alias, Cpto.CNOMBRECONCEPTO as ConceptoPremium, docApp.tipoDocumento as TipoDocumentoXML, IIF (Timbrado = 1 , 'Automatico', 'Manual') as Timbrado, DireccionArchivo   FROM ConfiguracionXML XMLConf LEFT JOIN admConceptos Cpto ON XMLConf.ConceptoPremium = Cpto.CCODIGOCONCEPTO LEFT JOIN Documentos docApp ON docApp.Id = XMLConf.TipoDocumentoXML WHERE XMLConf. Bandera = 0 ORDER BY XMLConf.TipoDocumentoXML ";
            List<string[]> resultadosDoc = Globales.SQLSRVManager.EjecutaQuery(getTable);

            dataGridView1.Rows.Clear();
            dataGridView1.RowHeadersVisible = false;

            // Solo agregar columnas si no existen
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("id", "ID"); // Asegúrate de agregar la columna para ID si la necesitas
                dataGridView1.Columns["id"].Visible = false; // Ocultar la columna del ID
                dataGridView1.Columns.Add("Alias", "Alias");
                dataGridView1.Columns.Add("ConceptoPremium", "Concepto Premium");
                dataGridView1.Columns.Add("TipoDocumentoXML", "Tipo de Documento XML");
                dataGridView1.Columns.Add("Timbrado", "Timbrado Automático");
                dataGridView1.Columns.Add("DireccionArchivo", "Dirección del Archivo");
            }

            // Recorrer los resultados obtenidos y agregarlos al DataGridView
            foreach (string[] fila in resultadosDoc)
            {
                // Asegúrate de que la fila tenga el mismo número de elementos que columnas
                if (fila.Length == dataGridView1.Columns.Count)
                {
                    dataGridView1.Rows.Add(fila);
                }
                else
                {
                    // Manejo de error: número de columnas no coincide
                    Console.WriteLine("Error: La fila no coincide con el número de columnas.");
                }
            }
            AjustarColumnas(); // Llama al método para ajustar columnas
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }


        private void EliminarElemento(int id)
        {
            Globales.SQLSRVManager.Conecta();
            string query = $"UPDATE ConfiguracionXML SET Bandera = 1 WHERE Id = {id}";
            // Usar EjecutaSimpleQuery para la consulta de inserción
            int filasAfectadas = Globales.SQLSRVManager.EjecutaSimpleQuery(query);
            MessageBox.Show("Configuracion Eliminada");
            getTableConceptos();
        }

        // Variable para almacenar el ID seleccionado
        private int? idSeleccionado = null;

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado.HasValue)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este elemento?", // Mensaje
                    "Confirmación", // Título del cuadro de diálogo
                    MessageBoxButtons.YesNo, // Botones que se mostrarán
                    MessageBoxIcon.Question // Icono que se mostrará
                );

                if (resultado == DialogResult.Yes)
                {
                    EliminarElemento(idSeleccionado.Value); // Llama a la función para eliminar el elemento
                    idSeleccionado = null; // Reinicia la selección
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento para eliminar.");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                BtnEliminar_Click(this, null);
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            getTableConceptos();
        }
    }
}
