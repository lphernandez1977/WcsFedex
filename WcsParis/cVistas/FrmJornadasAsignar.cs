using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WcsFedex
{
    public partial class FrmJornadasAsignar : Form
    {       
        public FrmJornadasAsignar()
        {
            InitializeComponent();
        }

        ENT_Tb_Tiendas _ENT_Tb_Tiendas = new ENT_Tb_Tiendas();
        LGN_Tb_Tiendas _LGN_Tb_Tiendas = new LGN_Tb_Tiendas();

        LGN_TB_Distribucion _lgn_Tb_Distribucion = new LGN_TB_Distribucion();

        DataTable dt = new DataTable();
        public Image imagen;
        public string oUsuario;

        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();


        //Grilla
        #region
        //**// Crea la Alineacion de la grilla
        enum Alineacion
        {
            Izquierda,
            Centro,
            Derecha
        }

        //**// Limpiar grilla
        private void GrillaLimpia(DataGridView dtg)
        {
            dtg.DataSource = null;
            dtg.Rows.Clear();
            dtg.Columns.Clear();

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Id", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Jornada", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Observacion", true);
            _seteaformato.CreaGrillaLimpia(dtg, 3, "Estado", true);
            _seteaformato.CreaGrillaImg(dtg, 4, "Detalle", true);
        }

        private void FormatoGrilla(DataGridView dtg)
        {

            //***********************
            //CABECERA DE GRILLA
            //***********************
            //Permite habilitar los formatos del usuario
            DgvDatos.EnableHeadersVisualStyles = false;
            //oculta la columna Default de grilla
            DgvDatos.RowHeadersVisible = false;

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Id", 50, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Jornada", 80, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Observacion", 400, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 3, "Estado", 100, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 4, "Detalle", 80, true, Alineacion.Centro.ToString(), true);

            //--- Permite la Seleccion de la Fila Completa
            DgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //--- Permite que la grilla no se pueda editar
            DgvDatos.ReadOnly = true;
            //--- desabilita el agrear linea
            DgvDatos.AllowUserToAddRows = false;
            //Permite copiar al Portapapeles (Memoria), para luego pegar... excel, bloc de notas, etc. (solo Dios y SG sabe lo que hace)
            DgvDatos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DgvDatos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Navy;

            //***********************
            //DETALLE DE GRILLA
            //***********************
            //cambia el Color de Fondo de la Grilla
            DgvDatos.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            //cambia el Color de Seleccion
            DgvDatos.DefaultCellStyle.SelectionBackColor = Color.Lime;
            //cambia el Color de fuente
            DgvDatos.DefaultCellStyle.SelectionForeColor = Color.Navy;
            //cambia el Tamaño y Letra de la fuente, color 
            DgvDatos.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8);
            DgvDatos.DefaultCellStyle.ForeColor = Color.Navy;
            DgvDatos.MultiSelect = false;

        }
        #endregion

        //Grilla 2
        #region

        //**// Limpiar grilla
        private void GrillaLimpia2(DataGridView dtg)
        {
            dtg.DataSource = null;
            dtg.Rows.Clear();
            dtg.Columns.Clear();

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Id", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Observacion", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Tipo", true);            
        }

        private void FormatoGrilla2(DataGridView dtg)
        {

            //***********************
            //CABECERA DE GRILLA
            //***********************
            //Permite habilitar los formatos del usuario
            DgvDatos2.EnableHeadersVisualStyles = false;
            //oculta la columna Default de grilla
            DgvDatos2.RowHeadersVisible = false;

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Id", 50, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Observacion", 400, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Tipo", 200, true, Alineacion.Izquierda.ToString(), true);
            
            //--- Permite la Seleccion de la Fila Completa
            DgvDatos2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //--- Permite que la grilla no se pueda editar
            DgvDatos2.ReadOnly = true;
            //--- desabilita el agrear linea
            DgvDatos2.AllowUserToAddRows = false;
            //Permite copiar al Portapapeles (Memoria), para luego pegar... excel, bloc de notas, etc. (solo Dios y SG sabe lo que hace)
            DgvDatos2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DgvDatos2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Navy;

            //***********************
            //DETALLE DE GRILLA
            //***********************
            //cambia el Color de Fondo de la Grilla
            DgvDatos2.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            //cambia el Color de Seleccion
            DgvDatos2.DefaultCellStyle.SelectionBackColor = Color.Lime;
            //cambia el Color de fuente
            DgvDatos2.DefaultCellStyle.SelectionForeColor = Color.Navy;
            //cambia el Tamaño y Letra de la fuente, color 
            DgvDatos2.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8);
            DgvDatos2.DefaultCellStyle.ForeColor = Color.Navy;
            DgvDatos2.MultiSelect = false;

        }
        #endregion

        private void FrmJornadasAsignar_Load(object sender, EventArgs e)
        {
            GrillaLimpia(DgvDatos);
            LlenarGrilla();
            FormatoGrilla(DgvDatos);

            GrillaLimpia2(DgvDatos2);
            LlenarGrilla2();
            FormatoGrilla2(DgvDatos2);
        }

        private void LlenarGrilla()
        {
            DataSet dsdatos = new DataSet();
            //lleno dataset
            dsdatos = _lgn_Tb_Distribucion.Listado_Jornadas_Disponibles();

            if (dt.Rows.Count == 0)
            {
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("Jornada", typeof(string));
                dt.Columns.Add("Observacion", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Detalle", typeof(Image));
            }

            else 
            {
                dt.Clear();

                foreach (DataRow dr in dsdatos.Tables[0].Rows)
                {
                    dt.Rows.Add(
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        ImagenGrilla("Y")
                        );
                }

                //Elimina el enlace de datos para poder limpiar
                this.DgvDatos.DataSource = null;

                //limpia los datos
                this.DgvDatos.Rows.Clear();
                this.DgvDatos.Columns.Clear();

                //asigna la informacion a la grilla                    
                this.DgvDatos.DataSource = dt;

                return;
            
            }

            if (DgvDatos.Rows.Count != 0)
            {
                foreach (DataRow dr in dsdatos.Tables[0].Rows)
                {
                    dt.Rows.Add(
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        ImagenGrilla("Y")
                        );
                }

                //Elimina el enlace de datos para poder limpiar
                this.DgvDatos.DataSource = null;

                //limpia los datos
                this.DgvDatos.Rows.Clear();
                this.DgvDatos.Columns.Clear();

                //asigna la informacion a la grilla                    
                this.DgvDatos.DataSource = dt;
            }               
        }

        private void LlenarGrilla2()
        {
            DataSet dsdatos2 = new DataSet();
            //lleno dataset
            dsdatos2 = _lgn_Tb_Distribucion.Listado_Jornadas_EnProduccion();

            try
            {
                if (dsdatos2 != null)
                {

                    //Elimina el enlace de datos para poder limpiar
                    this.DgvDatos2.DataSource = null;

                    //limpia los datos
                    this.DgvDatos2.Rows.Clear();
                    this.DgvDatos2.Columns.Clear();

                    //asigna la informacion a la grilla                    
                    this.DgvDatos2.DataSource = dsdatos2.Tables[0];

                }
                else
                {
                    //cierra formulario de Carga
                    //FrmEspere.CerrarVentanaCarga(FrmEspere);  
                }
            }
            catch (Exception ex)
            {

            }
        }

        public object ImagenGrilla(string loc_Estado) 
        {
            
            string ruta = Directory.GetCurrentDirectory();
            string fileOK = @"modificar.png";
            string fileNO = @"ErrDb.png";

            //insercion de registros
            if (loc_Estado == "Y")
            {
                imagen = Image.FromFile(ruta + @"\" + fileOK);

                return imagen;
            }
            else
            {
                imagen = Image.FromFile(ruta + @"\" + fileNO);
                return imagen;
            }        
        }

        private void DgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;  
        }

        private void DgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmJornadaDetalle frmDetalleJornadas = new FrmJornadaDetalle();

            if (MessageBox.Show("Desea ver el detalle de la Jornada?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (e.RowIndex != -1)
                {
                    int id = Convert.ToInt16(DgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    frmDetalleJornadas.usuario = oUsuario;
                    frmDetalleJornadas.in_CorrJornada = id;
                    frmDetalleJornadas.ShowDialog();


                    //refresco los datos 
                    GrillaLimpia(DgvDatos);
                    LlenarGrilla();
                    FormatoGrilla(DgvDatos);

                    GrillaLimpia2(DgvDatos2);
                    LlenarGrilla2();
                    FormatoGrilla2(DgvDatos2);

                    //
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
