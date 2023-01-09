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
    public partial class FormLogin : Form
    {
        public string senha;
        public string login;

        public FormLogin()
        {
            InitializeComponent();

            Lbl_Login.Text = "Usuário";
            Lbl_Password.Text = "Senha";
            Btn_OK.Text = "OK";
            Btn_Cancel.Text = "Cancel";
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            senha = Txt_Senha.Text;
            login = Txt_Login.Text;

            this.Close();

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void Btn_OK_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Cancel_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
