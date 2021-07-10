using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;

namespace WcsFedex
{
    public partial class FrmEditVelocidad : Form
    {
        //PLC
        private Plc oPLC = null;
        CLS_Utilidades.CLS_ValNumero _valnum = new CLS_Utilidades.CLS_ValNumero();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();
        public int loc_divertor = 0;
        FrmDivertores Divertores = new FrmDivertores();

        public FrmEditVelocidad()
        {
            InitializeComponent();
        }

        private void FrmEditVelocidad_Load(object sender, EventArgs e)
        {
            

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void TxtValorNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            _valnum.ControlaEntero(TxtValorNuevo, e, 3);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtValorNuevo.Text))
            {
                MessageBox.Show("Debe llenar los campos solicitados", " Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtValorNuevo.Focus();
                return;
            }

            if (TxtValorNuevo.Text == "0")
            {
                MessageBox.Show("Debe llenar los campos solicitados", " Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtValorNuevo.Focus();
                return;
            }

            Escribir_TimePoint(loc_divertor, Convert.ToInt16(TxtValorNuevo.Text));
        }

        private void cConPLC()
        {
            try
            {
                oPLC = new Plc(CpuType.S71200, cDispositivos.glo_IpPLC, cDispositivos.glo_RackPLC, cDispositivos.glo_SlotPLC);

                oPLC.Open();

                bool EstadoPLC = oPLC.IsConnected;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Escribir_TimePoint(int div, short db1IntVariable)
        {
            FrmDivertores FormDiv = new FrmDivertores();
         
            int linea = div;           

            cConPLC();

            try
            {
                switch (linea)
                {
                    case 1:

                        oPLC.Write("DB2.DBW398", db1IntVariable.ConvertToUshort());
                        FormDiv.LblDiv01.Text = db1IntVariable.ToString();
                        FormDiv.ShowDialog();
                        break;

                    case 2:
                        oPLC.Write("DB2.DBW400", db1IntVariable.ConvertToUshort());
                        FormDiv.LblDiv02.Text = db1IntVariable.ToString();
                        FormDiv.ShowDialog();
                        break;

                    case 3:
                        oPLC.Write("DB2.DBW402", db1IntVariable.ConvertToUshort());
                        FormDiv.LblDiv03.Text = db1IntVariable.ToString();
                        FormDiv.ShowDialog();
                        break;

                    case 4:
                        oPLC.Write("DB2.DBW404", db1IntVariable.ConvertToUshort());
                        FormDiv.LblDiv04.Text = db1IntVariable.ToString();
                        FormDiv.ShowDialog();
                        break;

                    case 5:
                        oPLC.Write("DB2.DBW406", db1IntVariable.ConvertToUshort());
                        FormDiv.LblDiv05.Text = db1IntVariable.ToString();
                        FormDiv.ShowDialog();
                        break;

                    case 6:
                        oPLC.Write("DB2.DBW408", db1IntVariable.ConvertToUshort());
                        FormDiv.LblDiv06.Text = db1IntVariable.ToString();
                        FormDiv.ShowDialog();
                        break;

                    case 7:
                        oPLC.Write("DB2.DBW410", db1IntVariable.ConvertToUshort());
                        FormDiv.LblDiv07.Text = db1IntVariable.ToString();
                        FormDiv.ShowDialog();
                        break;                       
                }
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                this.Close();
            }

        }

        private void TxtValorNuevo_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtValorNuevo);
        }

        private void TxtValorNuevo_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtValorNuevo);
        }
    }
}
