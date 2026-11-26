using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    internal class Bibliotecacs
    {
        // gerar hash senha
        public static string makeHash(string rawData)
        {
            // Cria instância SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //recebe gera hash
                byte[] bytes = sha256Hash.ComputeHash(
                    Encoding.UTF8.GetBytes(rawData));

                //converte array em string
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }


    }
}
