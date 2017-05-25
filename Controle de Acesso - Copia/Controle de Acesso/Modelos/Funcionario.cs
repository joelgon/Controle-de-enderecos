using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controle_de_Acesso.Util;
using Npgsql;

namespace Controle_de_Acesso.Modelos
{
    class Funcionario
    {
        public string RG { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha{ get; set; }


        public Funcionario()
        {
            //vazio
        }

        public Funcionario(string RG, string Nome, string Usuario, string Senha)
        {
            this.RG = RG;
            this.Nome = Nome;
            this.Usuario = Usuario;
            this.Senha = Senha;
        }

        public void Cadastrar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "INSERT INTO funcionarios(rg, nome, usuário, senha) VALUES (@rg, @nome, @usuário, @senha)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@rg", RG));
                cmd.Parameters.Add(new NpgsqlParameter("@nome", Nome));
                cmd.Parameters.Add(new NpgsqlParameter("@usuário", Usuario));
                cmd.Parameters.Add(new NpgsqlParameter("@senha", Senha));
                cmd.ExecuteNonQuery();
            }   
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }      
        }

        public bool logar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                string usuario = Usuario;
                string senha = Senha;
                conexao = ConectaDb.getConexao();
                string sql = "SELECT * FROM funcionarios WHERE usuário = @usuário and senha = @senha";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@usuário", Usuario));
                cmd.Parameters.Add(new NpgsqlParameter("@senha", Senha));
                Usuario = "";
                Senha = "";
                cmd.ExecuteNonQuery();
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    RG = dr["rg"].ToString();
                    Nome = dr["nome"].ToString();
                    Usuario = dr["usuário"].ToString();
                    Senha = dr["senha"].ToString();
                }
                if (usuario == Usuario && senha == Senha)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }

        public List<Funcionario> listar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "Select * From funcionarios";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                List<Funcionario> newlist = new List<Funcionario>();

                while (dr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.RG = dr["rg"].ToString();
                    funcionario.Nome = dr["nome"].ToString();
                    funcionario.Usuario = dr["usuário"].ToString();
                    funcionario.Senha = dr["senha"].ToString();

                    //Add to list;
                    newlist.Add(funcionario);
                }
                return newlist;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }

        public void update()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                if (Nome != "")
                {
                    string sql = "UPDATE funcionarios SET nome = @nome WHERE rg = @rg";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                    cmd.Parameters.Add(new NpgsqlParameter("@rg", RG));
                    cmd.Parameters.Add(new NpgsqlParameter("@nome", Nome));
                    cmd.ExecuteNonQuery();
                }
                if (Usuario != "")
                {
                    string sql = "UPDATE funcionarios SET usuário = @usuário WHERE rg = @rg";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                    cmd.Parameters.Add(new NpgsqlParameter("@rg", RG));
                    cmd.Parameters.Add(new NpgsqlParameter("@usuário", Usuario));
                    cmd.ExecuteNonQuery();
                }
                if (Senha != "")
                {
                    string sql = "UPDATE funcionarios SET senha = @senha WHERE rg = @rg";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                    cmd.Parameters.Add(new NpgsqlParameter("@rg", RG));
                    cmd.Parameters.Add(new NpgsqlParameter("@senha", Senha));
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }

        public void deletar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "DELETE FROM funcionarios WHERE rg = @rg";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@rg", RG));
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }
    }
}
