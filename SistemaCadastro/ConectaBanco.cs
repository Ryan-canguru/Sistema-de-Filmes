
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaCadastro
{
    internal class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root;port=3306;password=Batista@2006;database=bancos_filmes");

        string mensagem;

        public string Mensagem
        {
            get => mensagem;
        }

        public bool insereFilme(Filmes novoFilme)
        {
            try
            {
                conexao.Open();

                MySqlCommand cmd =
                    new MySqlCommand("sp_insereFilme", conexao);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("nome", novoFilme.Nome);
                cmd.Parameters.AddWithValue("genero",
                    Convert.ToInt32(novoFilme.Genero));
                cmd.Parameters.AddWithValue("diretor", novoFilme.Diretor);
                cmd.Parameters.AddWithValue("ano",
                    Convert.ToInt32(novoFilme.Ano));

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception erro)
            {
                mensagem = erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        public DataTable listaGeneros()
        {
            MySqlCommand cmd =
                new MySqlCommand("sp_listaGeneros", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conexao.Open();

                MySqlDataAdapter da =
                    new MySqlDataAdapter(cmd);

                DataTable tabela = new DataTable();
                da.Fill(tabela);

                return tabela;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }

        public DataTable listaFilmes()
        {
            MySqlCommand cmd =
                new MySqlCommand("sp_listaFilmes", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conexao.Open();

                MySqlDataAdapter da =
                    new MySqlDataAdapter(cmd);

                DataTable tabela = new DataTable();
                da.Fill(tabela);

                return tabela;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool deletaFilme(int idRemoveFilme)
        {
            MySqlCommand cmd =
                new MySqlCommand("sp_removeFilme", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("idfilme", idRemoveFilme);

            try
            {
                conexao.Open();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
        public bool alteraFilme(Filmes filmeAlterado, int idFilme)
        {
            MySqlCommand cmd =
                new MySqlCommand("sp_alteraFilme", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("idfilme", idFilme);
            cmd.Parameters.AddWithValue("nome", filmeAlterado.Nome);
            cmd.Parameters.AddWithValue("genero",
                Convert.ToInt32(filmeAlterado.Genero));
            cmd.Parameters.AddWithValue("diretor", filmeAlterado.Diretor);
            cmd.Parameters.AddWithValue("ano",
                Convert.ToInt32(filmeAlterado.Ano));

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }


        public bool insereGenero(string novoGenero)
        {
            MySqlCommand cmd =
                new MySqlCommand("sp_insereGenero", conexao);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("genero", novoGenero);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }


        public bool verifica(string user, string pass)
        {
            string senhaHash = Bibliotecacs.makeHash(pass);

            MySqlCommand cmd = new MySqlCommand(
                "sp_consultarUsuario", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("usuario", user);
            cmd.Parameters.AddWithValue("senha", senhaHash);

            try
            {
                conexao.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }



    }
}
