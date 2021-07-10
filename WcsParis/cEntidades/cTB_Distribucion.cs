using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcsFedex
{
    public class cTB_Distribucion
    {
        public int Codigo { get; set; }
        public	String	_DEPOT_FROM	{get; set;}	//3
        public	String	_DEPOT_TO	{get; set;}	//3
        public	String	_ZONA	{get; set;}	//4
        public	string	_PRODUCTO	{get; set;}	//2
        public	int	_ANDEN_DESTINO	{get; set;} //
        public string _DescDestino { get; set; } //100
        public DateTime _FEC_CREA { get; set; }	
        public	String	_USUARIO_CREA	{get; set;}	
        public	DateTime	_FEC_MOD	{get; set;}	
        public	String	_USUARIO_MOD	{get; set;}
        public string _JORNADA { get; set; }

        public static string oMensajes { get; set; }

    }
}
