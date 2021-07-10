using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace WcsParis
{
    public class LGN_Oracle
    {
        ACD_Oracle _ACD_Oracle = new ACD_Oracle();

        public DataSet Listado_Correlativo_VL_CBC_ORACLE_DS()
        {
            DataSet dsCorr = new DataSet();

            dsCorr = _ACD_Oracle.Listado_Correlativo_VL_CBC_ORACLE_DS();

            return dsCorr;
        }

        public string Inserta_VL_CBC_ORACLE(cENT_Vl_Cbc_Fdx oVl_Cbc_Fdx)
        {
            string res = string.Empty;

            res = _ACD_Oracle.Inserta_VL_CBC_ORACLE(oVl_Cbc_Fdx);

            return res;
        }

        public DataSet Listado_Correlativo_VL_CBC_SQL()
        {
            DataSet dsCorr = new DataSet();

            dsCorr = _ACD_Oracle.Listado_Correlativo_VL_CBC_SQL();

            return dsCorr;
        }
        
    }
}
