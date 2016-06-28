using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerMot.Utilities
{
    public static class Security
    {
        /// Encripta una cadena
        public static string Encriptar(string cadenaAencriptar)
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaAencriptar);
            var result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(string cadenaAdesencriptar)
        {
            byte[] decryted = Convert.FromBase64String(cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            var result = Encoding.Unicode.GetString(decryted,0,decryted.Length-1);
            return result;
        }
    }
}
