namespace Proejto_4
{
    partial class Tela_Cadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lklLogin = new LinkLabel();
            btnCadastro = new Button();
            txtCpf = new TextBox();
            txtSenha = new TextBox();
            txtNome = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // lklLogin
            // 
            lklLogin.AutoSize = true;
            lklLogin.Location = new Point(328, 359);
            lklLogin.Name = "lklLogin";
            lklLogin.Size = new Size(181, 15);
            lklLogin.TabIndex = 17;
            lklLogin.TabStop = true;
            lklLogin.Text = "Já possui uma conta? logue aqui!";
            lklLogin.LinkClicked += lklLogin_LinkClicked;
            // 
            // btnCadastro
            // 
            btnCadastro.Location = new Point(373, 309);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(96, 23);
            btnCadastro.TabIndex = 16;
            btnCadastro.Text = "Cadastre-se";
            btnCadastro.UseVisualStyleBackColor = true;
            btnCadastro.Click += btnCadastro_Click;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(373, 252);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(100, 23);
            txtCpf.TabIndex = 15;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(373, 210);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(100, 23);
            txtSenha.TabIndex = 14;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(373, 168);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(279, 260);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 12;
            label4.Text = "CPF";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(281, 218);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 11;
            label3.Text = "Senha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(279, 171);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 10;
            label2.Text = "Nome";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(373, 76);
            label1.Name = "label1";
            label1.Size = new Size(163, 33);
            label1.TabIndex = 9;
            label1.Text = "CADASTRO";
            // 
            // Tela_Cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lklLogin);
            Controls.Add(btnCadastro);
            Controls.Add(txtCpf);
            Controls.Add(txtSenha);
            Controls.Add(txtNome);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Tela_Cadastro";
            Text = "Tela_Cadastro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel lklLogin;
        private Button btnCadastro;
        private TextBox txtCpf;
        private TextBox txtSenha;
        private TextBox txtNome;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}