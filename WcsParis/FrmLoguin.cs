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
    public partial class FrmLoguin : Form
    {
        public FrmLoguin()
        {
            InitializeComponent();
        }

        cMD5 oEncriptar = new cMD5();
        public cTb_Usuarios _cTb_Usuarios = new cTb_Usuarios();
        public cTb_Usuarios oUser = new cTb_Usuarios();
        public cENT_Usuarios oSistemas = new cENT_Usuarios();
        LGN_Tb_Usuarios _LGN_Tb_Usuarios = new LGN_Tb_Usuarios();
        ACD_Tb_Usuarios _ACD_Tb_Usuarios = new ACD_Tb_Usuarios();

        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();
        
        private void Btn_Login_Click(object sender, EventArgs e)
        {           
            if ((string.IsNullOrEmpty(TxtUsuario.Text))) 
            {
                MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtUsuario.Focus();
                return;            
            }

            if ((string.IsNullOrEmpty(txtPassword.Text)))
            {
                MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            _cTb_Usuarios.Nom_Usuario = TxtUsuario.Text.Trim();
            _cTb_Usuarios.Contrasenia = cMD5.Encriptar(txtPassword.Text.Trim());
            cTb_Usuarios.UserCon = _cTb_Usuarios.Nom_Usuario;
            
            oUser = _ACD_Tb_Usuarios.Selecciona_Usuario(_cTb_Usuarios);

            if (oUser == null) 
            {
                MessageBox.Show("Usuario esta desactivado, favor contactarse con el administrador  ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            FrmLoguin frmPass = new FrmLoguin();            
            frmPass.Close();
            this.Visible = false;

            if (oUser.Nivel == 1) 
            {
                if (oSistemas.Cod_Sistema == 1)
                {
                    FrmControlUsuarios frmUser = new FrmControlUsuarios();
                    frmUser.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 2)
                {
                    FrmMantenedorTiendas frmTiendas = new FrmMantenedorTiendas();
                    frmTiendas.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 3)
                {
                    FrmMantenedorLineas  frmSalidas = new FrmMantenedorLineas();
                    frmSalidas.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 4)
                {
                    FrmConfSalTiendas frmSalTien = new FrmConfSalTiendas();
                    frmSalTien.oUsuario = _cTb_Usuarios.Nom_Usuario;
                    frmSalTien.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 5)
                {
                    FrmConfOlasTiendas frmOlasTien = new FrmConfOlasTiendas();
                    frmOlasTien.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 6)
                {
                    FrmReporteScanner frmReporte = new FrmReporteScanner();
                    frmReporte.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 8)
                {
                    FrmMantenedorDTD frmDTD = new FrmMantenedorDTD();
                    frmDTD.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 60)
                {
                    FrmEntradas frmEntradas = new FrmEntradas();
                    frmEntradas.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 70)
                {
                    FrmSalidas frmSalidas = new FrmSalidas();
                    frmSalidas.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 80)
                {
                    FrmProbarCaidas frmProbar = new FrmProbarCaidas();
                    frmProbar.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 9)
                {
                    FrmMantenedorDistribucion frmDistribucion = new FrmMantenedorDistribucion();
                    frmDistribucion.Usuario = _cTb_Usuarios.Nom_Usuario;
                    frmDistribucion.ShowDialog();
                    return;
                }


                if (oSistemas.Cod_Sistema == 10)
                {
                    FrmMantenedorTipDespachos frmTiposDespacho = new FrmMantenedorTipDespachos();
                    //frmTiposDespacho.MdiParent = this.MdiParent;
                    frmTiposDespacho.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 11)
                {
                    FrmDivertores Divertores = new FrmDivertores();
                    Divertores.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 12)
                {
                    FrmJornadasAsignar FrmJornadas = new FrmJornadasAsignar();
                    FrmJornadas.oUsuario = _cTb_Usuarios.Nom_Usuario;
                    FrmJornadas.ShowDialog();                                        
                    return;
                }
               
                MessageBox.Show("No tiene permiso para ingresar al MENU solicitado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);             
            }

            if (oUser.Nivel == 2)
            {
                //if (oSistemas.Cod_Sistema == 1)
                //{
                //    FrmControlUsuarios frmUser = new FrmControlUsuarios();
                //    frmUser.ShowDialog();
                //}

                if (oSistemas.Cod_Sistema == 2)
                {
                    FrmMantenedorTiendas frmTiendas = new FrmMantenedorTiendas();
                    frmTiendas.ShowDialog();
                }

                if (oSistemas.Cod_Sistema == 3)
                {
                    FrmMantenedorLineas frmSalidas = new FrmMantenedorLineas();
                    frmSalidas.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 4)
                {
                    FrmConfSalTiendas frmSalTien = new FrmConfSalTiendas();
                    frmSalTien.oUsuario = _cTb_Usuarios.Nom_Usuario;
                    frmSalTien.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 5)
                {
                    FrmConfOlasTiendas frmOlasTien = new FrmConfOlasTiendas();
                    frmOlasTien.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 6)
                {
                    FrmReporteScanner frmReporte = new FrmReporteScanner();
                    frmReporte.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 7)
                {
                    FrmRecuperarPass frmRecupera = new FrmRecuperarPass();
                    frmRecupera.ShowDialog();
                    return;
                }

                if (oSistemas.Cod_Sistema == 8)
                {
                    FrmReporteScanner frmReporte = new FrmReporteScanner();
                    frmReporte.ShowDialog();
                    return;
                }

                MessageBox.Show("No tiene permiso para ingresar al MENU solicitado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);                           
             }
           
        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtUsuario);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(txtPassword);
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtUsuario);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(txtPassword);
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FrmLoguin_Load(object sender, EventArgs e)
        {

        }
    }
}
