using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcsFedex
{
    public class cDispositivos
    {
        public string IpPLC { get; set; }
        public Int16 PortPLC { get; set; }
        public Int16 RackPLC { get; set; }
        public Int16 SlotPLC { get; set; }
        public int NumDb { get; set; }
        public string PtoCOM { get; set; }

        public static string glo_IpPLC { get; set; }
        public static Int16 glo_PortPLC { get; set; }
        public static Int16 glo_RackPLC { get; set; }
        public static Int16 glo_SlotPLC { get; set; }
        public static int glo_NumDb { get; set; }
        public static bool glo_EstadoConPLC { get; set; }
    }
}
