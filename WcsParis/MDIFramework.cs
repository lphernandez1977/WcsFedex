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
using System.Configuration;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Reflection;

namespace WcsFedex
{
    public partial class MDIFramework : Form
    {
        //PLC
        private Plc oPLC = null;

        private cEntidades.cEnums.ExceptionCode errorcode;
        bool EstadoPLC = false;
        bool stop = true;
        //bool stopHora = false;
        bool EstadoTMP = false;
        //bool EstadoTMPHora = false;
        //bool spFlag = false;
        //bool spEscribeString = false;
        //bool spEscribeEntero = false;
        string COM = string.Empty;

        //registro log
        cRegistroErr RegErrores = new cRegistroErr();
        cConexionIP oConexionIP = new cConexionIP();

        private LGN_TipoDespacho _lgn_tipodespacho = new LGN_TipoDespacho();

        //conectar PTO COM
        //SerialPort spPuertoSerie = new SerialPort("COM1");

        //ping
        private cPing ping = new cPing();

        //timer plc
        private static System.Threading.Timer temporizador = null;
               
        #region ENTIDADES
        public cDispositivos oDirecciones = new cDispositivos();
        public cTagPlc oTagPLC = new cTagPlc();
        private cEnt_Server oServer = new cEnt_Server();
        private cTb_Lectura_Cartones oLecturaCartones = new cTb_Lectura_Cartones();        
        #endregion

        #region LOGICA
        private cLogica.cServer lServer = new cLogica.cServer();
        //private LGN_ListadoSensores _LGN_ListadoSensores = new LGN_ListadoSensores();
        private LGN_Insertar_Lecturas _LGN_Insertar_Lecturas = new LGN_Insertar_Lecturas();
        private LGN_TB_Distribucion _lgn_Tb_Distribucion = new LGN_TB_Distribucion();

        #endregion

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

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Lectura", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Salida", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Etiqueta", true);
            _seteaformato.CreaGrillaLimpia(dtg, 3, "Fecha", true);
            _seteaformato.CreaGrillaLimpia(dtg, 4, "Kilos", true);
            _seteaformato.CreaGrillaLimpia(dtg, 5, "Volumen", false);
            _seteaformato.CreaGrillaLimpia(dtg, 6, "RAMPA_SAL_SORTER", false);
            _seteaformato.CreaGrillaLimpia(dtg, 7, "Destino", false);
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

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Lectura", 60, true, Alineacion.Centro.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Salida", 60, true, Alineacion.Centro.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Etiqueta", 180, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 3, "Fecha", 110, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 4, "Kilos", 50, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 5, "Volumen", 70, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 6, "RAMPA_SAL_SORTER", 70, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 7, "Destino", 70, false, Alineacion.Izquierda.ToString(), true);

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

        #region Temporizador_PLC

        private void OnStart()
        {
            stop = false;
            TimerCallback tcb = new TimerCallback(OnElapsedTime);
            temporizador = new System.Threading.Timer(tcb, null, 500, 1000);
            EstadoTMP = true;
        }

        private void OnElapsedTime(Object stateInfo)
        {
            //TareasHilo();
            FechaHoraServer();
        }

        private void OnStop()
        {
            //stop = true;            
            //temporizador.Change(Timeout.Infinite, Timeout.Infinite);
            //temporizador.Dispose();
            //EstadoTMP = false;

            stop = true;
            EstadoTMP = false;

            if (temporizador != null)
                temporizador.Dispose()
            ;
        }

        private void TareasHilo() 
        {
            //OnStop();
           
            if (ping.PingServidores(oDirecciones.IpPLC))
            {
                //si estoy conectado al PLC 
                if (EstadoPLC)
                {                    
                    ////funcion lee estado start/stop
                    LecturaEstadoPLC();

                    PanelControl();

                    ////funcion lee emergencias
                    LeerEmergencias();

                    ////funcion lee emergencia full line
                    LeerFullLine();
                }
                else
                {
                    if (ping.PingServidores(oDirecciones.IpPLC))
                    {
                        cConPLC();
                        this.ToolEstadoPlc.Text = "En Linea";
                        ToolEstadoPlc.ForeColor = Color.Green;
                    }
                    else
                    {
                        this.ToolEstadoPlc.Text = "Desconectado";
                        ToolEstadoPlc.ForeColor = Color.Red;
                        RegErrores.RegistroLog("IP " + oDirecciones.IpPLC + " No esta disponible");
                    }

                }

            }
            else
            {
                EstadoPLC = false;
                cDispositivos.glo_EstadoConPLC = EstadoPLC;
                this.ToolEstadoPlc.Text = "Desconectado";
                ToolEstadoPlc.ForeColor = Color.Red;
                RegErrores.RegistroLog("IP " + oDirecciones.IpPLC + " No esta disponible");
            }
                    

           

            //OnStart();
        }

        #endregion 

        #region TEMPORIZADOR_DBA
        //private void OnStartDBA()
        //{          
        //    TimerCallback tick = new TimerCallback(ProcDBA);
        //    tempoDBA = new System.Threading.Timer(tick, null, 3000, 10000);
        //}

        //private void ProcDBA(Object stateInfo)
        //{
        //    OnStopDBA();

        //    GrillaLimpia(DgvDatos);
        //    LlenarGrillaTempo();
        //    FormatoGrilla(DgvDatos);

        //    OnStartDBA();
        //}

        //private void OnStopDBA()
        //{

        //    if (tempoDBA != null)
        //        tempoDBA.Dispose();
        //}

        #endregion

        #region CONECTAR PLC
        
        private void cConPLC()
        {
            try
            {               
                oPLC = new Plc(CpuType.S71200, oDirecciones.IpPLC, oDirecciones.RackPLC, oDirecciones.SlotPLC);

                oPLC.Open();

                EstadoPLC = oPLC.IsConnected;
                
                cDispositivos.glo_EstadoConPLC = EstadoPLC;

                if (EstadoPLC)
                {
                    this.ToolEstadoPlc.Text = "Conectado";
                    ToolEstadoPlc.ForeColor = Color.Green;
   
                }
                else
                {
                    this.ToolEstadoPlc.Text = "Desconectado";
                    ToolEstadoPlc.ForeColor = Color.Red;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ToolEstadoPlc.Text = "Desconectado";
                ToolEstadoPlc.ForeColor = Color.Red;
                RegErrores.RegistroLog(ex.Message.ToString());                
            }
        }
        
        #endregion                                                                                                    

        #region LIMPIAR-PLC

        private void LimpiarPLC(int startbyte)
        {
            //BORRAR VALORES PLC
            byte[] db1Bytes = new byte[16];
            oPLC.WriteBytes(DataType.DataBlock, 1, startbyte, db1Bytes);
        }

        #endregion

        public MDIFramework()
        {
            InitializeComponent();

            //para que hilo trabaje con elementos
            CheckForIllegalCrossThreadCalls = false;
        }
      
        private void MDIFramework_Load(object sender, EventArgs e)
        {
            label18.Visible = false;

            FrmInicio frm = new FrmInicio();
            frm.MdiParent = this;
            frm.Show();
            
            GrillaLimpia(DgvDatos);
            LlenarGrilla();
            FormatoGrilla(DgvDatos);

            LblEstado.Visible = false;

            PbStart.Visible = false;
            PbStop.Visible = false;

            BtnStart.Visible = false;
            BtnStop.Visible = false;

            //emergencias
            Emergencia1.Visible = false;
            Emergencia2.Visible = false;
            Emergencia3.Visible = false;
            LblEmer1.Visible = false;
            LblEmer2.Visible = false;
            LblEmer3.Visible = false;

            //Full Line
            FullLine1.Visible = false;
            FullLine2.Visible = false;
            FullLine3.Visible = false;
            FullLine4.Visible = false;
            FullLine5.Visible = false;
            FullLine6.Visible = false;
            FullLine7.Visible = false;
            FullLine8.Visible = false;

            FullLine1Est.Visible = false;
            FullLine2Est.Visible = false;
            FullLine3Est.Visible = false;
            FullLine4Est.Visible = false;
            FullLine5Est.Visible = false;
            FullLine6Est.Visible = false;
            FullLine7Est.Visible = false;
            FullLine8Est.Visible = false;
      
            Direcciones();

            Application.DoEvents();

            Application.DoEvents();

            Application.DoEvents();
           
            frm.Close();

            label18.Visible = true;
                      
            //fecha server
            FechaHoraServer();

            ToolEstadoPlc.Text = "Iniciando......";

            if (ping.PingServidores(oDirecciones.IpPLC))
            {
                cConPLC();
                this.ToolEstadoPlc.Text = "En Linea";
                ToolEstadoPlc.ForeColor = Color.Green;
            }
            else
            {
                this.ToolEstadoPlc.Text = "Desconectado";
                ToolEstadoPlc.ForeColor = Color.Red;
            }

            //INICIAR TEMPORIZADOR FECHA HORA
            OnStart();
                                                 
            this.Show();

            Tempo.Enabled = true;
            Tempo.Interval = 1000;
            Thread.Sleep(5000);
            Tempo.Start();

            //valido tipo despacho si existe
            TipoDespacho();

            //validar si hay jornadas cargadas en produccion
            ListadoJornadaEnProduccion();

            if (cEnt_TB_Tipo_Despacho.glo_CodTipoDespacho == 0)
            {
                MessageBox.Show("Debe Asignar Tipo Despacho, para distribuir cajas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void ListadoJornadaEnProduccion() 
        {
            DataSet dsdatos = new DataSet();
            string res = string.Empty;

            //lleno dataset
            dsdatos = _lgn_Tb_Distribucion.Listado_Jornadas_EnProduccion();

            //VALIDO QUE NO EXISTAN REGISTROS DE TABLA JORNADA PRODUCCION
            if (dsdatos.Tables[0].Rows.Count == 0) 
            {
                res = _lgn_Tb_Distribucion.Crear_Jornada_Automaticas();

                if (res == "1")
                {
                    RegErrores.RegistroLog(cTB_Distribucion.oMensajes);
                }
                else 
                {
                    RegErrores.RegistroLog(cTB_Distribucion.oMensajes);
                    MessageBox.Show(cTB_Distribucion.oMensajes, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }
        }

        private void TipoDespacho()
        {
            DataSet dsTipo = new DataSet();
            dsTipo = _lgn_tipodespacho.Listado_TipoDespacho();
            if (dsTipo != null)
            {
                foreach (DataRow fila in dsTipo.Tables[0].Rows)
                {
                    cEnt_TB_Tipo_Despacho.glo_CodTipoDespacho = Convert.ToInt32(fila[0]);
                    LblTipoDesp.Text = cEnt_TB_Tipo_Despacho.glo_CodTipoDespacho.ToString();
                }
            }
        }

        private void Direcciones()
        {
            oDirecciones.IpPLC = ConfigurationManager.AppSettings["IpPCL"].ToString();
            oDirecciones.PortPLC = Convert.ToInt16(ConfigurationManager.AppSettings["PortPLC"].ToString());
            oDirecciones.RackPLC = Convert.ToInt16(ConfigurationManager.AppSettings["RackPLC"].ToString());
            oDirecciones.SlotPLC = Convert.ToInt16(ConfigurationManager.AppSettings["SlotPLC"].ToString());
            oDirecciones.NumDb = Convert.ToInt16(ConfigurationManager.AppSettings["NumDb"].ToString());

            cDispositivos.glo_IpPLC = oDirecciones.IpPLC;
            cDispositivos.glo_PortPLC = oDirecciones.PortPLC;
            cDispositivos.glo_RackPLC = oDirecciones.RackPLC;
            cDispositivos.glo_SlotPLC = oDirecciones.SlotPLC;
            cDispositivos.glo_NumDb = oDirecciones.NumDb;
            

        }

        private void FechaHoraServer() 
        {
            try 
            { 
                ToolFechaHora.Text = lServer.RecuperaFechaServidor(); 
            }            
            catch (Exception ex) 
            {
             MessageBox.Show(ex.Message.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
             RegErrores.RegistroLog(ex.Message.ToString());          
            }
                       
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 60;
            frmloguin.MdiParent = this;
            frmloguin.Show();
         }

        private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 70;
            frmloguin.MdiParent = this;
            frmloguin.Show();
        }

        private void toolsMenu_Click(object sender, EventArgs e)
        {            
            if (EstadoPLC){oPLC.Close();}            
            this.Close();
        }

        private void pruebaDeCaídasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 80;
            frmloguin.MdiParent = this;
            frmloguin.Show();
        }

        private void calibraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 90;
            frmloguin.MdiParent = this;
            frmloguin.Show();
        }    

        private void mantenedorUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {     
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 1;
            frmloguin.MdiParent = this;
            frmloguin.Show();
           
        }

        private void mantenedorTiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 2;
            frmloguin.MdiParent = this;
            frmloguin.Show();
        }

        private void mantenedorLineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 3;
            frmloguin.MdiParent = this;
            frmloguin.Show();
        }

        private void configuraciónSalidasTiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 4;
            frmloguin.MdiParent = this;
            frmloguin.Show();
        }

        private void configuraciónOlasTiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 5;
            frmloguin.MdiParent = this;
            frmloguin.Show();
        }

#region JOB TEMPORIZADOR
        private void Tarea()
        {               

            ///Fecha y hora server
            FechaHoraServer();

            //si estoy conectado al PLC 
            if (EstadoPLC)
            {

                ////funcion lee estado start/stop
                LecturaEstadoPLC();

                PanelControl();

                ////funcion lee emergencias
                LeerEmergencias();

                ////funcion lee emergencia full line
                LeerFullLine();
            }


            GrillaLimpia(DgvDatos);
            LlenarGrilla();
            FormatoGrilla(DgvDatos);
        }

        private void TempoNormal_Tick(object sender, EventArgs e)
        {
            Tarea();
            //TareasHilo();
        }
        #endregion

        private void MDIFramework_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (EstadoPLC) { oPLC.Close(); }
            
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //valido tipo despacho si existe
            TipoDespacho();

            if (cEnt_TB_Tipo_Despacho.glo_CodTipoDespacho == 0)
            {
                MessageBox.Show("Debe Asignar Tipo Despacho, para distribuir cajas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Desea encender sorter?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    oPLC.Write("DB1.DBX0.0", true);

                    //Thread.Sleep(150);

                    oPLC.Write("DB1.DBX0.0", false);



                    MessageBox.Show("sorter se encuentra funcionando", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }                                         
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Desea detener sorter?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    oPLC.Write("DB1.DBX0.1", true);

                    //Thread.Sleep(150);

                    oPLC.Write("DB1.DBX0.1", false);


                    MessageBox.Show("sorter se encuentra detenido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }   
        }

        private void reporteScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 6;
            frmloguin.MdiParent = this;
            frmloguin.Show();                                 
        }

        private void recuperarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRecuperarPass frmRecupera = new FrmRecuperarPass();
            frmRecupera.ShowDialog();
        }

#region CONTROLES
        private void PanelControl()
        {

            if (oTagPLC.bool157)
            {
                PbStart.Visible = true;
                PbStop.Visible = false;

                BtnStop.Visible = true;
                BtnStart.Visible = false;

                LblEstado.Visible = true;
                LblEstado.Text = "Funcionando";
                LblEstado.ForeColor = Color.Green;
            }

            else
            {
                PbStart.Visible = false;
                PbStop.Visible = true;

                LblEstado.Visible = true;
                LblEstado.Text = "Detenido";
                LblEstado.ForeColor = Color.Red;

                BtnStop.Visible = false;
                BtnStart.Visible = true;
            }
        }

        private void LeerEmergencias()
        {
            try
            {
                oTagPLC.Emergencia1 = (bool)oPLC.Read("DB1.DBX0.2");
                oTagPLC.Emergencia2 = (bool)oPLC.Read("DB1.DBX0.3");
                //oTagPLC.Emergencia3 = (bool)oPLC.Read("DB8.DBX1.1");
            }

            catch (Exception ex)
            {
                RegErrores.RegistroLog(ex.Message.ToString() + " funcion LeerEmergencias");
            }

            if (oTagPLC.Emergencia1)
            {
                Emergencia1.Visible = false;
                LblEmer1.Visible = false;
                //LblEmer1.Text = "Emergencia 1 Encendida";
            }
            else
            {
                Emergencia1.Visible = true;
                LblEmer1.Visible = true;
                LblEmer1.Text = "Emergencia Panel";
            }

            if (oTagPLC.Emergencia2)
            {
                Emergencia2.Visible = false;
                LblEmer2.Visible = false;
                //LblEmer2.Text = "Emergencia 2 Encendida";
            }
            else
            {
                Emergencia2.Visible = true;
                LblEmer2.Visible = true;
                LblEmer2.Text = "Emergencia Campo";
            }

        }

        private void LecturaEstadoPLC()
        {
            try
            {
                //indica estado PLC
                //1 CORRIENDO
                //0 DETENIDO
                oTagPLC.bool157 = (bool)oPLC.Read("DB2.DBX0.1");
            }
            catch (Exception ex)
            {
                RegErrores.RegistroLog(ex.Message.ToString() + " funcion LecturaEstadoPLC");
            }


        }

        private void LeerFullLine()
        {
            try
            {
                oTagPLC.FullLine1 = (bool)oPLC.Read("DB2.DBX28.1");
                oTagPLC.FullLine2 = (bool)oPLC.Read("DB2.DBX28.2");
                oTagPLC.FullLine3 = (bool)oPLC.Read("DB2.DBX28.3");
                oTagPLC.FullLine4 = (bool)oPLC.Read("DB2.DBX28.4");
                oTagPLC.FullLine5 = (bool)oPLC.Read("DB2.DBX28.5");
                oTagPLC.FullLine6 = (bool)oPLC.Read("DB2.DBX28.6");
                oTagPLC.FullLine7 = (bool)oPLC.Read("DB2.DBX28.7");
                oTagPLC.FullLine8 = (bool)oPLC.Read("DB2.DBX28.0");
            }
            catch (Exception ex)
            {
                RegErrores.RegistroLog(ex.Message.ToString() + " funcion LeerFullLine");
            }

            if (oTagPLC.FullLine1)
            {
                FullLine1.Visible = true;
                FullLine1Est.Visible = true;
                FullLine1Est.Text = "Linea Full 1";
            }
            else
            {
                FullLine1.Visible = false;
                FullLine1Est.Visible = false;
                //FullLine1Est.Text = "Emergencia Panel Encendida";
            }

            if (oTagPLC.FullLine2)
            {
                FullLine2.Visible = true;
                FullLine2Est.Visible = true;
                FullLine2Est.Text = "Linea Full 2";
            }
            else
            {
                FullLine2.Visible = false;
                FullLine2Est.Visible = false;
                //LblEmer2.Text = "Emergencia Botoneras Encendida";
            }

            if (oTagPLC.FullLine3)
            {
                FullLine3.Visible = true;
                FullLine3Est.Visible = true;
                FullLine3Est.Text = "Linea Full 3";
            }
            else
            {
                FullLine3.Visible = false;
                FullLine3Est.Visible = false;
                //FullLine3Est.Text = "Emergencia 3 Encendida";
            }

            if (oTagPLC.FullLine4)
            {
                FullLine4.Visible = true;
                FullLine4Est.Visible = true;
                FullLine4Est.Text = "Linea Full 4";
            }
            else
            {
                FullLine4.Visible = false;
                FullLine4Est.Visible = false;
                //FullLine3Est.Text = "Emergencia 3 Encendida";
            }

            if (oTagPLC.FullLine5)
            {
                FullLine5.Visible = true;
                FullLine5Est.Visible = true;
                FullLine5Est.Text = "Linea Full 5";
            }
            else
            {
                FullLine5.Visible = false;
                FullLine5Est.Visible = false;
                //FullLine3Est.Text = "Emergencia 3 Encendida";
            }

            if (oTagPLC.FullLine6)
            {
                FullLine6.Visible = true;
                FullLine6Est.Visible = true;
                FullLine6Est.Text = "Linea Full 6";
            }
            else
            {
                FullLine6.Visible = false;
                FullLine6Est.Visible = false;
            }

            if (oTagPLC.FullLine7)
            {
                FullLine7.Visible = true;
                FullLine7Est.Visible = true;
                FullLine7Est.Text = "Linea Full 7";
            }
            else
            {
                FullLine7.Visible = false;
                FullLine7Est.Visible = false;
            }

            if (oTagPLC.FullLine8)
            {
                FullLine8.Visible = true;
                FullLine8Est.Visible = true;
                FullLine8Est.Text = "Sorter Lleno";
            }
            else
            {
                FullLine8.Visible = false;
                FullLine8Est.Visible = false;
            }

        }

        #endregion

        private void LlenarGrilla()
        {           
            DataSet dsdatos = new DataSet();

            //lleno dataset
            dsdatos = _LGN_Insertar_Lecturas.Listado_CartonesLeidos();

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
                    GrillaLimpia(DgvDatos);
                    FormatoGrilla(DgvDatos);
                }
            }
            catch (Exception ex)
            {

                RegErrores.RegistroLog(ex.Message.ToString());                
                //FrmEspere.CerrarVentanaCarga(FrmEspere);
            }

        }

        private void LlenarGrillaTempo()
        {
            DataSet dsdatos2 = new DataSet();

            //lleno dataset
            dsdatos2 = _LGN_Insertar_Lecturas.Listado_CartonesLeidos();
            
            try
            {
                if (dsdatos2 != null)
                {
                    //DataGridView DgvDatos = new DataGridView();

                    //Elimina el enlace de datos para poder limpiar
                    this.DgvDatos.DataSource = null;

                    //limpia los datos
                    this.DgvDatos.Rows.Clear();
                    this.DgvDatos.Columns.Clear();
                   
                    //asigna la informacion a la grilla                    
                    this.DgvDatos.DataSource = dsdatos2.Tables[0];

                }
                else
                {
                    GrillaLimpia(DgvDatos);
                    FormatoGrilla(DgvDatos);
                }
            }
            catch (Exception ex)
            {

                RegErrores.RegistroLog(ex.Message.ToString());
                //FrmEspere.CerrarVentanaCarga(FrmEspere);
            }

        }

        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mantenedorDTDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 8;
            frmloguin.MdiParent = this;
            frmloguin.Show();
        }

        private void mantenedorTablaDistribuciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 9;
            frmloguin.MdiParent = this;
            frmloguin.Show();
        }

        private void Tempo_Tick(object sender, EventArgs e)
        {
            Tempo.Stop();

            TareasHilo();

            GrillaLimpia(DgvDatos);            
            LlenarGrillaTempo();
            FormatoGrilla(DgvDatos);

            for (int i = 0; i < DgvDatos.RowCount; i++)
            {
                if (i == 0)
                {
                    LblSalida.Text = DgvDatos.Rows[i].Cells[1].Value.ToString();
                    LblCarton.Text = DgvDatos.Rows[i].Cells[2].Value.ToString();
                    LblbPeso.Text = DgvDatos.Rows[i].Cells[4].Value.ToString();
                    LblSalidaCli.Text = DgvDatos.Rows[i].Cells[6].Value.ToString();
                    LblNomDestino.Text = DgvDatos.Rows[i].Cells[7].Value.ToString();                    
                }
            }

            TipoDespacho();

            Tempo.Start();
        }

        private void mantenedorTipoDespachoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 10;
            frmloguin.MdiParent = this;
            frmloguin.Show();
        }

        private void mantenedorDivertoresToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 11;
            frmloguin.MdiParent = this;
            frmloguin.Show();                 
        }

        private void asignarJornadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoguin frmloguin = new FrmLoguin();
            frmloguin.oSistemas.Cod_Sistema = 12;
            frmloguin.MdiParent = this;
            frmloguin.Show(); 

        }


      
    }
}
