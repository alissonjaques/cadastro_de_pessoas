using System;
using System.Windows.Forms;

namespace CadastroDePessoas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            preencheGrid();
        }
        //
        private void preencheGrid()
        {
            try
            {
                dgvCientes.DataSource = AcessoFB.fb_GetDados().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        //
        private void btnNovo_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.ID = Convert.ToInt32(txtID.Text);
            cliente.Nome = txtNome.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Email = txtEmail.Text;

            try
            {
                AcessoFB.fb_InserirDados(cliente);
                preencheGrid();
                MessageBox.Show("Cliente inserido com sucesso !", "Inserir", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        //
        private void dgvCientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente cliente = new Cliente();
            try
            {
                int codigo = Convert.ToInt32(dgvCientes.Rows[e.RowIndex].Cells[0].Value);
                cliente = AcessoFB.fb_ProcuraDados(codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
            preencheDados(cliente);
        }
        //
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            try
            {
                int codigo = (int)Int64.Parse(txtID.Text);
                cliente = AcessoFB.fb_ProcuraDados(codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
            preencheDados(cliente);
        }
        //
        private void preencheDados(Cliente cli)
        {
            txtID.Text = cli.ID.ToString();
            txtNome.Text = cli.Nome;
            txtEndereco.Text = cli.Endereco;
            txtTelefone.Text = cli.Telefone;
            txtEmail.Text = cli.Email;
        }
        //
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            foreach (Control myControl in groupBox1.Controls)
            {
                if (myControl as TextBox == null)
                { }
                else
                {
                    ((TextBox)myControl).Text = "";
                }
            }
            txtID.Focus();
        }
        //
        private void btnAltera_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.ID = Convert.ToInt32(txtID.Text);
                cliente.Nome = txtNome.Text;
                cliente.Endereco = txtEndereco.Text;
                cliente.Telefone = txtTelefone.Text;
                cliente.Email = txtEmail.Text;
                AcessoFB.fb_AlterarDados(cliente);
                preencheGrid();
                MessageBox.Show("Cliente alterado com sucesso !", "Alterar", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        //
        private void btnExclui_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(txtID.Text);
                AcessoFB.fb_ExcluirDados(codigo);
                preencheGrid();
                MessageBox.Show("Cliente excluído com sucesso !", "Alterar", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
