namespace WcsFedex
{
    partial class FrmJornadaDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJornadaDetalle));
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.BtnExe = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvDatos
            // 
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.Location = new System.Drawing.Point(12, 12);
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.RowTemplate.Height = 24;
            this.DgvDatos.Size = new System.Drawing.Size(498, 478);
            this.DgvDatos.TabIndex = 0;
            // 
            // BtnExe
            // 
            this.BtnExe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExe.ForeColor = System.Drawing.Color.Navy;
            this.BtnExe.Image = global::WcsFedex.Properties.Resources.config;
            this.BtnExe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExe.Location = new System.Drawing.Point(374, 503);
            this.BtnExe.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExe.Name = "BtnExe";
            this.BtnExe.Size = new System.Drawing.Size(135, 36);
            this.BtnExe.TabIndex = 39;
            this.BtnExe.Text = "Ejecutar";
            this.BtnExe.UseVisualStyleBackColor = true;
            this.BtnExe.Click += new System.EventHandler(this.BtnExe_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Navy;
            this.Label4.Location = new System.Drawing.Point(13, 512);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(177, 19);
            this.Label4.TabIndex = 40;
            this.Label4.Text = "Poner En Producción";
            // 
            // FrmJornadaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 552);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.BtnExe);
            this.Controls.Add(this.DgvDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmJornadaDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-MAC Ingeniería Eléctrica y Mantenimiento Industrial";
            this.Load += new System.EventHandler(this.FrmJornadaDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvDatos;
        internal System.Windows.Forms.Button BtnExe;
        internal System.Windows.Forms.Label Label4;
    }
}