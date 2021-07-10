namespace WcsFedex
{
    partial class FrmConfSalTiendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfSalTiendas));
            this.Label4 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.ListadoSalidasDisponibles = new System.Windows.Forms.ListBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnRest = new System.Windows.Forms.Button();
            this.BtnAddTodos = new System.Windows.Forms.Button();
            this.BtnResTodos = new System.Windows.Forms.Button();
            this.ListadoSeleccion = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Navy;
            this.Label4.Location = new System.Drawing.Point(270, 20);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(483, 33);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "ASIGNACIÓN DESTINO / JORNADA";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Navy;
            this.BtnSalir.Image = global::WcsFedex.Properties.Resources.salir;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(866, 574);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 36);
            this.BtnSalir.TabIndex = 11;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.Navy;
            this.BtnGuardar.Image = global::WcsFedex.Properties.Resources.grabar;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(723, 574);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(135, 36);
            this.BtnGuardar.TabIndex = 34;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // ListadoSalidasDisponibles
            // 
            this.ListadoSalidasDisponibles.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListadoSalidasDisponibles.ForeColor = System.Drawing.Color.Navy;
            this.ListadoSalidasDisponibles.FormattingEnabled = true;
            this.ListadoSalidasDisponibles.ItemHeight = 19;
            this.ListadoSalidasDisponibles.Location = new System.Drawing.Point(41, 68);
            this.ListadoSalidasDisponibles.Name = "ListadoSalidasDisponibles";
            this.ListadoSalidasDisponibles.Size = new System.Drawing.Size(420, 498);
            this.ListadoSalidasDisponibles.TabIndex = 38;
            this.ListadoSalidasDisponibles.DoubleClick += new System.EventHandler(this.ListadoSalidasDisponibles_DoubleClick);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.Navy;
            this.BtnAdd.Location = new System.Drawing.Point(473, 68);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(98, 34);
            this.BtnAdd.TabIndex = 39;
            this.BtnAdd.Text = "--->";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnRest
            // 
            this.BtnRest.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRest.ForeColor = System.Drawing.Color.Navy;
            this.BtnRest.Location = new System.Drawing.Point(473, 108);
            this.BtnRest.Name = "BtnRest";
            this.BtnRest.Size = new System.Drawing.Size(98, 34);
            this.BtnRest.TabIndex = 40;
            this.BtnRest.Text = "<---";
            this.BtnRest.UseVisualStyleBackColor = true;
            this.BtnRest.Click += new System.EventHandler(this.BtnRest_Click);
            // 
            // BtnAddTodos
            // 
            this.BtnAddTodos.ForeColor = System.Drawing.Color.Navy;
            this.BtnAddTodos.Location = new System.Drawing.Point(473, 148);
            this.BtnAddTodos.Name = "BtnAddTodos";
            this.BtnAddTodos.Size = new System.Drawing.Size(98, 44);
            this.BtnAddTodos.TabIndex = 41;
            this.BtnAddTodos.Text = "Agregar Todos ";
            this.BtnAddTodos.UseVisualStyleBackColor = true;
            this.BtnAddTodos.Click += new System.EventHandler(this.BtnAddTodos_Click);
            // 
            // BtnResTodos
            // 
            this.BtnResTodos.ForeColor = System.Drawing.Color.Navy;
            this.BtnResTodos.Location = new System.Drawing.Point(473, 198);
            this.BtnResTodos.Name = "BtnResTodos";
            this.BtnResTodos.Size = new System.Drawing.Size(98, 44);
            this.BtnResTodos.TabIndex = 42;
            this.BtnResTodos.Text = "Quitar Todos ";
            this.BtnResTodos.UseVisualStyleBackColor = true;
            this.BtnResTodos.Click += new System.EventHandler(this.BtnResTodos_Click);
            // 
            // ListadoSeleccion
            // 
            this.ListadoSeleccion.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListadoSeleccion.ForeColor = System.Drawing.Color.Navy;
            this.ListadoSeleccion.FormattingEnabled = true;
            this.ListadoSeleccion.ItemHeight = 19;
            this.ListadoSeleccion.Location = new System.Drawing.Point(581, 68);
            this.ListadoSeleccion.Name = "ListadoSeleccion";
            this.ListadoSeleccion.Size = new System.Drawing.Size(420, 498);
            this.ListadoSeleccion.TabIndex = 43;
            this.ListadoSeleccion.DoubleClick += new System.EventHandler(this.ListadoSeleccion_DoubleClick);
            // 
            // FrmConfSalTiendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 636);
            this.Controls.Add(this.ListadoSeleccion);
            this.Controls.Add(this.BtnResTodos);
            this.Controls.Add(this.BtnAddTodos);
            this.Controls.Add(this.BtnRest);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.ListadoSalidasDisponibles);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.Label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfSalTiendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-MAC Ingeniería Eléctrica y Mantenimiento Industrial";
            this.Load += new System.EventHandler(this.FrmConfSalTiendas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Button BtnSalir;
        internal System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.ListBox ListadoSalidasDisponibles;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnRest;
        private System.Windows.Forms.Button BtnAddTodos;
        private System.Windows.Forms.Button BtnResTodos;
        private System.Windows.Forms.ListBox ListadoSeleccion;
    }
}