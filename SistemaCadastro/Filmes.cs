using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    internal class Filmes
    {
        string nome;
        string genero;
        string diretor;
        string ano;

        public string Nome { get => nome; set => nome = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Diretor { get => diretor; set => diretor = value; }
        public string Ano { get => ano; set => ano = value; }
    }
}
