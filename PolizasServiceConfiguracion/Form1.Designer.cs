
namespace ReadXMLPremium
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            btnIniciarServicio = new System.Windows.Forms.Button();
            btnGuardarConfig = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            btnReiniciarServicio = new System.Windows.Forms.Button();
            btnDetenerServicio = new System.Windows.Forms.Button();
            lblServiceStatus = new System.Windows.Forms.Label();
            tabPage1 = new System.Windows.Forms.TabPage();
            txtBoxDirLog = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtPassSql = new System.Windows.Forms.TextBox();
            lblPassword = new System.Windows.Forms.Label();
            txtUserSql = new System.Windows.Forms.TextBox();
            txtDB = new System.Windows.Forms.TextBox();
            txtInstancia = new System.Windows.Forms.TextBox();
            LblCorreo = new System.Windows.Forms.Label();
            SmtpPuerto = new System.Windows.Forms.Label();
            smtpServidor = new System.Windows.Forms.Label();
            tabConfigService = new System.Windows.Forms.TabPage();
            txtEndPointAPI = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            txtSegundos = new System.Windows.Forms.NumericUpDown();
            tabConfigSQL = new System.Windows.Forms.TabPage();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            btnDocumento = new System.Windows.Forms.Button();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPage2 = new System.Windows.Forms.TabPage();
            txtPassCSD = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txtRutaEmpresa = new System.Windows.Forms.TextBox();
            txtPassSDK = new System.Windows.Forms.TextBox();
            txtUserSDK = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabConfigService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtSegundos).BeginInit();
            tabConfigSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControlMain.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // btnIniciarServicio
            // 
            btnIniciarServicio.Location = new System.Drawing.Point(931, 13);
            btnIniciarServicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnIniciarServicio.Name = "btnIniciarServicio";
            btnIniciarServicio.Size = new System.Drawing.Size(117, 44);
            btnIniciarServicio.TabIndex = 0;
            btnIniciarServicio.Text = "Iniciar";
            btnIniciarServicio.UseVisualStyleBackColor = true;
            btnIniciarServicio.Click += btnIniciarServicio_Click;
            // 
            // btnGuardarConfig
            // 
            btnGuardarConfig.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnGuardarConfig.Location = new System.Drawing.Point(0, 497);
            btnGuardarConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnGuardarConfig.Name = "btnGuardarConfig";
            btnGuardarConfig.Size = new System.Drawing.Size(1060, 48);
            btnGuardarConfig.TabIndex = 8;
            btnGuardarConfig.Text = "Guardar ";
            btnGuardarConfig.UseVisualStyleBackColor = true;
            btnGuardarConfig.Click += btnGuardarConfig_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnReiniciarServicio);
            panel1.Controls.Add(btnDetenerServicio);
            panel1.Controls.Add(lblServiceStatus);
            panel1.Controls.Add(btnIniciarServicio);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1060, 67);
            panel1.TabIndex = 9;
            // 
            // btnReiniciarServicio
            // 
            btnReiniciarServicio.Location = new System.Drawing.Point(679, 13);
            btnReiniciarServicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnReiniciarServicio.Name = "btnReiniciarServicio";
            btnReiniciarServicio.Size = new System.Drawing.Size(120, 44);
            btnReiniciarServicio.TabIndex = 3;
            btnReiniciarServicio.Text = "Reiniciar";
            btnReiniciarServicio.UseVisualStyleBackColor = true;
            btnReiniciarServicio.Click += btnReiniciarServicio_Click;
            // 
            // btnDetenerServicio
            // 
            btnDetenerServicio.Location = new System.Drawing.Point(805, 13);
            btnDetenerServicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnDetenerServicio.Name = "btnDetenerServicio";
            btnDetenerServicio.Size = new System.Drawing.Size(120, 44);
            btnDetenerServicio.TabIndex = 2;
            btnDetenerServicio.Text = "Detener";
            btnDetenerServicio.UseVisualStyleBackColor = true;
            btnDetenerServicio.Click += btnDetenerServicio_Click;
            // 
            // lblServiceStatus
            // 
            lblServiceStatus.AutoSize = true;
            lblServiceStatus.Location = new System.Drawing.Point(26, 29);
            lblServiceStatus.Name = "lblServiceStatus";
            lblServiceStatus.Size = new System.Drawing.Size(202, 20);
            lblServiceStatus.TabIndex = 1;
            lblServiceStatus.Text = "Cargando estado del servicio";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtBoxDirLog);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtPassSql);
            tabPage1.Controls.Add(lblPassword);
            tabPage1.Controls.Add(txtUserSql);
            tabPage1.Controls.Add(txtDB);
            tabPage1.Controls.Add(txtInstancia);
            tabPage1.Controls.Add(LblCorreo);
            tabPage1.Controls.Add(SmtpPuerto);
            tabPage1.Controls.Add(smtpServidor);
            tabPage1.Location = new System.Drawing.Point(4, 29);
            tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabPage1.Size = new System.Drawing.Size(1052, 370);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "SQL Server";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtBoxDirLog
            // 
            txtBoxDirLog.HideSelection = false;
            txtBoxDirLog.Location = new System.Drawing.Point(204, 255);
            txtBoxDirLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtBoxDirLog.Name = "txtBoxDirLog";
            txtBoxDirLog.Size = new System.Drawing.Size(793, 27);
            txtBoxDirLog.TabIndex = 18;
            txtBoxDirLog.TextChanged += textBox1_TextChanged_2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(49, 258);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(40, 20);
            label2.TabIndex = 19;
            label2.Text = "Logs";
            // 
            // txtPassSql
            // 
            txtPassSql.HideSelection = false;
            txtPassSql.Location = new System.Drawing.Point(204, 208);
            txtPassSql.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtPassSql.Name = "txtPassSql";
            txtPassSql.Size = new System.Drawing.Size(793, 27);
            txtPassSql.TabIndex = 16;
            txtPassSql.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(49, 211);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(83, 20);
            lblPassword.TabIndex = 17;
            lblPassword.Text = "Contraseña";
            // 
            // txtUserSql
            // 
            txtUserSql.Location = new System.Drawing.Point(204, 157);
            txtUserSql.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtUserSql.Name = "txtUserSql";
            txtUserSql.Size = new System.Drawing.Size(793, 27);
            txtUserSql.TabIndex = 14;
            // 
            // txtDB
            // 
            txtDB.Location = new System.Drawing.Point(204, 100);
            txtDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtDB.Name = "txtDB";
            txtDB.Size = new System.Drawing.Size(793, 27);
            txtDB.TabIndex = 12;
            // 
            // txtInstancia
            // 
            txtInstancia.Location = new System.Drawing.Point(204, 49);
            txtInstancia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtInstancia.Name = "txtInstancia";
            txtInstancia.Size = new System.Drawing.Size(793, 27);
            txtInstancia.TabIndex = 10;
            txtInstancia.TextChanged += textBox1_TextChanged_1;
            // 
            // LblCorreo
            // 
            LblCorreo.AutoSize = true;
            LblCorreo.Location = new System.Drawing.Point(49, 157);
            LblCorreo.Name = "LblCorreo";
            LblCorreo.Size = new System.Drawing.Size(59, 20);
            LblCorreo.TabIndex = 15;
            LblCorreo.Text = "Usuario";
            // 
            // SmtpPuerto
            // 
            SmtpPuerto.AutoSize = true;
            SmtpPuerto.Location = new System.Drawing.Point(49, 100);
            SmtpPuerto.Name = "SmtpPuerto";
            SmtpPuerto.Size = new System.Drawing.Size(83, 20);
            SmtpPuerto.TabIndex = 13;
            SmtpPuerto.Text = "Base Datos";
            // 
            // smtpServidor
            // 
            smtpServidor.AutoSize = true;
            smtpServidor.Location = new System.Drawing.Point(49, 49);
            smtpServidor.Name = "smtpServidor";
            smtpServidor.Size = new System.Drawing.Size(67, 20);
            smtpServidor.TabIndex = 11;
            smtpServidor.Text = "Instancia";
            smtpServidor.Click += label6_Click;
            // 
            // tabConfigService
            // 
            tabConfigService.Controls.Add(txtEndPointAPI);
            tabConfigService.Controls.Add(label1);
            tabConfigService.Controls.Add(label7);
            tabConfigService.Controls.Add(txtSegundos);
            tabConfigService.Location = new System.Drawing.Point(4, 29);
            tabConfigService.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabConfigService.Name = "tabConfigService";
            tabConfigService.Size = new System.Drawing.Size(1052, 370);
            tabConfigService.TabIndex = 2;
            tabConfigService.Text = "Servicio";
            tabConfigService.UseVisualStyleBackColor = true;
            tabConfigService.Click += tabConfigService_Click;
            // 
            // txtEndPointAPI
            // 
            txtEndPointAPI.HideSelection = false;
            txtEndPointAPI.Location = new System.Drawing.Point(45, 154);
            txtEndPointAPI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtEndPointAPI.Name = "txtEndPointAPI";
            txtEndPointAPI.Size = new System.Drawing.Size(999, 27);
            txtEndPointAPI.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(45, 121);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(67, 20);
            label1.TabIndex = 19;
            label1.Text = "EndPoint";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(45, 47);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(195, 20);
            label7.TabIndex = 1;
            label7.Text = "Sincronizar cada (segundos)";
            // 
            // txtSegundos
            // 
            txtSegundos.Location = new System.Drawing.Point(45, 75);
            txtSegundos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSegundos.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            txtSegundos.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            txtSegundos.Name = "txtSegundos";
            txtSegundos.Size = new System.Drawing.Size(330, 27);
            txtSegundos.TabIndex = 0;
            txtSegundos.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // tabConfigSQL
            // 
            tabConfigSQL.Controls.Add(pictureBox1);
            tabConfigSQL.Controls.Add(dataGridView1);
            tabConfigSQL.Controls.Add(btnDocumento);
            tabConfigSQL.Location = new System.Drawing.Point(4, 29);
            tabConfigSQL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabConfigSQL.Name = "tabConfigSQL";
            tabConfigSQL.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabConfigSQL.Size = new System.Drawing.Size(1052, 370);
            tabConfigSQL.TabIndex = 0;
            tabConfigSQL.Text = "Configuración";
            tabConfigSQL.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(8, 322);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(33, 39);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.DoubleClick += pictureBox1_DoubleClick;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(8, 7);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new System.Drawing.Size(1036, 309);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // btnDocumento
            // 
            btnDocumento.Location = new System.Drawing.Point(761, 322);
            btnDocumento.Name = "btnDocumento";
            btnDocumento.Size = new System.Drawing.Size(283, 39);
            btnDocumento.TabIndex = 0;
            btnDocumento.Text = "Agregar Documento";
            btnDocumento.UseVisualStyleBackColor = true;
            btnDocumento.Click += btnDocumento_Click;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabConfigSQL);
            tabControlMain.Controls.Add(tabConfigService);
            tabControlMain.Controls.Add(tabPage1);
            tabControlMain.Controls.Add(tabPage2);
            tabControlMain.Location = new System.Drawing.Point(0, 91);
            tabControlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(1060, 403);
            tabControlMain.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtPassCSD);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(txtRutaEmpresa);
            tabPage2.Controls.Add(txtPassSDK);
            tabPage2.Controls.Add(txtUserSDK);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label5);
            tabPage2.Location = new System.Drawing.Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(1052, 370);
            tabPage2.TabIndex = 4;
            tabPage2.Text = "Configuracion API";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtPassCSD
            // 
            txtPassCSD.HideSelection = false;
            txtPassCSD.Location = new System.Drawing.Point(206, 199);
            txtPassCSD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtPassCSD.Name = "txtPassCSD";
            txtPassCSD.Size = new System.Drawing.Size(793, 27);
            txtPassCSD.TabIndex = 23;
            txtPassCSD.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(51, 199);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(115, 20);
            label6.TabIndex = 22;
            label6.Text = "Contraseña CSD";
            // 
            // txtRutaEmpresa
            // 
            txtRutaEmpresa.Location = new System.Drawing.Point(206, 138);
            txtRutaEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtRutaEmpresa.Name = "txtRutaEmpresa";
            txtRutaEmpresa.Size = new System.Drawing.Size(793, 27);
            txtRutaEmpresa.TabIndex = 20;
            // 
            // txtPassSDK
            // 
            txtPassSDK.Location = new System.Drawing.Point(206, 81);
            txtPassSDK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtPassSDK.Name = "txtPassSDK";
            txtPassSDK.Size = new System.Drawing.Size(793, 27);
            txtPassSDK.TabIndex = 18;
            // 
            // txtUserSDK
            // 
            txtUserSDK.Location = new System.Drawing.Point(206, 30);
            txtUserSDK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtUserSDK.Name = "txtUserSDK";
            txtUserSDK.Size = new System.Drawing.Size(793, 27);
            txtUserSDK.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(51, 138);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(96, 20);
            label3.TabIndex = 21;
            label3.Text = "RutaEmpresa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(51, 81);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(115, 20);
            label4.TabIndex = 19;
            label4.Text = "Contraseña SDK";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(51, 30);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(91, 20);
            label5.TabIndex = 17;
            label5.Text = "Usuario SDK";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1060, 545);
            Controls.Add(panel1);
            Controls.Add(btnGuardarConfig);
            Controls.Add(tabControlMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Lectura de XML - Premium";
            Load += frmMain_Load;
            Shown += frmMain_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabConfigService.ResumeLayout(false);
            tabConfigService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtSegundos).EndInit();
            tabConfigSQL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControlMain.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnIniciarServicio;
        private System.Windows.Forms.Button btnGuardarConfig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblServiceStatus;
        private System.Windows.Forms.Button btnDetenerServicio;
        private System.Windows.Forms.Button btnReiniciarServicio;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPassSql;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserSql;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.TextBox txtInstancia;
        private System.Windows.Forms.Label LblCorreo;
        private System.Windows.Forms.Label SmtpPuerto;
        private System.Windows.Forms.Label smtpServidor;
        private System.Windows.Forms.TabPage tabConfigService;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown txtSegundos;
        private System.Windows.Forms.TabPage tabConfigSQL;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TextBox txtEndPointAPI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDocumento;
        private System.Windows.Forms.TextBox txtBoxDirLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtRutaEmpresa;
        private System.Windows.Forms.TextBox txtPassSDK;
        private System.Windows.Forms.TextBox txtUserSDK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassCSD;
        private System.Windows.Forms.Label label6;
    }
}

