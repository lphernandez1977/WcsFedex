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
    public partial class FrmMantenedorTipDespachos : Form
    {
        cEnt_TB_Tipo_Despacho _TiposDespacho = new cEnt_TB_Tipo_Despacho();
        LGN_TipoDespacho _lgnTiposDespacho = new LGN_TipoDespacho();

        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();

        public DataSet dsdatos = new DataSet();

        bool flag = false;

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

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Codigo", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Nombre", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Id", true);
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

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Codigo", 80, true, Alineacion.Derecha.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Nombre", 300, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Id", 50, false, Alineacion.Izquierda.ToString(), true);
   
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

        public FrmMantenedorTipDespachos()
        {
            InitializeComponent();
        }

        private void FrmMantenedorTipDespachos_Load(object sender, EventArgs e)
        {
            this.Show();

            GrillaLimpia(DgvDatos);
            LlenarGrilla();
            FormatoGrilla(DgvDatos);            
        }

        private void TxtCodTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void LlenarGrilla()
        {
            
            //lleno dataset
            dsdatos = _lgnTiposDespacho.Listado_TipoDespacho();

            try
            {
                if (dsdatos != null)
                {
                    //abrir formulario de Carga
                    //FrmEspere.AbrirVentanaCarga(FrmEspere);

                    //Elimina el enlace de datos para poder limpiar
                    this.DgvDatos.DataSource = null;

                    //limpia los datos
                    this.DgvDatos.Rows.Clear();
                    this.DgvDatos.Columns.Clear();

                    //asigna la informacion a la grilla                    
                    this.DgvDatos.DataSource = dsdatos.Tables[0];

                    foreach (DataRow fila in dsdatos.Tables[0].Rows) 
                    {                        
                        _TiposDespacho.CodTipDespacho = Convert.ToInt16(fila[0].ToString());
                        _TiposDespacho.NomEstado = fila[1].ToString();                        
                    }
                    
                }
                else
                {
                    //cierra formulario de Carga
                    //FrmEspere.CerrarVentanaCarga(FrmEspere);  

                }
            }
            catch (Exception ex)
            {
                //FrmEspere.CerrarVentanaCarga(FrmEspere);
            }

        }

        private void DgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            //suprimo el enter
            e.SuppressKeyPress = true;          
        }

        private void BorrarCajas() 
        {
            TxtCodTipo.Text = string.Empty;
            TxtNomTipo.Text = string.Empty;        
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string res = string.Empty;
            string act = string.Empty;

            if ((dsdatos.Tables[0].Rows.Count >= 1) && (flag != true))
            {
                MessageBox.Show("No es posible agregar Tipos De Despacho, Si desea modificar, seleccione el registro con doble click y luego modifique CODIGO y NOMBRE", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;                
            }

            if (string.IsNullOrEmpty(TxtCodTipo.Text)) 
            {
                MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCodTipo.Focus();
                return;                                        
            }

            if (string.IsNullOrEmpty(TxtNomTipo.Text))
            {
                MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtNomTipo.Focus();
                return;
            }

            _TiposDespacho.CodTipDespacho = Convert.ToInt32(TxtCodTipo.Text);
            _TiposDespacho.NomEstado = TxtNomTipo.Text.Trim();
            _TiposDespacho.UsuarioRegistro = cTb_Usuarios.UserCon;


            if (flag)
            {
                //actualiza
                act = _lgnTiposDespacho.Actualiza_Tipo_Despacho(_TiposDespacho);
                if (act == "1")
                {
                    MessageBox.Show("Tipo despacho actualizado en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BorrarCajas();
                    GrillaLimpia(DgvDatos);
                    LlenarGrilla();
                    FormatoGrilla(DgvDatos);
                    flag = false;
                    BtnGuardar.Text = "Guardar";
                    return;
                }
                else
                {
                    MessageBox.Show(res, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


            }
            else
            {

                //crear nuevo registro
                res = _lgnTiposDespacho.Inserta_Tipo_Despacho(_TiposDespacho);
                if (res == "1")
                {
                    MessageBox.Show("Tipo despacho agregado en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BorrarCajas();
                    GrillaLimpia(DgvDatos);
                    LlenarGrilla();
                    FormatoGrilla(DgvDatos);
                    flag = false;
                    BtnGuardar.Text = "Guardar";
                    return;
                }
                else
                {
                    MessageBox.Show(res, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
          
        }

        private void TxtCodTipo_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtCodTipo);
        }

        private void TxtCodTipo_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtCodTipo);
        }

        private void TxtNomTipo_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtNomTipo);
        }

        private void TxtNomTipo_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtNomTipo);
        }

        private void DgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                TxtCodTipo.Text = DgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtNomTipo.Text = DgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString();
                _TiposDespacho.CodEstado = Convert.ToInt32(DgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString());
                flag = true;

                //quito registro grilla
                DgvDatos.Rows.RemoveAt(e.RowIndex);

                BtnGuardar.Text = "Editar";
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarCajas();

            TxtCodTipo.Focus();

            GrillaLimpia(DgvDatos);
            LlenarGrilla();
            FormatoGrilla(DgvDatos);

            BtnGuardar.Text = "Guardar";

        }        
    }
}
