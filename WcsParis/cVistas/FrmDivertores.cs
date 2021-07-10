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
    public partial class FrmDivertores : Form
    {
        //PLC
        private Plc oPLC = null;
        
                
        public FrmDivertores()
        {
            InitializeComponent();           
        }

        private void FrmDivertores_Load(object sender, EventArgs e)
        {

            if (cDispositivos.glo_EstadoConPLC)
            {
                cConPLC();
                Leer_TimePoint();
            }
            else 
            {
                //cConPLC();
            }

            this.Show();
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

        public void Leer_TimePoint() 
        {
            try
            {
                LblDiv01.Text = oPLC.Read("DB2.DBD358").ToString();
                LblDiv02.Text = oPLC.Read("DB2.DBD362").ToString();
                LblDiv03.Text = oPLC.Read("DB2.DBD366").ToString();
                LblDiv04.Text = oPLC.Read("DB2.DBD370").ToString();
                LblDiv05.Text = oPLC.Read("DB2.DBD374").ToString();
                LblDiv06.Text = oPLC.Read("DB2.DBD378").ToString();
                LblDiv07.Text = oPLC.Read("DB2.DBD382").ToString();               
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message.ToString(), " Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void BtnMod_Click(object sender, EventArgs e)
        {            
            FrmEditVelocidad EditVelocidad = new FrmEditVelocidad();
            EditVelocidad.LblModulo.Text = "DIVERTOR ----- 01";
            EditVelocidad.LblVeloActual.Text = LblDiv01.Text;
            EditVelocidad.loc_divertor = 1;
            this.Close();
            EditVelocidad.Show();            
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            FrmEditVelocidad EditVelocidad = new FrmEditVelocidad();
            EditVelocidad.LblModulo.Text = "DIVERTOR ----- 02";
            EditVelocidad.LblVeloActual.Text = LblDiv02.Text;
            EditVelocidad.loc_divertor = 2;
            this.Close();
            EditVelocidad.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            FrmEditVelocidad EditVelocidad = new FrmEditVelocidad();
            EditVelocidad.LblModulo.Text = "DIVERTOR ----- 03";
            EditVelocidad.LblVeloActual.Text = LblDiv03.Text;
            EditVelocidad.loc_divertor = 3;
            this.Close();
            EditVelocidad.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            FrmEditVelocidad EditVelocidad = new FrmEditVelocidad();
            EditVelocidad.LblModulo.Text = "DIVERTOR ----- 04";
            EditVelocidad.LblVeloActual.Text = LblDiv04.Text;
            EditVelocidad.loc_divertor = 4;
            this.Close();
            EditVelocidad.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
            FrmEditVelocidad EditVelocidad = new FrmEditVelocidad();
            EditVelocidad.LblModulo.Text = "DIVERTOR ----- 05";
            EditVelocidad.LblVeloActual.Text = LblDiv05.Text;
            EditVelocidad.loc_divertor = 5;
            this.Close();
            EditVelocidad.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmEditVelocidad EditVelocidad = new FrmEditVelocidad();
            EditVelocidad.LblModulo.Text = "DIVERTOR ----- 06";
            EditVelocidad.LblVeloActual.Text = LblDiv06.Text;
            EditVelocidad.loc_divertor = 6;
            this.Close();
            EditVelocidad.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmEditVelocidad EditVelocidad = new FrmEditVelocidad();
            EditVelocidad.LblModulo.Text = "DIVERTOR ----- 07";
            EditVelocidad.LblVeloActual.Text = LblDiv07.Text;
            EditVelocidad.loc_divertor = 7;
            this.Close();
            EditVelocidad.Show();
        }
   
    }
}
