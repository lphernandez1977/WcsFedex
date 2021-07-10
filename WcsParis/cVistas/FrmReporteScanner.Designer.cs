namespace WcsFedex
{
    partial class FrmReporteScanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteScanner));
            this.label2 = new System.Windows.Forms.Label();
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.Fecha1 = new System.Windows.Forms.DateTimePicker();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Fecha2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DgvDatosDia = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.LblTotalCartones = new System.Windows.Forms.Label();
            this.Fecha3 = new System.Windows.Forms.DateTimePicker();
            this.BtnSelec = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatosDia)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(405, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 33);
            this.label2.TabIndex = 38;
            this.label2.Text = "REPORTE ESORTER FEDEX";
            // 
            // DgvDatos
            // 
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.Location = new System.Drawing.Point(50, 396);
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.RowTemplate.Height = 24;
            this.DgvDatos.Size = new System.Drawing.Size(1106, 398);
            this.DgvDatos.TabIndex = 39;
            this.DgvDatos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDatos_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(50, 360);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 33);
            this.label1.TabIndex = 40;
            this.label1.Text = "Fecha Inicio";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.Navy;
            this.BtnGuardar.Image = global::WcsFedex.Properties.Resources.excel;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(879, 803);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(135, 36);
            this.BtnGuardar.TabIndex = 3;
            this.BtnGuardar.Text = "Exportar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Navy;
            this.BtnSalir.Image = global::WcsFedex.Properties.Resources.salir;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(1018, 803);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 36);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // Fecha1
            // 
            this.Fecha1.CalendarFont = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha1.CalendarForeColor = System.Drawing.Color.Navy;
            this.Fecha1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha1.Location = new System.Drawing.Point(250, 363);
            this.Fecha1.Name = "Fecha1";
            this.Fecha1.Size = new System.Drawing.Size(148, 27);
            this.Fecha1.TabIndex = 0;
            this.Fecha1.Value = new System.DateTime(2019, 7, 7, 0, 0, 0, 0);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.Navy;
            this.BtnBuscar.Image = global::WcsFedex.Properties.Resources.buscar;
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.Location = new System.Drawing.Point(1023, 358);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(132, 36);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(456, 360);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 33);
            this.label3.TabIndex = 46;
            this.label3.Text = "Fecha Fin";
            // 
            // Fecha2
            // 
            this.Fecha2.CalendarFont = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha2.CalendarForeColor = System.Drawing.Color.Navy;
            this.Fecha2.CalendarTitleForeColor = System.Drawing.Color.Navy;
            this.Fecha2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha2.Location = new System.Drawing.Point(613, 363);
            this.Fecha2.Name = "Fecha2";
            this.Fecha2.Size = new System.Drawing.Size(148, 27);
            this.Fecha2.TabIndex = 1;
            this.Fecha2.Value = new System.DateTime(2019, 7, 7, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(50, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(348, 33);
            this.label4.TabIndex = 47;
            this.label4.Text = "Resumen Proceso Diario";
            // 
            // DgvDatosDia
            // 
            this.DgvDatosDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatosDia.Location = new System.Drawing.Point(50, 110);
            this.DgvDatosDia.Name = "DgvDatosDia";
            this.DgvDatosDia.RowTemplate.Height = 24;
            this.DgvDatosDia.Size = new System.Drawing.Size(348, 236);
            this.DgvDatosDia.TabIndex = 48;
            this.DgvDatosDia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDatosDia_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(456, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(298, 33);
            this.label5.TabIndex = 49;
            this.label5.Text = "Total Cartones Diario";
            // 
            // LblTotalCartones
            // 
            this.LblTotalCartones.AutoSize = true;
            this.LblTotalCartones.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalCartones.ForeColor = System.Drawing.Color.Navy;
            this.LblTotalCartones.Location = new System.Drawing.Point(798, 74);
            this.LblTotalCartones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTotalCartones.Name = "LblTotalCartones";
            this.LblTotalCartones.Size = new System.Drawing.Size(31, 33);
            this.LblTotalCartones.TabIndex = 50;
            this.LblTotalCartones.Text = "0";
            // 
            // Fecha3
            // 
            this.Fecha3.CalendarFont = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha3.CalendarForeColor = System.Drawing.Color.Navy;
            this.Fecha3.CalendarTitleForeColor = System.Drawing.Color.Navy;
            this.Fecha3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha3.Location = new System.Drawing.Point(456, 236);
            this.Fecha3.Name = "Fecha3";
            this.Fecha3.Size = new System.Drawing.Size(148, 27);
            this.Fecha3.TabIndex = 51;
            this.Fecha3.Value = new System.DateTime(2019, 7, 7, 0, 0, 0, 0);
            // 
            // BtnSelec
            // 
            this.BtnSelec.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelec.ForeColor = System.Drawing.Color.Navy;
            this.BtnSelec.Image = global::WcsFedex.Properties.Resources.buscar;
            this.BtnSelec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSelec.Location = new System.Drawing.Point(697, 236);
            this.BtnSelec.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSelec.Name = "BtnSelec";
            this.BtnSelec.Size = new System.Drawing.Size(132, 36);
            this.BtnSelec.TabIndex = 52;
            this.BtnSelec.Text = "Buscar";
            this.BtnSelec.UseVisualStyleBackColor = true;
            this.BtnSelec.Click += new System.EventHandler(this.BtnSelec_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(456, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(265, 33);
            this.label6.TabIndex = 53;
            this.label6.Text = "Seleccionar Fecha";
            // 
            // FrmReporteScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 845);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnSelec);
            this.Controls.Add(this.Fecha3);
            this.Controls.Add(this.LblTotalCartones);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DgvDatosDia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Fecha2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.Fecha1);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvDatos);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReporteScanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-MAC Ingeniería Eléctrica y Mantenimiento Industrial";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmReporteScanner_FormClosed);
            this.Load += new System.EventHandler(this.FrmReporteScanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatosDia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvDatos;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DateTimePicker Fecha1;
        internal System.Windows.Forms.Button BtnBuscar;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Fecha2;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DgvDatosDia;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label LblTotalCartones;
        private System.Windows.Forms.DateTimePicker Fecha3;
        internal System.Windows.Forms.Button BtnSelec;
        internal System.Windows.Forms.Label label6;
    }
}