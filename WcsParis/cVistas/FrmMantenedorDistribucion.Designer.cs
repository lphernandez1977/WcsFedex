namespace WcsFedex
{
    partial class FrmMantenedorDistribucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMantenedorDistribucion));
            this.Label4 = new System.Windows.Forms.Label();
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.CboJornada = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtDescDestino = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtAndenDestino = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtProducto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtZona = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDestino = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TxtOrigen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.RadioFedex = new System.Windows.Forms.RadioButton();
            this.RadioFasa = new System.Windows.Forms.RadioButton();
            this.DgvDatosFasa = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatosFasa)).BeginInit();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Navy;
            this.Label4.Location = new System.Drawing.Point(-4, -162);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(296, 29);
            this.Label4.TabIndex = 51;
            this.Label4.Text = "MANTENEDOR SALIDAS";
            // 
            // DgvDatos
            // 
            this.DgvDatos.AllowUserToAddRows = false;
            this.DgvDatos.AllowUserToDeleteRows = false;
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.Location = new System.Drawing.Point(10, 434);
            this.DgvDatos.Margin = new System.Windows.Forms.Padding(4);
            this.DgvDatos.MultiSelect = false;
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.ReadOnly = true;
            this.DgvDatos.Size = new System.Drawing.Size(840, 297);
            this.DgvDatos.TabIndex = 49;
            this.DgvDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDatos_CellDoubleClick);
            this.DgvDatos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDatos_KeyDown);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.BtnLimpiar);
            this.GroupBox1.Controls.Add(this.CboJornada);
            this.GroupBox1.Controls.Add(this.label10);
            this.GroupBox1.Controls.Add(this.label9);
            this.GroupBox1.Controls.Add(this.TxtDescDestino);
            this.GroupBox1.Controls.Add(this.label8);
            this.GroupBox1.Controls.Add(this.TxtAndenDestino);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.TxtProducto);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.TxtZona);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.TxtDestino);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.TxtOrigen);
            this.GroupBox1.Location = new System.Drawing.Point(0, 150);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(850, 250);
            this.GroupBox1.TabIndex = 48;
            this.GroupBox1.TabStop = false;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.ForeColor = System.Drawing.Color.Navy;
            this.BtnLimpiar.Image = global::WcsFedex.Properties.Resources.limpiar;
            this.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpiar.Location = new System.Drawing.Point(700, 198);
            this.BtnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(135, 36);
            this.BtnLimpiar.TabIndex = 57;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // CboJornada
            // 
            this.CboJornada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboJornada.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboJornada.ForeColor = System.Drawing.Color.Navy;
            this.CboJornada.FormattingEnabled = true;
            this.CboJornada.Location = new System.Drawing.Point(218, 183);
            this.CboJornada.Name = "CboJornada";
            this.CboJornada.Size = new System.Drawing.Size(232, 32);
            this.CboJornada.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(24, 181);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 29);
            this.label10.TabIndex = 16;
            this.label10.Text = "Jornada";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(325, 143);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 29);
            this.label9.TabIndex = 14;
            this.label9.Text = "Destino";
            // 
            // TxtDescDestino
            // 
            this.TxtDescDestino.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescDestino.Location = new System.Drawing.Point(444, 140);
            this.TxtDescDestino.Margin = new System.Windows.Forms.Padding(4);
            this.TxtDescDestino.MaxLength = 50;
            this.TxtDescDestino.Name = "TxtDescDestino";
            this.TxtDescDestino.Size = new System.Drawing.Size(232, 35);
            this.TxtDescDestino.TabIndex = 5;
            this.TxtDescDestino.Enter += new System.EventHandler(this.TxtDescDestino_Enter);
            this.TxtDescDestino.Leave += new System.EventHandler(this.TxtDescDestino_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(24, 141);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 29);
            this.label8.TabIndex = 12;
            this.label8.Text = "Anden Destino";
            // 
            // TxtAndenDestino
            // 
            this.TxtAndenDestino.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAndenDestino.Location = new System.Drawing.Point(219, 138);
            this.TxtAndenDestino.Margin = new System.Windows.Forms.Padding(4);
            this.TxtAndenDestino.MaxLength = 2;
            this.TxtAndenDestino.Name = "TxtAndenDestino";
            this.TxtAndenDestino.Size = new System.Drawing.Size(88, 35);
            this.TxtAndenDestino.TabIndex = 4;
            this.TxtAndenDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtAndenDestino.Enter += new System.EventHandler(this.TxtAndenDestino_Enter);
            this.TxtAndenDestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAndenDestino_KeyPress);
            this.TxtAndenDestino.Leave += new System.EventHandler(this.TxtAndenDestino_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(321, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Producto";
            // 
            // TxtProducto
            // 
            this.TxtProducto.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProducto.Location = new System.Drawing.Point(445, 97);
            this.TxtProducto.Margin = new System.Windows.Forms.Padding(4);
            this.TxtProducto.MaxLength = 2;
            this.TxtProducto.Name = "TxtProducto";
            this.TxtProducto.Size = new System.Drawing.Size(88, 35);
            this.TxtProducto.TabIndex = 3;
            this.TxtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtProducto.Enter += new System.EventHandler(this.TxtProducto_Enter);
            this.TxtProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProducto_KeyPress);
            this.TxtProducto.Leave += new System.EventHandler(this.TxtProducto_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(24, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 29);
            this.label7.TabIndex = 8;
            this.label7.Text = "Zona";
            // 
            // TxtZona
            // 
            this.TxtZona.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtZona.Location = new System.Drawing.Point(219, 97);
            this.TxtZona.Margin = new System.Windows.Forms.Padding(4);
            this.TxtZona.MaxLength = 4;
            this.TxtZona.Name = "TxtZona";
            this.TxtZona.Size = new System.Drawing.Size(88, 35);
            this.TxtZona.TabIndex = 2;
            this.TxtZona.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtZona.Enter += new System.EventHandler(this.TxtZona_Enter);
            this.TxtZona.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtZona_KeyPress);
            this.TxtZona.Leave += new System.EventHandler(this.TxtZona_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(321, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 29);
            this.label6.TabIndex = 6;
            this.label6.Text = "Destino";
            // 
            // TxtDestino
            // 
            this.TxtDestino.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDestino.Location = new System.Drawing.Point(445, 53);
            this.TxtDestino.Margin = new System.Windows.Forms.Padding(4);
            this.TxtDestino.MaxLength = 3;
            this.TxtDestino.Name = "TxtDestino";
            this.TxtDestino.Size = new System.Drawing.Size(88, 35);
            this.TxtDestino.TabIndex = 1;
            this.TxtDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtDestino.Enter += new System.EventHandler(this.TxtDestino_Enter);
            this.TxtDestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDestino_KeyPress);
            this.TxtDestino.Leave += new System.EventHandler(this.TxtDestino_Leave);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Navy;
            this.Label1.Location = new System.Drawing.Point(24, 60);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(90, 29);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Origen";
            // 
            // TxtOrigen
            // 
            this.TxtOrigen.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOrigen.Location = new System.Drawing.Point(219, 57);
            this.TxtOrigen.Margin = new System.Windows.Forms.Padding(4);
            this.TxtOrigen.MaxLength = 3;
            this.TxtOrigen.Name = "TxtOrigen";
            this.TxtOrigen.Size = new System.Drawing.Size(88, 35);
            this.TxtOrigen.TabIndex = 0;
            this.TxtOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtOrigen.Enter += new System.EventHandler(this.TxtOrigen_Enter);
            this.TxtOrigen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtOrigen_KeyPress);
            this.TxtOrigen.Leave += new System.EventHandler(this.TxtOrigen_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(206, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(505, 29);
            this.label3.TabIndex = 52;
            this.label3.Text = "MANTENEDOR TABLAS DE DISTRIBUCIÓN";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Navy;
            this.Label5.Location = new System.Drawing.Point(10, 409);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(219, 19);
            this.Label5.TabIndex = 53;
            this.Label5.Text = "Listado Distribución Fedex";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Navy;
            this.BtnSalir.Image = global::WcsFedex.Properties.Resources.salir;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(710, 745);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 36);
            this.BtnSalir.TabIndex = 55;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.Navy;
            this.BtnGuardar.Image = global::WcsFedex.Properties.Resources.grabar;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(571, 745);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(135, 36);
            this.BtnGuardar.TabIndex = 54;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.Color.Navy;
            this.BtnEliminar.Image = global::WcsFedex.Properties.Resources.eliminar;
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(432, 745);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(135, 36);
            this.BtnEliminar.TabIndex = 56;
            this.BtnEliminar.Text = "Borrar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // RadioFedex
            // 
            this.RadioFedex.AutoSize = true;
            this.RadioFedex.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.RadioFedex.ForeColor = System.Drawing.Color.Navy;
            this.RadioFedex.Location = new System.Drawing.Point(24, 57);
            this.RadioFedex.Name = "RadioFedex";
            this.RadioFedex.Size = new System.Drawing.Size(196, 33);
            this.RadioFedex.TabIndex = 57;
            this.RadioFedex.TabStop = true;
            this.RadioFedex.Text = "Listado Fedex";
            this.RadioFedex.UseVisualStyleBackColor = true;
            this.RadioFedex.Click += new System.EventHandler(this.RadioFedex_Click);
            // 
            // RadioFasa
            // 
            this.RadioFasa.AutoSize = true;
            this.RadioFasa.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.RadioFasa.ForeColor = System.Drawing.Color.Navy;
            this.RadioFasa.Location = new System.Drawing.Point(250, 57);
            this.RadioFasa.Name = "RadioFasa";
            this.RadioFasa.Size = new System.Drawing.Size(181, 33);
            this.RadioFasa.TabIndex = 58;
            this.RadioFasa.TabStop = true;
            this.RadioFasa.Text = "Listado Fasa";
            this.RadioFasa.UseVisualStyleBackColor = true;
            this.RadioFasa.Visible = false;
            this.RadioFasa.Click += new System.EventHandler(this.RadioFasa_Click);
            // 
            // DgvDatosFasa
            // 
            this.DgvDatosFasa.AllowUserToAddRows = false;
            this.DgvDatosFasa.AllowUserToDeleteRows = false;
            this.DgvDatosFasa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatosFasa.Location = new System.Drawing.Point(10, 201);
            this.DgvDatosFasa.Margin = new System.Windows.Forms.Padding(4);
            this.DgvDatosFasa.MultiSelect = false;
            this.DgvDatosFasa.Name = "DgvDatosFasa";
            this.DgvDatosFasa.ReadOnly = true;
            this.DgvDatosFasa.Size = new System.Drawing.Size(840, 530);
            this.DgvDatosFasa.TabIndex = 59;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(15, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 19);
            this.label11.TabIndex = 60;
            this.label11.Text = "Listado Distribucion Fasa";
            // 
            // FrmMantenedorDistribucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 788);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DgvDatosFasa);
            this.Controls.Add(this.RadioFasa);
            this.Controls.Add(this.RadioFedex);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.DgvDatos);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMantenedorDistribucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-MAC Ingeniería Eléctrica y Mantenimiento Industrial";
            this.Load += new System.EventHandler(this.FrmMantenedorDistribucion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatosFasa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DataGridView DgvDatos;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TxtOrigen;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox TxtDescDestino;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox TxtAndenDestino;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox TxtProducto;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox TxtZona;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox TxtDestino;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button BtnSalir;
        internal System.Windows.Forms.Button BtnGuardar;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CboJornada;
        internal System.Windows.Forms.Button BtnEliminar;
        internal System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.RadioButton RadioFedex;
        private System.Windows.Forms.RadioButton RadioFasa;
        internal System.Windows.Forms.DataGridView DgvDatosFasa;
        private System.Windows.Forms.Label label11;
    }
}