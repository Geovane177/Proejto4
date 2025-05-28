using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proejto_4
{
    public class Usuarios
    {
        private int id;
        private string nome;
        private string senha;
        private string cpf;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public bool CadastrarUsuario()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new BancoDB().conectar())
                {
                    string inserir = "insert into usuarios (nome, senha, cpf) values (@nome, @senha, @cpf)";
                    MySqlCommand comando = new MySqlCommand(inserir, conexaoBanco);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@senha", senha);
                    comando.Parameters.AddWithValue("@cpf", cpf);

                    int resultado = comando.ExecuteNonQuery();

                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no catch ao cadastrar usuario: " + ex.Message);
                return false;
            }
        }

        public bool Logar()
        {
            try
            {
                using (MySqlConnection conexao = new BancoDB().conectar())
                {
                    string query = "select id from usuarios where nome = @nome and senha = @senha and cpf = @cpf";
                    MySqlCommand comando = new MySqlCommand(query, conexao);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@senha", senha);
                    comando.Parameters.AddWithValue("@cpf", cpf);

                    object resultado = comando.ExecuteScalar();
                    if (resultado != null)
                    {
                        id = Convert.ToInt32(resultado);
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no catch ao logar usuario: " + ex.Message);
                return false;
            }
        }
    }
}
