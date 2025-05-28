using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proejto_4
{
    internal class Contatos
    {
        private string nome;
        private string telefone;
        private string email;
        private int idUsuario;

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public bool CadastrarContato()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new BancoDB().conectar())
                {
                    string inserir = "insert into contatos (id_usuario, nome, telefone, email) values (@id_usuario, @nome, @telefone, @email)";
                    MySqlCommand comando = new MySqlCommand(inserir, conexaoBanco);
                    comando.Parameters.AddWithValue("@id_usuario", idUsuario);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@telefone", telefone);
                    comando.Parameters.AddWithValue("@email", email);

                    int resultado = comando.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no catch ao cadastrar contato: " + ex.Message);
                return false;
            }
        }
        public bool ListarContatos(DataGridView dataGrid)
        {
            try
            {
                using (MySqlConnection conexaoBanco = new BancoDB().conectar())
                {
                    // Query corrigida: filtra contatos do usuário pelo campo id_usuario
                    string listar = "SELECT * FROM contatos WHERE id_usuario = @idUsuario";
                    MySqlCommand comando = new MySqlCommand(listar, conexaoBanco);
                    comando.Parameters.AddWithValue("@idUsuario", this.idUsuario); // usa o idUsuario da instância

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                    DataTable tabela = new DataTable();
                    adaptador.Fill(tabela);
                    dataGrid.DataSource = tabela;

                    // Configurações do DataGridView
                    dataGrid.AllowUserToAddRows = false;
                    dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGrid.AutoResizeColumns();
                    dataGrid.ClearSelection();

                    return dataGrid.Rows.Count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar contatos: " + ex.Message);
                return false;
            }
        }

       
       
    }
}