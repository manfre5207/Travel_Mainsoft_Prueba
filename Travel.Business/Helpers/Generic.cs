using System.Security.Cryptography;
using System.Text;

namespace Travel.Business.Helpers
{
    /// <summary>
    /// Clase genérica estática de métodos comunes para todas las clases.
    /// </summary>
    public static class Generic
    {
        /// <summary>
        /// Métodos para encriptar la contraseña.
        /// <param name="text">Recibe el password desde el controller.</param>
        /// </summary>
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
