using System;
using System.Windows.Forms;

namespace Proejto_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lklCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tela_Cadastro tela_Cadastro = new Tela_Cadastro();
            tela_Cadastro.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios usuarios = new Usuarios();
                usuarios.Nome = txtNome.Text;
                usuarios.Senha = txtSenha.Text;
                usuarios.Cpf = txtCpf.Text;

                if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtSenha.Text) && !string.IsNullOrEmpty(txtCpf.Text))
                {
                    if (usuarios.Logar())
                    {
                        MessageBox.Show("Usuário logado com sucesso");
                        Tela_Agenda tela_Agenda = new Tela_Agenda(usuarios);
                        tela_Agenda.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorretos");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao logar usuário: " + ex.Message);
            }
        }
    }
}
