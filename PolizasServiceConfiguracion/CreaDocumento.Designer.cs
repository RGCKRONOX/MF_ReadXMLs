namespace ConfiguracionLecturaXML
{
    partial class CreaDocumento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreaDocumento));
            BtnGuardar = new System.Windows.Forms.Button();
            txtBoxUrlFIleXML = new System.Windows.Forms.TextBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            cboBoxPremium = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cboBoxTipoDoc = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            txtBoxAlias = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // BtnGuardar
            // 
            BtnGuardar.Location = new System.Drawing.Point(12, 256);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new System.Drawing.Size(911, 42);
            BtnGuardar.TabIndex = 0;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.UseVisualStyleBackColor = true;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // txtBoxUrlFIleXML
            // 
            txtBoxUrlFIleXML.Location = new System.Drawing.Point(213, 183);
            txtBoxUrlFIleXML.Name = "txtBoxUrlFIleXML";
            txtBoxUrlFIleXML.Size = new System.Drawing.Size(710, 27);
            txtBoxUrlFIleXML.TabIndex = 1;
            txtBoxUrlFIleXML.TextChanged += textBox1_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(745, 12);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(178, 24);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Timbrado Automatico";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 183);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(128, 20);
            label1.TabIndex = 3;
            label1.Text = "Direccion Carpeta";
            // 
            // cboBoxPremium
            // 
            cboBoxPremium.FormattingEnabled = true;
            cboBoxPremium.Location = new System.Drawing.Point(213, 55);
            cboBoxPremium.Name = "cboBoxPremium";
            cboBoxPremium.Size = new System.Drawing.Size(710, 28);
            cboBoxPremium.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(184, 20);
            label2.TabIndex = 5;
            label2.Text = "Tipo Documento Premium";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 126);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(154, 20);
            label3.TabIndex = 6;
            label3.Text = "Tipo Documento XML";
            // 
            // cboBoxTipoDoc
            // 
            cboBoxTipoDoc.FormattingEnabled = true;
            cboBoxTipoDoc.Location = new System.Drawing.Point(213, 118);
            cboBoxTipoDoc.Name = "cboBoxTipoDoc";
            cboBoxTipoDoc.Size = new System.Drawing.Size(710, 28);
            cboBoxTipoDoc.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 9);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(41, 20);
            label4.TabIndex = 9;
            label4.Text = "Alias";
            label4.Click += label4_Click;
            // 
            // txtBoxAlias
            // 
            txtBoxAlias.Location = new System.Drawing.Point(213, 9);
            txtBoxAlias.Name = "txtBoxAlias";
            txtBoxAlias.Size = new System.Drawing.Size(495, 27);
            txtBoxAlias.TabIndex = 8;
            // 
            // CreaDocumento
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(935, 310);
            Controls.Add(label4);
            Controls.Add(txtBoxAlias);
            Controls.Add(cboBoxTipoDoc);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cboBoxPremium);
            Controls.Add(label1);
            Controls.Add(checkBox1);
            Controls.Add(txtBoxUrlFIleXML);
            Controls.Add(BtnGuardar);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreaDocumento";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Configuracion Lectura";
            Load += CreaDocumento_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox txtBoxUrlFIleXML;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBoxPremium;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBoxTipoDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxAlias;
    }
}