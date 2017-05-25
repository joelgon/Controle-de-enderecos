using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Controle_de_Acesso.Util
{
    class ConectaDb
    {
        private static string Servername = "localhost";
        private static string Port = "5432";
        private static string Username = "postgres";
        private static string Password = "postgres";
        private static string Database = "Condominio";

        public static NpgsqlConnection getConexao()
        {
            try
            {
                string conexao = string.Format("Server = {0}; Port = {1}; User Id = {2}; Password = {3}; Database = {4}", Servername, Port, Username, Password, Database);
                NpgsqlConnection npgsqlconexao = new NpgsqlConnection(conexao);
                npgsqlconexao.Open();
                return npgsqlconexao;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
