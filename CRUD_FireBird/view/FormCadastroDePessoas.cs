using System;
using System.Windows.Forms;

namespace CadastroDePessoas
{
    public partial class FormCadastroDePessoas : Form
    {
        public FormCadastroDePessoas()
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
                dgvCientes.DataSource = Conexao.fb_GetDados().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
        }
        //
        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                Pessoa pessoa = new Pessoa();
                pessoa.ID = Convert.ToInt32(txtID.Text);
                pessoa.Nome = txtNome.Text;
                pessoa.Endereco = txtEndereco.Text;
                pessoa.Telefone = txtTelefone.Text;
                pessoa.Email = txtEmail.Text;
                Conexao.fb_InserirDados(pessoa);
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
            Pessoa cliente = new Pessoa();
            try
            {
                int codigo = Convert.ToInt32(dgvCientes.Rows[e.RowIndex].Cells[0].Value);
                cliente = Conexao.fb_ProcuraDados(codigo);
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
            Pessoa cliente = new Pessoa();
            try
            {
                int codigo = (int)Int64.Parse(txtID.Text);
                cliente = Conexao.fb_ProcuraDados(codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
            }
            preencheDados(cliente);
        }
        //
        private void preencheDados(Pessoa pessoa)
        {
            txtID.Text = pessoa.ID.ToString();
            txtNome.Text = pessoa.Nome;
            txtEndereco.Text = pessoa.Endereco;
            txtTelefone.Text = pessoa.Telefone;
            txtEmail.Text = pessoa.Email;
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
                Pessoa pessoa = new Pessoa();
                pessoa.ID = Convert.ToInt32(txtID.Text);
                pessoa.Nome = txtNome.Text;
                pessoa.Endereco = txtEndereco.Text;
                pessoa.Telefone = txtTelefone.Text;
                pessoa.Email = txtEmail.Text;
                Conexao.fb_AlterarDados(pessoa);
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
                Conexao.fb_ExcluirDados(codigo);
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();  
        }
    }
}
