using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace WcsFedex
{
    public class cPing
    {
        cRegistroErr oErrores = new cRegistroErr();
        public Boolean PingServidores(string _ipServer) 
        {
            Ping ping = new Ping();
            int tiempo = 1;

            try
            {

                if (ping.Send(_ipServer, tiempo).Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) 
            {
                oErrores.RegistroLog(ex.Message.ToString());
                return false;                
            }
        
        }
    }
}
