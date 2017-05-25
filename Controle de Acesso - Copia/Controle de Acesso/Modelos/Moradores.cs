using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Controle_de_Acesso.Util;

namespace Controle_de_Acesso.Modelos
{
    class Moradores
    {
        public string Rg { get; set; }
        public string Nome { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

        public Moradores()
        {
            //vazio
        }

        public Moradores(string Rg, string Nome, string Rua, int Numero)
        {
            this.Rg = Rg;
            this.Nome = Nome;
            this.Rua = Rua;
            this.Numero = Numero;
        }

        public void cadastrar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "INSERT INTO morador(rg, nome, rua, numero) VALUES (@rg, @nome, @rua, @numero)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@rg", Rg));
                cmd.Parameters.Add(new NpgsqlParameter("@nome", Nome));
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

        public List<Moradores> listarMoradores()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "SELECT * FROM morador";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                List<Moradores> newlist = new List<Moradores>();

                while (dr.Read())
                {
                    Moradores moradores = new Moradores();
                    moradores.Rg = dr["rg"].ToString();
                    moradores.Nome = dr["nome"].ToString();
                    moradores.Rua = dr["rua"].ToString();
                    moradores.Numero = int.Parse(dr["numero"].ToString());

                    newlist.Add(moradores);
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

        public void DeletarEndereco()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "DELETE FROM morador WHERE rg = @rg and rua = @rua and numero = @numero";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@rg", Rg));
                cmd.Parameters.Add(new NpgsqlParameter("@rua", Rua));
                cmd.Parameters.Add(new NpgsqlParameter("@numero", Numero));
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

        public void DeletarRegistro()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDb.getConexao();
                string sql = "DELETE FROM morador WHERE rg = @rg";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@rg", Rg));
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
    }
}
