using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Proejto_4
{
    public partial class Tela_Agenda : Form
    {
        private Usuarios usuarioLogado;

        public Tela_Agenda(Usuarios usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
        }

        private void AtualizarListaContatos()
        {
            Contatos contatos = new Contatos();
            contatos.IdUsuario = usuarioLogado.Id;
            contatos.ListarContatos(dgvAgenda);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Contatos contatos = new Contatos();
                contatos.Nome = txtNome.Text;
                contatos.Telefone = txtTelefone.Text;
                contatos.Email = txtEmail.Text;
                contatos.IdUsuario = usuarioLogado.Id;

                if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtTelefone.Text) && !string.IsNullOrEmpty(txtEmail.Text))
                {
                    if (contatos.CadastrarContato())
                    {
                        MessageBox.Show("Contato cadastrado com sucesso");
                        AtualizarListaContatos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar contato");
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos antes de adicionar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no catch ao cadastrar contato: " + ex.Message);
            }
        }

        private int idContato;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow linha = dgvAgenda.Rows[e.RowIndex];
                    idContato = Convert.ToInt32(dgvAgenda.Rows[e.RowIndex].Cells["id"].Value);
                    txtNome.Text = linha.Cells["nome"].Value.ToString();
                    txtTelefone.Text = linha.Cells["telefone"].Value.ToString();
                    txtEmail.Text = linha.Cells["email"].Value.ToString();
                    txtId.Text = idContato.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar contato: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tela_Agenda_Load(object sender, EventArgs e)
        {
            AtualizarListaContatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string telefone = txtTelefone.Text;
                string email = txtEmail.Text;

                if (idContato > 0)
                {
                    if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(telefone) && !string.IsNullOrEmpty(email))
                    {
                        using (MySqlConnection conexao = new BancoDB().conectar())
                        {
                            string editar = "UPDATE contatos SET nome = @nome, telefone = @telefone, email = @email WHERE id = @id";
                            MySqlCommand comando = new MySqlCommand(editar, conexao);

                            comando.Parameters.AddWithValue("@nome", nome);
                            comando.Parameters.AddWithValue("@telefone", telefone);
                            comando.Parameters.AddWithValue("@email", email);
                            comando.Parameters.AddWithValue("@id", idContato);

                            int resultado = comando.ExecuteNonQuery();

                            if (resultado > 0)
                            {
                                MessageBox.Show("Contato editado com sucesso!");
                                AtualizarListaContatos();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum contato foi alterado.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha todos os campos antes de editar.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um contato primeiro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados! " + ex.Message);
            }
        }

        

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (idContato > 0)
                {


                    var resultad = MessageBox.Show("Você quer excluir esse contato?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                    if (resultad == DialogResult.Yes)
                    {
                        using (MySqlConnection conexao = new BancoDB().conectar())
                        {
                            string excluir = "Delete from contatos where id = @id;";
                            MySqlCommand comando = new MySqlCommand(excluir, conexao);

                            comando.Parameters.AddWithValue("@id", idContato);

                            comando.ExecuteNonQuery();
                            AtualizarListaContatos();

                            MessageBox.Show("contato excluido com sucesso.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("contato não foi excluido.");
                    }

                }
                else
                {
                    MessageBox.Show("Selecione um contato");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao excluir Produto!" + ex.Message);
            }
        }
    }
}
