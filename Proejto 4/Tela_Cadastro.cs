using System;
using System.Windows.Forms;

namespace Proejto_4
{
    public partial class Tela_Cadastro : Form
    {
        public Tela_Cadastro()
        {
            InitializeComponent();
        }

        private void lklLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Nome = txtNome.Text;
            usuarios.Senha = txtSenha.Text;
            usuarios.Cpf = txtCpf.Text;

            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtSenha.Text) && !string.IsNullOrEmpty(txtCpf.Text))
            {
                if (usuarios.CadastrarUsuario())
                {
                    MessageBox.Show("Usuário cadastrado com sucesso");
                    Tela_Agenda tela_Agenda = new Tela_Agenda(usuarios);
                    tela_Agenda.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Falha ao cadastrar usuário");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }
    }
}
