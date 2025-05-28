using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proejto_4
{
    internal class BancoDB
    {
        private string conexaoBanco = "server=localhost; database=agenda; Uid=root; pwd=";

        public MySqlConnection conectar()
        {
            MySqlConnection conexao = new MySqlConnection(conexaoBanco);
            conexao.Open();
            return conexao;
        }
    }
}
