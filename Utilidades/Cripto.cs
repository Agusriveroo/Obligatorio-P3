using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Cripto
    {
        public static string HashPasswordConBcrypt(string pass, int workFactor) { 
        
        
            return BCrypt.Net.BCrypt.HashPassword(pass, workFactor);

        }

        public static bool VerifyPassword(string pass, string hashPass)
        {
            return BCrypt.Net.BCrypt.Verify(pass, hashPass);
        }



    }
}
