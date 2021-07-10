using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregadas
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

//oracle
using System.Data.OracleClient;
using System.Data.OleDb;




namespace WcsFedex
{
    public class ACD_TB_Distribucion
    {

        //SQL
        public DataSet Listado_TB_Distribucion()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("SP_Selecciona_TB_Distribucion_Fedex", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = rutsta;

                        //abrimos conexion
                        con.Open();

                        //Ejecutamos Procedimiento                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //llenar el conjunto de datos utilizando los valores predeterminados para los nombres de DataTable, etc 
                        adapter.Fill(ds);

                        //Cierre conexion
                        con.Close();
                        //retorna los datos
                        return ds;
                    }
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public DataSet Listado_TB_DistribucionFasa()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("SP_Selecciona_TB_Distribucion_Fasa", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = rutsta;

                        //abrimos conexion
                        con.Open();

                        //Ejecutamos Procedimiento                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //llenar el conjunto de datos utilizando los valores predeterminados para los nombres de DataTable, etc 
                        adapter.Fill(ds);

                        //Cierre conexion
                        con.Close();
                        //retorna los datos
                        return ds;
                    }
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public string Inserta_TB_Distribucion(cTB_Distribucion oTB_Distribucion)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Inserta_TB_Distribucion_Fedex", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@in_DEPOT_FROM", System.Data.SqlDbType.VarChar,3).Value = oTB_Distribucion._DEPOT_FROM;
                cmd.Parameters.Add("@in_DEPOT_TO", System.Data.SqlDbType.VarChar,3).Value = oTB_Distribucion._DEPOT_TO;
                cmd.Parameters.Add("@in_ZONA", System.Data.SqlDbType.VarChar, 4).Value = oTB_Distribucion._ZONA;
                cmd.Parameters.Add("@in_PRODUCTO", System.Data.SqlDbType.VarChar,2).Value = oTB_Distribucion._PRODUCTO;
                cmd.Parameters.Add("@in_ANDEN_DESTINO", System.Data.SqlDbType.Int).Value = oTB_Distribucion._ANDEN_DESTINO;
                cmd.Parameters.Add("@in_Desc_Destino", System.Data.SqlDbType.VarChar,100).Value = oTB_Distribucion._DescDestino;
                cmd.Parameters.Add("@in_Jornada", System.Data.SqlDbType.VarChar, 1).Value = oTB_Distribucion._JORNADA;                
                cmd.Parameters.Add("@in_UsuarioCrea", System.Data.SqlDbType.VarChar, 20).Value = oTB_Distribucion._USUARIO_CREA;

                //parametros de salida
                cmd.Parameters.Add("@out_Mensaje_Operacion", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@out_Mensaje_ErrorSql", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;                
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt16(cmd.Parameters["@out_Mensaje_Operacion"].Value.ToString());
                string MensajeErr = cmd.Parameters["@out_Mensaje_ErrorSql"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                if (Salida == 1)
                {
                    return "1";
                }
                else
                {
                    return MensajeErr;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        public string Editar_TB_Distribucion(cTB_Distribucion oTB_Distribucion)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("SP_Modifica_TB_Distribucion_Fedex", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@in_COD", System.Data.SqlDbType.Int).Value = oTB_Distribucion.Codigo;
                cmd.Parameters.Add("@in_DEPOT_FROM", System.Data.SqlDbType.VarChar, 3).Value = oTB_Distribucion._DEPOT_FROM;
                cmd.Parameters.Add("@in_DEPOT_TO", System.Data.SqlDbType.VarChar, 3).Value = oTB_Distribucion._DEPOT_TO;
                cmd.Parameters.Add("@in_ZONA", System.Data.SqlDbType.VarChar, 4).Value = oTB_Distribucion._ZONA;
                cmd.Parameters.Add("@in_PRODUCTO", System.Data.SqlDbType.VarChar,2).Value = oTB_Distribucion._PRODUCTO;
                cmd.Parameters.Add("@in_ANDEN_DESTINO", System.Data.SqlDbType.Int).Value = oTB_Distribucion._ANDEN_DESTINO;
                cmd.Parameters.Add("@in_Desc_Destino", System.Data.SqlDbType.VarChar,100).Value = oTB_Distribucion._DescDestino;
                cmd.Parameters.Add("@in_Jornada", System.Data.SqlDbType.VarChar, 1).Value = oTB_Distribucion._JORNADA; 
                cmd.Parameters.Add("@in_UsuarioMod", System.Data.SqlDbType.VarChar, 20).Value = oTB_Distribucion._USUARIO_MOD;

                //parametros de salida
                cmd.Parameters.Add("@out_Mensaje_Operacion", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@out_Mensaje_ErrorSql", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt16(cmd.Parameters["@out_Mensaje_Operacion"].Value.ToString());
                string MensajeErr = cmd.Parameters["@out_Mensaje_ErrorSql"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                if (Salida == 1)
                {
                    return "1";
                }
                else
                {
                    return MensajeErr;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
		
		public string Eliminar_TB_Distribucion(cTB_Distribucion oTB_Distribucion)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("[SP_Elimina_TB_Distribucion_Fedex]", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@in_COD", System.Data.SqlDbType.Int).Value = oTB_Distribucion.Codigo;

                //parametros de salida
                cmd.Parameters.Add("@out_Mensaje_Operacion", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@out_Mensaje_ErrorSql", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt16(cmd.Parameters["@out_Mensaje_Operacion"].Value.ToString());
                string MensajeErr = cmd.Parameters["@out_Mensaje_ErrorSql"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                if (Salida == 1)
                {
                    return "1";
                }
                else
                {
                    return MensajeErr;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        public bool CreaTablaJornadasDespacho(string p_xml) 
        {
            int exe = 0;
            string mensaje2;

            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("SP_INSERTA_XML_JORNADAS_FEDEX", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@PgDocXml", System.Data.SqlDbType.Xml).Value = p_xml;
                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;                
                cnx.Open();
                exe = cmd.ExecuteNonQuery();
                int pmensaje1 = Convert.ToInt32(cmd.Parameters["@Pgi_Salida"].Value);
                mensaje2 = Convert.ToString(cmd.Parameters["@pMensaje_Error"].Value);
                                
                cnx.Close();
                cnx.Dispose();

                cTB_Distribucion.oMensajes = mensaje2;

                if (pmensaje1 == 1) { return true; } else { return false; }
                
            }
            catch (Exception ex)
            {
                cTB_Distribucion.oMensajes = ex.Message.ToString();
                return false;
            }
        
        }

        public DataSet Listado_Jornadas_Disponibles()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("SP_Listado_Jornadas_Disponibles", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = rutsta;

                        //abrimos conexion
                        con.Open();

                        //Ejecutamos Procedimiento                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //llenar el conjunto de datos utilizando los valores predeterminados para los nombres de DataTable, etc 
                        adapter.Fill(ds);

                        //Cierre conexion
                        con.Close();
                        //retorna los datos
                        return ds;
                    }
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public DataSet Listado_Jornadas_EnProduccion()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("SP_Listado_Jornadas_En_Produccion", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = rutsta;

                        //abrimos conexion
                        con.Open();

                        //Ejecutamos Procedimiento                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //llenar el conjunto de datos utilizando los valores predeterminados para los nombres de DataTable, etc 
                        adapter.Fill(ds);

                        //Cierre conexion
                        con.Close();
                        //retorna los datos
                        return ds;
                    }
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public DataSet Listado_Detalle_Jornadas(int loc_corr)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("SP_Detalle_Jornadas", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@in_CorrJornada", System.Data.SqlDbType.Int).Value = loc_corr;

                        //abrimos conexion
                        con.Open();

                        //Ejecutamos Procedimiento                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //llenar el conjunto de datos utilizando los valores predeterminados para los nombres de DataTable, etc 
                        adapter.Fill(ds);

                        //Cierre conexion
                        con.Close();
                        //retorna los datos
                        return ds;
                    }
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public string Poner_Jornada_Produccion(int loc_corr, string in_usuario)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("SP_EJECUTA_JORNADAS_PRODUCCION", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@in_CorrJornada", System.Data.SqlDbType.Int).Value = loc_corr;
                cmd.Parameters.Add("@in_Usuario", System.Data.SqlDbType.VarChar, 50).Value = in_usuario;
        
                //parametros de salida
                cmd.Parameters.Add("@out_Mensaje_Operacion", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@out_Mensaje_ErrorSql", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt16(cmd.Parameters["@out_Mensaje_Operacion"].Value.ToString());
                string MensajeErr = cmd.Parameters["@out_Mensaje_ErrorSql"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                cTB_Distribucion.oMensajes = MensajeErr;

                if (Salida == 1)
                {

                    return "1";
                }
                else
                {
                    return MensajeErr;
                }

            }
            catch (Exception ex)
            {
                cTB_Distribucion.oMensajes = ex.Message.ToString();

                return ex.Message.ToString();
            }

        }

        public string Validar_Jornada_Produccion()
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("SP_EJECUTA_JORNADAS_PRODUCCION", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.Add("@in_CorrJornada", System.Data.SqlDbType.Int).Value = loc_corr;
                //cmd.Parameters.Add("@in_Usuario", System.Data.SqlDbType.VarChar, 50).Value = in_usuario;

                //parametros de salida
                cmd.Parameters.Add("@out_Mensaje_Operacion", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@out_Mensaje_ErrorSql", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt16(cmd.Parameters["@out_Mensaje_Operacion"].Value.ToString());
                string MensajeErr = cmd.Parameters["@out_Mensaje_ErrorSql"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                cTB_Distribucion.oMensajes = MensajeErr;

                if (Salida == 1)
                {

                    return "1";
                }
                else
                {
                    return MensajeErr;
                }

            }
            catch (Exception ex)
            {
                cTB_Distribucion.oMensajes = ex.Message.ToString();

                return ex.Message.ToString();
            }

        }

        public string Crear_Jornada_Automaticas()
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("SP_CREAR_JORNADAS_AUTOMATICAS", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.Add("@in_CorrJornada", System.Data.SqlDbType.Int).Value = loc_corr;
                //cmd.Parameters.Add("@in_Usuario", System.Data.SqlDbType.VarChar, 50).Value = in_usuario;

                //parametros de salida
                cmd.Parameters.Add("@out_Mensaje_Operacion", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@out_Mensaje_ErrorSql", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt16(cmd.Parameters["@out_Mensaje_Operacion"].Value.ToString());
                string MensajeErr = cmd.Parameters["@out_Mensaje_ErrorSql"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                cTB_Distribucion.oMensajes = MensajeErr;

                if (Salida == 1)
                {

                    return "1";
                }
                else
                {
                    return MensajeErr;
                }

            }
            catch (Exception ex)
            {
                cTB_Distribucion.oMensajes = ex.Message.ToString();

                return ex.Message.ToString();
            }

        }
    }

}
