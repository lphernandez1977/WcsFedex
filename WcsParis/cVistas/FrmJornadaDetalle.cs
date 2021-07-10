using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WcsFedex
{
    public partial class FrmJornadaDetalle : Form
    {
        public FrmJornadaDetalle()
        {
            InitializeComponent();
        }

        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();
        
        LGN_TB_Distribucion _lgn_Tb_Distribucion = new LGN_TB_Distribucion();

        public int in_CorrJornada = 0;
        public string usuario;

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

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Salida", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Destino", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Jornada", true);
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

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Salida", 50, true, Alineacion.Centro.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Destino", 150, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Jornada", 80, true, Alineacion.Izquierda.ToString(), true);

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

        private void FrmJornadaDetalle_Load(object sender, EventArgs e)
        {
            GrillaLimpia(DgvDatos);
            LlenarGrilla(in_CorrJornada);
            FormatoGrilla(DgvDatos);
        }

        private void LlenarGrilla(int loc_corr)
        {
            DataSet dsdatos = new DataSet();

            //lleno dataset
            dsdatos = _lgn_Tb_Distribucion.Listado_Detalle_Jornadas(loc_corr);

            try
            {
                if (dsdatos != null)
                {

                    //Elimina el enlace de datos para poder limpiar
                    this.DgvDatos.DataSource = null;

                    //limpia los datos
                    this.DgvDatos.Rows.Clear();
                    this.DgvDatos.Columns.Clear();

                    //asigna la informacion a la grilla                    
                    this.DgvDatos.DataSource = dsdatos.Tables[0];

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

        private void BtnExe_Click(object sender, EventArgs e)
        {

            string res = string.Empty;

            if (MessageBox.Show("Desea asignar la Jornada " + in_CorrJornada + " a produccion para iniciar la distribución?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                res = _lgn_Tb_Distribucion.Poner_Jornada_Produccion(in_CorrJornada, usuario);

                if (res == "1")
                {
                    this.Close();
                }
                else 
                {
                    MessageBox.Show(cTB_Distribucion.oMensajes.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);               
                }
            }
            else 
            {
                this.Close();            
            }


        }
    }
}
