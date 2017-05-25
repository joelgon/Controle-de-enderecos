using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Controle_de_Acesso.Util;

namespace Controle_de_Acesso.Modelos
{
    class Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }

        public Endereco()
        {
            //vazio
        }

        public Endereco(string Rua, int Numero)
        {
            this.Rua = Rua;
            this.Numero = Numero;
        }

        public void cadastrar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "INSERT INTO endereco (rua, numero) VALUES (@rua, @numero)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@rua", Rua));
                cmd.Parameters.Add(new NpgsqlParameter("@numero", Numero));
                cmd.ExecuteNonQuery();
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

        public List<Endereco> listar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "SELECT * FROM endereco";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                List<Endereco> newlist = new List<Endereco>();

                while (dr.Read())
                {
                    Endereco novoendereco = new Endereco();
                    novoendereco.Rua = dr["rua"].ToString();
                    novoendereco.Numero = int.Parse(dr["numero"].ToString());

                    //add to list;
                    newlist.Add(novoendereco);
                }
                return newlist;
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

        public void deletar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "DELETE FROM endereco WHERE rua = @rua and numero = @numero";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@rua", Rua));
                cmd.Parameters.Add(new NpgsqlParameter("@numero", Numero));
                cmd.ExecuteNonQuery();
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

        public List<Endereco> listarRua()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "SELECT DISTINCT rua FROM endereco";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                List<Endereco> end = new List<Endereco>();
                while (dr.Read())
                {
                    Endereco newreg = new Endereco();
                    newreg.Rua = dr["rua"].ToString();
                    //o numero não sera recuperado pq não é interesante;
                    //add to list;
                    end.Add(newreg);
                }
                return end;
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

        public List<Endereco> listarNumeros()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "SELECT numero FROM endereco WHERE rua = @rua";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@rua", Rua));
                NpgsqlDataReader dr = cmd.ExecuteReader();
                List<Endereco> end = new List<Endereco>();
                while (dr.Read())
                {
                    Endereco newObj = new Endereco();
                    newObj.Numero = int.Parse(dr["numero"].ToString());

                    //add to list;
                    end.Add(newObj);
                }
                return end;
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
