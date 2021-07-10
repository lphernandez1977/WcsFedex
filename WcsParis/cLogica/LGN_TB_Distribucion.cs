using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace WcsFedex
{
    public class LGN_TB_Distribucion
    {
        ACD_TB_Distribucion _ACD_TB_Distribucion = new ACD_TB_Distribucion();

        public DataSet Listado_TB_Distribucion()
        {
            DataSet ds = new DataSet();

            ds = _ACD_TB_Distribucion.Listado_TB_Distribucion();
            //ds = objOracle.Listado_TB_Distribucion_ORACLE();

            return ds;

        }

        public DataSet Listado_TB_DistribucionFasa()
        {
            DataSet ds = new DataSet();
            ds = _ACD_TB_Distribucion.Listado_TB_DistribucionFasa();
            return ds;
        }

        public string Inserta_TB_Distribucion(cTB_Distribucion oTB_Distribucion)
        {
            string res = string.Empty;

            res = _ACD_TB_Distribucion.Inserta_TB_Distribucion(oTB_Distribucion);

            return res;
        }

        public string Editar_TB_Distribucion(cTB_Distribucion oTB_Distribucion)
        {
            string res = string.Empty;

            res = _ACD_TB_Distribucion.Editar_TB_Distribucion(oTB_Distribucion);
            //res = objOracle.Editar_TB_Distribucion_ORACLE(oTB_Distribucion);

            return res;
        }

        public string Eliminar_TB_Distribucion(cTB_Distribucion oTB_Distribucion)
        {
            string res = string.Empty;

            res = _ACD_TB_Distribucion.Eliminar_TB_Distribucion(oTB_Distribucion);

            return res;
        }

        public bool CreaTablaJornadasDespacho(string p_xml)
        {
            bool res = false;
            res = _ACD_TB_Distribucion.CreaTablaJornadasDespacho(p_xml);
            return true;
        }

        public DataSet Listado_Jornadas_Disponibles()
        {
            DataSet ds = new DataSet();
            ds = _ACD_TB_Distribucion.Listado_Jornadas_Disponibles();
            return ds;
        }

        public DataSet Listado_Jornadas_EnProduccion()
        {
            DataSet ds = new DataSet();
            ds = _ACD_TB_Distribucion.Listado_Jornadas_EnProduccion();
            return ds;
        }

        public DataSet Listado_Detalle_Jornadas(int loc_corr)
        {
            DataSet ds = new DataSet();
            ds = _ACD_TB_Distribucion.Listado_Detalle_Jornadas(loc_corr);
            return ds;
        }

        public string Poner_Jornada_Produccion(int loc_corr, string in_usuario)
        {
            string res;
            res = _ACD_TB_Distribucion.Poner_Jornada_Produccion(loc_corr, in_usuario);
            return res;
        }

        public string Validar_Jornada_Produccion()
        {
            string res;
            res = _ACD_TB_Distribucion.Validar_Jornada_Produccion();
            return res;
        }

        public string Crear_Jornada_Automaticas()
        {
            string res;
            res = _ACD_TB_Distribucion.Crear_Jornada_Automaticas();
            return res;
        }
    
    }
}
