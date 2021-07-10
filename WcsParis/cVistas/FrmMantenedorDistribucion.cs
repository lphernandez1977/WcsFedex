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
    public partial class FrmMantenedorDistribucion : Form
    {
        bool flag = false;

        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();
        CLS_Utilidades.CLS_ValNumero _valnum = new CLS_Utilidades.CLS_ValNumero();
        

        //registro log
        cRegistroErr RegErrores = new cRegistroErr();
        cTB_Distribucion _oTb_Distribucion = new cTB_Distribucion();
        LGN_TB_Distribucion _neg_TB_Distribucion = new LGN_TB_Distribucion();

        public string Usuario;

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

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Cod", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Origen", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Destino", true);
            _seteaformato.CreaGrillaLimpia(dtg, 3, "Zona", true);
            _seteaformato.CreaGrillaLimpia(dtg, 4, "Producto", true);
            _seteaformato.CreaGrillaLimpia(dtg, 5, "Anden", true);
            _seteaformato.CreaGrillaLimpia(dtg, 6, "Descripción", true);
            _seteaformato.CreaGrillaLimpia(dtg, 7, "Jornada", true);
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

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Cod", 70,false, Alineacion.Izquierda.ToString(),true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Origen", 60, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Destino", 80, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 3, "Zona", 60, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 4, "Producto", 80, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 5, "Anden", 60, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 6, "Descripción", 130, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 7, "Jornada", 60, true, Alineacion.Izquierda.ToString(), true);


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

        }

        private void GrillaLimpia2(DataGridView dtg)
        {
            dtg.DataSource = null;
            dtg.Rows.Clear();
            dtg.Columns.Clear();

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Id", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Codigo", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Salida", true);            
        }

        private void FormatoGrilla2(DataGridView dtg)
        {

            //***********************
            //CABECERA DE GRILLA
            //***********************
            //Permite habilitar los formatos del usuario
            DgvDatosFasa.EnableHeadersVisualStyles = false;
            //oculta la columna Default de grilla
            DgvDatosFasa.RowHeadersVisible = false;

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Id", 70, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Codigo", 120, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Salida", 120, true, Alineacion.Izquierda.ToString(), true);

            //--- Permite la Seleccion de la Fila Completa
            DgvDatosFasa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //--- Permite que la grilla no se pueda editar
            DgvDatosFasa.ReadOnly = true;
            //--- desabilita el agrear linea
            DgvDatosFasa.AllowUserToAddRows = false;
            //Permite copiar al Portapapeles (Memoria), para luego pegar... excel, bloc de notas, etc. (solo Dios y SG sabe lo que hace)
            DgvDatosFasa.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DgvDatosFasa.ColumnHeadersDefaultCellStyle.ForeColor = Color.Navy;

            //***********************
            //DETALLE DE GRILLA
            //***********************
            //cambia el Color de Fondo de la Grilla
            DgvDatosFasa.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            //cambia el Color de Seleccion
            DgvDatosFasa.DefaultCellStyle.SelectionBackColor = Color.Lime;
            //cambia el Color de fuente
            DgvDatosFasa.DefaultCellStyle.SelectionForeColor = Color.Navy;
            //cambia el Tamaño y Letra de la fuente, color 
            DgvDatosFasa.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8);
            DgvDatosFasa.DefaultCellStyle.ForeColor = Color.Navy;
        }
                
        #endregion

        private void LlenarGrilla()
        {
            //lleno dataset
            DataSet dsdatos = new DataSet();
            dsdatos = _neg_TB_Distribucion.Listado_TB_Distribucion();

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
                }
            }
            catch (Exception ex)
            {
                RegErrores.RegistroLog(ex.Message.ToString() + " funcion LeerEtiquetasDerivadas");
            }

        }

        private void LlenarGrillaFasa()
        {
            //lleno dataset
            DataSet dsdatos = new DataSet();
            dsdatos = _neg_TB_Distribucion.Listado_TB_DistribucionFasa();

            try
            {
                if (dsdatos != null)
                {

                    //Elimina el enlace de datos para poder limpiar
                    this.DgvDatosFasa.DataSource = null;

                    //limpia los datos
                    this.DgvDatosFasa.Rows.Clear();
                    this.DgvDatosFasa.Columns.Clear();

                    //asigna la informacion a la grilla                    
                    this.DgvDatosFasa.DataSource = dsdatos.Tables[0];
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                RegErrores.RegistroLog(ex.Message.ToString() + " funcion LeerEtiquetasDerivadas");
            }

        }

        public FrmMantenedorDistribucion()
        {
            InitializeComponent();
        }

        private void FrmMantenedorDistribucion_Load(object sender, EventArgs e)
        {          
            RadioFedex.Checked = true;
            RadioFasa.Checked = false;
            DgvDatosFasa.Visible = false;
                 
            GrillaLimpia(DgvDatos);
            LlenarGrilla();
            FormatoGrilla(DgvDatos);

            LenarCboJornada();

            this.Show();

        }

        private void TxtOrigen_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtOrigen);
        }

        private void TxtDestino_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtDestino);
        }

        private void TxtZona_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtZona);
        }

        private void TxtProducto_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtProducto);
        }

        private void TxtAndenDestino_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtAndenDestino);
        }

        private void TxtDescDestino_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtDescDestino);
        }

        private void TxtOrigen_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtOrigen);
        }

        private void TxtDestino_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtDestino);
        }

        private void TxtZona_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtZona);
        }

        private void TxtProducto_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtProducto);
        }

        private void TxtAndenDestino_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtAndenDestino);
        }

        private void TxtDescDestino_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtDescDestino);
        }

        private void TxtOrigen_KeyPress(object sender, KeyPressEventArgs e)
        {
            _valnum.ControlaEntero(TxtOrigen, e, 3);
        }

        private void TxtDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            _valnum.ControlaEntero(TxtDestino, e, 3);
        }

        private void TxtZona_KeyPress(object sender, KeyPressEventArgs e)
        {
            _valnum.ControlaEntero(TxtZona, e, 4);
        }

        private void TxtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            _valnum.ControlaEntero(TxtProducto, e, 2);
        }

        private void TxtAndenDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            _valnum.ControlaEntero(TxtAndenDestino, e, 1);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BorrarCajas() 
        {
            TxtOrigen.Text = string.Empty;
            TxtDestino.Text = string.Empty;
            TxtZona.Text = string.Empty;
            TxtProducto.Text = string.Empty;
            TxtAndenDestino.Text = string.Empty;
            TxtDescDestino.Text = string.Empty;
            LenarCboJornada(); 
        }

        private void DgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            //suprimo el enter
            e.SuppressKeyPress = true;  
        }

        private void DgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _oTb_Distribucion.Codigo = Convert.ToInt16(DgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                TxtOrigen.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString());
                TxtDestino.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString());
                TxtZona.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString());
                TxtProducto.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString());
                TxtAndenDestino.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString());
                TxtDescDestino.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[6].Value.ToString());

                if (DgvDatos.Rows[e.RowIndex].Cells[7].Value.ToString() == "AM")
                {
                    CboJornada.SelectedValue = 1;
                }
                else
                {
                    CboJornada.SelectedValue = 2;
                }


                TxtOrigen.Focus();
                //quito registro grilla
                DgvDatos.Rows.RemoveAt(e.RowIndex);
                flag = true;
                BtnGuardar.Text = "Editar";
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string res = string.Empty;
            string mod = string.Empty;
                                 
            if (string.IsNullOrEmpty(TxtDescDestino.Text))
            {
                MessageBox.Show("Se debe llenar el destino de la distribución ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtOrigen.Focus();
                return;
            }

            if (CboJornada.SelectedValue == "0") 
            {
                MessageBox.Show("Se debe agregar jornada al destino de la distribución ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CboJornada.Focus();
                return;            
            }

            _oTb_Distribucion._DEPOT_FROM = TxtOrigen.Text;
            _oTb_Distribucion._DEPOT_TO = TxtDestino.Text;
            _oTb_Distribucion._ZONA = TxtZona.Text;
            _oTb_Distribucion._PRODUCTO = TxtProducto.Text;
            _oTb_Distribucion._ANDEN_DESTINO = Convert.ToInt16(TxtAndenDestino.Text);
            _oTb_Distribucion._DescDestino = TxtDescDestino.Text.ToUpper();
            _oTb_Distribucion._JORNADA = CboJornada.SelectedValue.ToString();
            
            
            
            if (flag)
            {
                if (MessageBox.Show("Desea modificar Destino " + _oTb_Distribucion._DEPOT_TO.ToString() + ". ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    _oTb_Distribucion._USUARIO_MOD = cTb_Usuarios.UserCon;

                    mod = _neg_TB_Distribucion.Editar_TB_Distribucion(_oTb_Distribucion);

                    if (mod == "1")
                    {
                        MessageBox.Show("Destino editado en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BorrarCajas();
                        LlenarGrilla();
                        FormatoGrilla(DgvDatos);
                        flag = false;
                        BtnGuardar.Text = "Guardar";
                        LenarCboJornada();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(mod, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else 
                {
                    BorrarCajas();
                    LlenarGrilla();
                    FormatoGrilla(DgvDatos);                  
                }

            }
            else 
            {
                if (MessageBox.Show("Desea agregar nuevo Destino. ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    _oTb_Distribucion._USUARIO_CREA = cTb_Usuarios.UserCon;

                    res = _neg_TB_Distribucion.Inserta_TB_Distribucion(_oTb_Distribucion);

                    if (res == "1")
                    {
                        MessageBox.Show("Destino agregado en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BorrarCajas();
                        LlenarGrilla();
                        FormatoGrilla(DgvDatos);
                        flag = false;
                        BtnGuardar.Text = "Guardar";
                        LenarCboJornada();
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
                    BorrarCajas();
                    LlenarGrilla();
                    FormatoGrilla(DgvDatos);
                }                             
            }
        }



        private void LenarCboJornada()
        {
            List<cTb_Nivel> lista = new List<cTb_Nivel>();

            lista.Add(new cTb_Nivel("Seleccionar Jornada", 0));
            lista.Add(new cTb_Nivel("AM", 1));
            lista.Add(new cTb_Nivel("PM", 2));

            //Vaciar comboBox
            this.CboJornada.DataSource = null;

            //Asignar la propiedad DataSource
            this.CboJornada.DataSource = lista;

            //Indicar qué propiedad se verá en la lista
            this.CboJornada.DisplayMember = "Name";

            //Indicar qué valor tendrá cada ítem
            this.CboJornada.ValueMember = "Value";
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            string res = string.Empty;

            if (MessageBox.Show("Desea eliminar el origen " + TxtOrigen.Text + " seleccionado ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                res = _neg_TB_Distribucion.Eliminar_TB_Distribucion(_oTb_Distribucion);

                if (res == "1") 
                {
                    MessageBox.Show("Origen eliminado en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BorrarCajas();
                    LlenarGrilla();
                    FormatoGrilla(DgvDatos);
                    flag = false;                    
                    LenarCboJornada();
                    TxtOrigen.Focus();            
                    return;
                }
                else
                {
                    MessageBox.Show(res, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            BorrarCajas();
            TxtOrigen.Focus();            
            LlenarGrilla();
            FormatoGrilla(DgvDatos);
        }

        private void RadioFedex_Click(object sender, EventArgs e)
        {
            if (RadioFedex.Checked = true) 
            {
                GroupBox1.Visible = true;
                DgvDatos.Visible = true;
                Label5.Visible = true;
                label11.Visible = false;
                DgvDatosFasa.Visible = false;                                       
            }
        }

        private void RadioFasa_Click(object sender, EventArgs e)
        {
            if (RadioFasa.Checked = true) 
            {
                DgvDatosFasa.Visible = true;
                label11.Visible = true;
                
                GrillaLimpia2(DgvDatosFasa);
                LlenarGrillaFasa();
                FormatoGrilla2(DgvDatosFasa);

                Label5.Visible = false;                
                GroupBox1.Visible = false;
                DgvDatos.Visible = false;            
            }
        }



 
    }
}
