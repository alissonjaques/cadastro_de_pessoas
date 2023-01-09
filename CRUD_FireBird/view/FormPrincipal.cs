using CadastroDePessoas.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDePessoas.view
{
    public partial class FormPrincipal : Form
    {
        int ControleCadastroDePessoas = 0;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void byteBankToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ControleCadastroDePessoas == 0)
            {
                ControleCadastroDePessoas += 1;
                FormCadastroDePessoas U = new FormCadastroDePessoas();
                U.Dock = DockStyle.Fill;
                U.TopLevel = false;
                U.Visible = true;
                TabPage TB = new TabPage();
                TB.Name = "Cadastro de Pessoas";
                TB.Text = "Cadastro de Pessoas";
                TB.ImageIndex = 7;                
                TB.Controls.Add(U);
                Tbc_Aplicacoes.TabPages.Add(TB);
            }
            else
            {
                MessageBox.Show("Não posso abrir o Cadastro de Clientes porque já está aberto.", "Banco ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin F = new FormLogin();
            F.ShowDialog();

            if (F.DialogResult == DialogResult.OK)
            {

                string senha = F.senha;
                string login = F.login;

                if (BibliotecaDeMetodos.ValidaSenhaLogin(login,senha) == true)
                {
                    pessoasToolStripMenuItem.Enabled = true;
                    apagarAbaToolStripMenuItem.Enabled = true;
                    conectarToolStripMenuItem.Enabled = false;
                    cadastrosToolStripMenuItem.Enabled = true;

                    MessageBox.Show("Bem vindo " + login + " !", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Senha inválida !", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        void ApagaAba(TabPage TB)
        {
            if (TB.Name == "Cadastro de Pessoas")
            {
                ControleCadastroDePessoas = 0;
            }
            Tbc_Aplicacoes.TabPages.Remove(TB);
        }

       
        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void apagarAbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(Tbc_Aplicacoes.SelectedTab == null))
            {
                ApagaAba(Tbc_Aplicacoes.SelectedTab);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
