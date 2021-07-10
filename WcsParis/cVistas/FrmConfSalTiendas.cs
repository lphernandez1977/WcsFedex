using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;

namespace WcsFedex
{
    public partial class FrmConfSalTiendas : Form
    {
        public FrmConfSalTiendas()
        {
            InitializeComponent();
        }

        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();

        cRegistroErr LogError = new cRegistroErr();

        cTB_Distribucion oTablaDistribucion = new cTB_Distribucion();
        cTb_Lineas _ENT_Lineas = new cTb_Lineas();
        
        ENT_Tb_Tiendas _ENT_Tb_Tiendas = new ENT_Tb_Tiendas(); 

        LGN_Tb_Tiendas _LGN_Tb_Tiendas = new LGN_Tb_Tiendas();
        LGN_Tb_Lineas _LGN_Tb_Lineas = new LGN_Tb_Lineas();

        public string oUsuario = string.Empty;
        public string MensajeObs = string.Empty;

        LGN_TB_Distribucion _lgn_Tb_Distribucion = new LGN_TB_Distribucion();

        private void FrmConfSalTiendas_Load(object sender, EventArgs e)
        {
            LlenarGrilla();
        }

        private void LlenarGrilla()
        {
            DataSet dsdatos = new DataSet();
            //lleno dataset
            dsdatos = _LGN_Tb_Tiendas.Listado_Tiendas_2();            
            try
            {
                if (dsdatos != null)
                {
                    
                    foreach(DataRow dr in dsdatos.Tables[0].Rows)
                    {
                        ListadoSalidasDisponibles.Items.Add(dr[0].ToString());                    
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
                LogError.RegistroLog(ex.Message.ToString());
                //FrmEspere.CerrarVentanaCarga(FrmEspere);
            }

        }

       private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            FrmJornada Jornadas = new FrmJornada();

            if (MessageBox.Show("Desea crear Jornada para Distribución ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (ListadoSeleccion.Items.Count != 0)
                {
                    Jornadas.ShowDialog();
                    
                    string in_jornada = Jornadas.loc_Jornada;

                    if (Generaxml(ListadoSeleccion, in_jornada))
                    {
                        MessageBox.Show("Jornada creada en forma correcta ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;                        
                    }
                    else
                    {
                        MessageBox.Show(MensajeObs, " Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;                        
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione destinos para crear jornada ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }      
            }     
        }

#region XML

        public bool Generaxml(ListBox dato, string loc_jornada)
        {
            try
            {
                XDocument documento = new XDocument(new XDeclaration("1.0", "utf-8", "no"));
                //nodo raiz
                XElement nodoraiz = new XElement("Destino");
                documento.Add(nodoraiz);
            
                //encabezado traslado
                //_ent_SgtTrasladoSTA.IdTraslado = 1000000001;
                //_ent_SgtTrasladoSTA.RutProveedor = Convert.ToInt32(TxtRutProv.Text);
                //_ent_SgtTrasladoSTA.RutSTA = Convert.ToInt32(CboServTec.SelectedValue);
            
                //Creamos el nodo cabecera
                XElement CabCombo = new XElement("CabeceraDistribucionJornadas");
                //CabCombo.Add(new XElement("IdTraslado", _ent_SgtTrasladoSTA.IdTraslado));
                //CabCombo.Add(new XElement("RutProveedor", _ent_SgtTrasladoSTA.RutProveedor));                
                nodoraiz.Add(CabCombo);

                XElement nododetalle = new XElement("DetalleDistribucionJornadas");
                CabCombo.Add(nododetalle);

                foreach ( string fila in dato.Items )
                {
                    oTablaDistribucion._DescDestino = fila.ToString().Replace("Ñ","N");
                    oTablaDistribucion._JORNADA = loc_jornada;
                                               
                    XElement DetCombo = new XElement("Detalle");                    
                    DetCombo.Add(new XElement("Destino", oTablaDistribucion._DescDestino));
                    DetCombo.Add(new XElement("Jornada", oTablaDistribucion._JORNADA));
                    DetCombo.Add(new XElement("Usuario", oUsuario));                   
                    nododetalle.Add(DetCombo);
                }

                //genera archivo xml                
                //nodoraiz.Save(@"E:\Fichero24052020.xml");                
                string xml = nodoraiz.ToString();
                bool res = false;

                //inserto los registros en la base de datos
                res = _lgn_Tb_Distribucion.CreaTablaJornadasDespacho(xml);

                if (res)
                {
                    MensajeObs = cTB_Distribucion.oMensajes;
                    return res;
                }
                else
                {
                    MensajeObs = cTB_Distribucion.oMensajes;
                    return res;                
                }                                
            }
            catch (Exception ex)
            {
                MensajeObs = ex.Message.ToString();
                return false;
            }
        }

#endregion





        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int index ;

            if (ListadoSalidasDisponibles.SelectedIndex >= 0) 
            {
                index = ListadoSalidasDisponibles.SelectedIndex;
                ListadoSeleccion.Items.Add(ListadoSalidasDisponibles.SelectedItem);
                ListadoSalidasDisponibles.Items.RemoveAt(index);
            }
        }

        private void BtnRest_Click(object sender, EventArgs e)
        {
            int index;

            if (ListadoSeleccion.SelectedIndex >= 0)
            {
                index = ListadoSeleccion.SelectedIndex;
                ListadoSalidasDisponibles.Items.Add(ListadoSeleccion.SelectedItem);
                ListadoSeleccion.Items.RemoveAt(index);
            }

        }

        private void BtnAddTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListadoSalidasDisponibles.Items.Count ; i++ )
            {
                ListadoSeleccion.Items.Add(ListadoSalidasDisponibles.Items[i]);
            }
            ListadoSalidasDisponibles.Items.Clear();           
        }

        private void BtnResTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListadoSeleccion.Items.Count; i++)
            {
                ListadoSalidasDisponibles.Items.Add(ListadoSeleccion.Items[i]);
            }
            ListadoSeleccion.Items.Clear();    
        }

        private void ListadoSalidasDisponibles_DoubleClick(object sender, EventArgs e)
        {
            int index;

            if (ListadoSalidasDisponibles.SelectedIndex >= 0)
            {
                index = ListadoSalidasDisponibles.SelectedIndex;
                ListadoSeleccion.Items.Add(ListadoSalidasDisponibles.SelectedItem);
                ListadoSalidasDisponibles.Items.RemoveAt(index);
            }

        }

        private void ListadoSeleccion_DoubleClick(object sender, EventArgs e)
        {
            int index;

            if (ListadoSeleccion.SelectedIndex >= 0)
            {
                index = ListadoSeleccion.SelectedIndex;
                ListadoSalidasDisponibles.Items.Add(ListadoSeleccion.SelectedItem);
                ListadoSeleccion.Items.RemoveAt(index);
            }
        }



       
    }
}

