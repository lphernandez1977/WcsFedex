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
using System.Security.Cryptography;

namespace WcsFedex
{
    public partial class FrmReporteScanner : Form
    {
        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();

        DataSet dsReporte = new DataSet();
        LGN_ReportScanner _LGN_ReportScanner = new LGN_ReportScanner();
        cRegistroErr LogError = new cRegistroErr();

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

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Carton", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Fecha", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Hora Lectura", false);
            _seteaformato.CreaGrillaLimpia(dtg, 3, "Minuto Lectura", false);
            _seteaformato.CreaGrillaLimpia(dtg, 4, "Segundo Lectura", false);
            _seteaformato.CreaGrillaLimpia(dtg, 5, "Fecha Salida", false);
            _seteaformato.CreaGrillaLimpia(dtg, 6, "Hora Salida", false);
            _seteaformato.CreaGrillaLimpia(dtg, 7, "Minuto Salida", false);
            _seteaformato.CreaGrillaLimpia(dtg, 8, "Segundo Salida", false);
            _seteaformato.CreaGrillaLimpia(dtg, 9, "Kilos", true);
            _seteaformato.CreaGrillaLimpia(dtg, 10, "Rampa Destino", false);
            _seteaformato.CreaGrillaLimpia(dtg, 11, "Rampa", true);
            _seteaformato.CreaGrillaLimpia(dtg, 12, "Error", false);
            _seteaformato.CreaGrillaLimpia(dtg, 13, "Linea Recirc", false);
            _seteaformato.CreaGrillaLimpia(dtg, 14, "Observacion", false);
            _seteaformato.CreaGrillaLimpia(dtg, 15, "Resultado", true);
            _seteaformato.CreaGrillaLimpia(dtg, 16, "Destino", true);
        }

        private void GrillaLimpia2(DataGridView dtg)
        {
            dtg.DataSource = null;
            dtg.Rows.Clear();
            dtg.Columns.Clear();

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Resultado", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Cartones", true);
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

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Carton", 200, true, Alineacion.Centro.ToString(),true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Fecha", 120, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Hora Lectura", 180, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 3, "Minuto Lectura", 110, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 4, "Segundo Lectura", 50, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 5, "Fecha Salida", 120, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 6, "Hora Salida", 70, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 7, "Minuto Salida", 70, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 8, "Segundo Salida", 60, false, Alineacion.Centro.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 9, "Kilos", 50, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 10, "Rampa Destino", 180, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 11, "Rampa", 80, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 12, "Error", 50, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 13, "Linea Recirc", 80, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 14, "Observacion", 70, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 15, "Resultado", 150, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 16, "Destino", 150, true, Alineacion.Izquierda.ToString(), true);

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

        private void FormatoGrilla2(DataGridView dtg)
        {

            //***********************
            //CABECERA DE GRILLA
            //***********************
            //Permite habilitar los formatos del usuario
            DgvDatosDia.EnableHeadersVisualStyles = false;
            //oculta la columna Default de grilla
            DgvDatosDia.RowHeadersVisible = false;

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Resultado", 150, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Cartones", 100, true, Alineacion.Izquierda.ToString(), true);

            //--- Permite la Seleccion de la Fila Completa
            DgvDatosDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //--- Permite que la grilla no se pueda editar
            DgvDatosDia.ReadOnly = true;
            //--- desabilita el agrear linea
            DgvDatosDia.AllowUserToAddRows = false;
            //Permite copiar al Portapapeles (Memoria), para luego pegar... excel, bloc de notas, etc. (solo Dios y SG sabe lo que hace)
            DgvDatosDia.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DgvDatosDia.ColumnHeadersDefaultCellStyle.ForeColor = Color.Navy;

            //***********************
            //DETALLE DE GRILLA
            //***********************
            //cambia el Color de Fondo de la Grilla
            DgvDatosDia.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            //cambia el Color de Seleccion
            DgvDatosDia.DefaultCellStyle.SelectionBackColor = Color.Lime;
            //cambia el Color de fuente
            DgvDatosDia.DefaultCellStyle.SelectionForeColor = Color.Navy;
            //cambia el Tamaño y Letra de la fuente, color 
            DgvDatosDia.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8);
            DgvDatosDia.DefaultCellStyle.ForeColor = Color.Navy;
            DgvDatosDia.MultiSelect = false;

        }

        #endregion

        public FrmReporteScanner()
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

        private void FrmReporteScanner_Load(object sender, EventArgs e)
        {
            GrillaLimpia(DgvDatos);
            FormatoGrilla(DgvDatos);
            Fecha1.Value = DateTime.Now.AddDays(-1);
            Fecha2.Value = DateTime.Now.AddDays(1);
            Fecha3.Value = DateTime.Now;

            LblTotalCartones.Text = "0";

            GrillaLimpia2(DgvDatosDia);
            LlenarGrillaDia(string.Format("{0:yyyy-MM-dd}", Fecha3.Value));
            FormatoGrilla2(DgvDatosDia);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string oFechaIni = string.Format("{0:yyyy-MM-dd}", Fecha1.Value);
        
            string oFechaTer = string.Format("{0:yyyy-MM-dd}", Fecha2.Value.AddDays(1));
            
            GrillaLimpia(DgvDatos);
            LlenarGrillaConsulta(oFechaIni,oFechaTer);
            FormatoGrilla(DgvDatos);
        }
        
        private void LlenarGrillaConsulta(string oFechaIni, string oFechaTer)
        {    
            try 
            {
                dsReporte = _LGN_ReportScanner.Listado_ReportScanner(oFechaIni,oFechaTer);

                if (dsReporte.Tables[0].Rows.Count == 0) 
                {
                    MessageBox.Show("No existen registros para el rango solicitado ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dsReporte != null)
                {
                    //abrir formulario de Carga
                    //FrmEspere.AbrirVentanaCarga(FrmEspere);

                    //Elimina el enlace de datos para poder limpiar
                    this.DgvDatos.DataSource = null;

                    //limpia los datos
                    this.DgvDatos.Rows.Clear();
                    this.DgvDatos.Columns.Clear();                    
                    //asigna la informacion a la grilla                    
                    this.DgvDatos.DataSource = dsReporte.Tables[0];                   
                }
                else
                {
                    MessageBox.Show("Debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                }
            }
            catch(Exception ex)
            {
                LogError.RegistroLog(ex.Message.ToString());
            }

        }

        private void LlenarGrillaDia(string oFecha)
        {
            try
            {
                dsReporte = _LGN_ReportScanner.Listado_ReportScannerDiario(oFecha);

                if (dsReporte != null)
                {
                    //abrir formulario de Carga
                    //FrmEspere.AbrirVentanaCarga(FrmEspere);

                    //Elimina el enlace de datos para poder limpiar
                    this.DgvDatosDia.DataSource = null;

                    //limpia los datos
                    this.DgvDatosDia.Rows.Clear();
                    this.DgvDatosDia.Columns.Clear();
                    //asigna la informacion a la grilla                    
                    this.DgvDatosDia.DataSource = dsReporte.Tables[0];

                    int valor = 0;
                    foreach (DataRow dr in dsReporte.Tables[0].Rows)
                    {
                        valor += Convert.ToInt16(dr[1]);       
                    }
                    
                    LblTotalCartones.Text = String.Format("{0:#,0}", valor);
                }
                else
                {
                    //MessageBox.Show("Debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.RegistroLog(ex.Message.ToString());
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea exportar la información seleccionada ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Exportar(DgvDatos);
            }
            return;            
        }

        public void Exportar(DataGridView oInforme)
        {
            string ruta = string.Empty;
            string Carpeta = string.Empty;
            string path = string.Empty;
            string fichero = string.Empty;

            string Head0 = string.Empty;
            string Head1 = string.Empty;
            string Head2 = string.Empty;
            string Head3 = string.Empty;
            string Head4 = string.Empty;
            string Head5 = string.Empty;
            string Head6 = string.Empty;
            string Head7 = string.Empty;
            string Head8 = string.Empty;
            string Head9 = string.Empty;
            string Head10 = string.Empty;
            string Head11 = string.Empty;
            string Head12 = string.Empty;
            string Head13 = string.Empty;
            string Head14 = string.Empty;
            string Head15 = string.Empty;
            string Head16 = string.Empty;
            
            string Detalle0 = string.Empty;
            string Detalle1 = string.Empty;
            string Detalle2 = string.Empty;
            string Detalle3 = string.Empty;
            string Detalle4 = string.Empty;
            string Detalle5 = string.Empty;
            string Detalle6 = string.Empty;
            string Detalle7 = string.Empty;
            string Detalle8 = string.Empty;
            string Detalle9 = string.Empty;
            string Detalle10 = string.Empty;
            string Detalle11 = string.Empty;
            string Detalle12 = string.Empty;
            string Detalle13 = string.Empty;
            string Detalle14 = string.Empty;
            string Detalle15 = string.Empty;
            string Detalle16 = string.Empty;
                      
            if (oInforme.RowCount  == 0)
            {
                MessageBox.Show("No hay registros para exportar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ruta = Directory.GetCurrentDirectory();
                Carpeta = "ReporteScanner";

                path = ruta + @"\" + Carpeta;

                fichero = "ReportScanner_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".csv";

                if (File.Exists(path))
                {

                }
                else 
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);                
                }

                Head0 = oInforme.Columns[0].HeaderText;
                Head1 = oInforme.Columns[1].HeaderText;
                Head2 = oInforme.Columns[2].HeaderText;
                Head3 = oInforme.Columns[3].HeaderText;
                Head4 = oInforme.Columns[4].HeaderText;
                Head5 = oInforme.Columns[5].HeaderText;
                Head6 = oInforme.Columns[6].HeaderText;
                Head7 = oInforme.Columns[7].HeaderText;
                Head8 = oInforme.Columns[8].HeaderText;
                Head9 = oInforme.Columns[9].HeaderText;
                Head10 = oInforme.Columns[10].HeaderText;
                Head11 = oInforme.Columns[11].HeaderText;
                Head12 = oInforme.Columns[12].HeaderText;
                Head13 = oInforme.Columns[13].HeaderText;
                Head14 = oInforme.Columns[14].HeaderText;
                Head15 = oInforme.Columns[15].HeaderText;
                Head16 = oInforme.Columns[16].HeaderText;

                

                StreamWriter oSW = new StreamWriter(path + @"\" + fichero);
                String Linea = Head0 + ";" + Head1 + ";" + Head2 + ";" + Head3 + ";" + Head4 + ";" + Head5 + ";" + Head6 + ";" + Head7 + ";" + Head8 +";" + Head9 +";" + Head10 +";" + Head11 +";" + Head12 +";" + Head13 +";" + Head14 +";" + Head15 +";" + Head16;
                oSW.WriteLine(Linea);
                oSW.Flush();

                foreach (DataGridViewRow fila in oInforme.Rows)
                {
                    Detalle0 = fila.Cells[0].Value.ToString();
                    Detalle1 = fila.Cells[1].Value.ToString();
                    Detalle2 = fila.Cells[2].Value.ToString();
                    Detalle3 = fila.Cells[3].Value.ToString();
                    Detalle4 = fila.Cells[4].Value.ToString();
                    Detalle5 = fila.Cells[5].Value.ToString();
                    Detalle6 = fila.Cells[6].Value.ToString();
                    Detalle7 = fila.Cells[7].Value.ToString();
                    Detalle8 = fila.Cells[8].Value.ToString();
                    Detalle9 = fila.Cells[9].Value.ToString();
                    Detalle10 = fila.Cells[10].Value.ToString();
                    Detalle11 = fila.Cells[11].Value.ToString();
                    Detalle12 = fila.Cells[12].Value.ToString();
                    Detalle13 = fila.Cells[13].Value.ToString();
                    Detalle14 = fila.Cells[14].Value.ToString();
                    Detalle15 = fila.Cells[15].Value.ToString();
                    Detalle16 = fila.Cells[16].Value.ToString();

                    String Detalle = "_"+ Detalle0 + ";" + Detalle1 + ";" + Detalle2 + ";" + Detalle3 + ";" + Detalle4 + ";" + Detalle5 + ";" + Detalle6 + ";" + Detalle7 + ";" + Detalle8 + ";" + Detalle9 + ";" + Detalle10 + ";" + Detalle11 + ";" + Detalle12 + ";" + Detalle13 + ";" + Detalle14 + ";" + Detalle15 + ";" + Detalle16;
                    oSW.WriteLine(Detalle);
                    oSW.Flush();
                }
                oSW.Close();

                MessageBox.Show("Información Exportada en el fichero " + fichero, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;               
             
            }
            catch (Exception ex)
            {
                LogError.RegistroLog(ex.Message.ToString());
            }

        }

        private void FrmReporteScanner_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void DgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            //suprimo el enter
            e.SuppressKeyPress = true;  
        }

        private void DgvDatosDia_KeyDown(object sender, KeyEventArgs e)
        {
            //suprimo el enter
            e.SuppressKeyPress = true;
        }

        private void BtnSelec_Click(object sender, EventArgs e)
        {
            string oFechaIni = string.Format("{0:yyyy-MM-dd}", Fecha3.Value);

            GrillaLimpia2(DgvDatosDia);
            LlenarGrillaDia(string.Format("{0:yyyy-MM-dd}", oFechaIni));
            FormatoGrilla2(DgvDatosDia);

            
        }
    }
}
