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
    public partial class FrmJornada : Form
    {
        public int loc_Id_Jornada = 0;
        public string loc_Jornada = string.Empty;

        public FrmJornada()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void LlenarCboJornada()
        {
            List<cENT_Lista> lista = new List<cENT_Lista>();

            lista.Add(new cENT_Lista("Seleccionar Jornada", 0));
            lista.Add(new cENT_Lista("AM", 1));
            lista.Add(new cENT_Lista("PM", 2));


            //Vaciar comboBox
            this.CboJornada.DataSource = null;

            //Asignar la propiedad DataSource
            this.CboJornada.DataSource = lista;

            //Indicar qué propiedad se verá en la lista
            this.CboJornada.DisplayMember = "Name";

            //Indicar qué valor tendrá cada ítem
            this.CboJornada.ValueMember = "Value";
        }

        private void FrmJornada_Load(object sender, EventArgs e)
        {
            LlenarCboJornada();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea asignar la Jornada " + loc_Jornada  + " a las tiendas seleccionadas, para distribución?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                loc_Jornada = CboJornada.SelectedItem.ToString();
                this.Close();
            }          
        }

     
    }
}
