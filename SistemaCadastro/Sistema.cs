
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Sistema : Form
    {
        int idFilmeAlterar = 0;

        public Sistema()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastra.Height;
            marcador.Top = btnCadastra.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBusca.Height;
            marcador.Top = btnBusca.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void Sistema_Load(object sender, EventArgs e)
        {
            listaCBGeneros();
            lista_grindFilmes();
        }

        void lista_grindFilmes()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabela = con.listaFilmes();

            if (tabela == null)
            {
                MessageBox.Show("Erro ao listar filmes: " + con.Mensagem);
                return;
            }

            dgBandas.DataSource = tabela;

            if (dgBandas.Columns.Contains("id_filme"))
            {
                dgBandas.Columns["id_filme"].Visible = false;
            }
        }

        public void listaCBGeneros()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabelaDados = new DataTable();

            tabelaDados = con.listaGeneros();

            if (tabelaDados == null)
            {
                MessageBox.Show("Erro ao listar gêneros: " + con.Mensagem);
                return;
            }

            if (!tabelaDados.Columns.Contains("id_genero") ||
                !tabelaDados.Columns.Contains("nome_genero"))
            {
                MessageBox.Show(
                    "A procedure sp_listaGeneros não retornou as colunas corretas.");
                return;
            }

            cbGenero.DataSource = null;
            cbGenero.DisplayMember = "";
            cbGenero.ValueMember = "";

            cbGenero.DisplayMember = "nome_genero";
            cbGenero.ValueMember = "id_genero";
            cbGenero.DataSource = tabelaDados;
            cbGenero.SelectedIndex = -1;

            cbAlteraGenero.DataSource = null;
            cbAlteraGenero.DisplayMember = "";
            cbAlteraGenero.ValueMember = "";

            cbAlteraGenero.DisplayMember = "nome_genero";
            cbAlteraGenero.ValueMember = "id_genero";
            cbAlteraGenero.DataSource = tabelaDados.Copy();
            cbAlteraGenero.SelectedIndex = -1;
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            DataTable tabela = dgBandas.DataSource as DataTable;

            if (tabela == null)
                return;

            if (!tabela.Columns.Contains("nome_filme"))
                return;

            string busca = txtBusca.Text.Replace("'", "''")
                                        .Replace("[", "[[]")
                                        .Replace("%", "[%]")
                                        .Replace("*", "[*]");

            tabela.DefaultView.RowFilter =
                string.Format("nome_filme LIKE '{0}%'", busca);
        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {
            if (dgBandas.CurrentRow == null ||
                dgBandas.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Selecione um filme para excluir!");
                return;
            }

            if (!dgBandas.Columns.Contains("id_filme"))
            {
                MessageBox.Show("Coluna id_filme não encontrada!");
                return;
            }

            int linha = dgBandas.CurrentRow.Index;

            int id = Convert.ToInt32(
                dgBandas.Rows[linha].Cells["id_filme"].Value.ToString());

            DialogResult resp = MessageBox.Show(
                "Tem certeza que deseja excluir?",
                "Remove Filme",
                MessageBoxButtons.OKCancel);

            if (resp == DialogResult.OK)
            {
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.deletaFilme(id);

                if (retorno == true)
                {
                    MessageBox.Show("Filme excluído com sucesso!");
                    lista_grindFilmes();
                }
                else
                {
                    MessageBox.Show(
                        "Erro ao excluir o filme: " + con.Mensagem);
                }
            }
            else
            {
                MessageBox.Show("Exclusão cancelada");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgBandas.CurrentRow == null ||
                dgBandas.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Selecione um filme para alterar!");
                return;
            }

            DataGridViewRow linha = dgBandas.CurrentRow;

            if (linha.Cells["id_filme"].Value == null ||
                linha.Cells["id_filme"].Value == DBNull.Value)
            {
                MessageBox.Show("Selecione um filme válido!");
                return;
            }

            int idSelecionado = Convert.ToInt32(
                linha.Cells["id_filme"].Value);

            txtAlteraNome.Text =
                linha.Cells["nome_filme"].Value.ToString();

            txtAlteraIntegrantes.Text =
                linha.Cells["nome_diretor"].Value.ToString();

            txtAlteraRanking.Text =
                linha.Cells["ano_filme"].Value.ToString();

            string generoFilme =
                linha.Cells["nome_genero"].Value.ToString();

            cbAlteraGenero.SelectedIndex =
                cbAlteraGenero.FindStringExact(generoFilme);

            if (cbAlteraGenero.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Não foi possível localizar o gênero do filme.");
                return;
            }

            idFilmeAlterar = idSelecionado;

            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }

        private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
            if (idFilmeAlterar == 0)
            {
                MessageBox.Show("Selecione um filme para alterar!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAlteraNome.Text))
            {
                MessageBox.Show("Digite o nome do filme!");
                return;
            }

            if (cbAlteraGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um gênero!");
                return;
            }

            int idGenero;

            if (!int.TryParse(
                Convert.ToString(cbAlteraGenero.SelectedValue),
                out idGenero))
            {
                MessageBox.Show("Gênero inválido!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAlteraIntegrantes.Text))
            {
                MessageBox.Show("Digite o nome do diretor!");
                return;
            }

            int ano;

            if (!int.TryParse(txtAlteraRanking.Text, out ano))
            {
                MessageBox.Show("Digite um ano válido!");
                return;
            }

            ConectaBanco con = new ConectaBanco();
            Filmes filmeAlterado = new Filmes();

            filmeAlterado.Nome = txtAlteraNome.Text;
            filmeAlterado.Genero = idGenero.ToString();
            filmeAlterado.Diretor = txtAlteraIntegrantes.Text;
            filmeAlterado.Ano = ano.ToString();

            bool retorno = con.alteraFilme(
                filmeAlterado, idFilmeAlterar);

            if (retorno == false)
            {
                MessageBox.Show(
                    "Erro ao alterar o filme: " + con.Mensagem);
            }
            else
            {
                MessageBox.Show("Filme alterado com sucesso!");

                idFilmeAlterar = 0;

                txtAlteraNome.Clear();
                txtAlteraIntegrantes.Clear();
                txtAlteraRanking.Clear();
                cbAlteraGenero.SelectedIndex = -1;

                txtBusca.Clear();
                lista_grindFilmes();

                tabControl1.SelectedTab = tabControl1.TabPages[1];
            }
        }

        private void bntAddGenero_Click(object sender, EventArgs e)
        {
            FrmAddGenero fromGenero = new FrmAddGenero();
            this.Hide();
            fromGenero.ShowDialog();
            this.Close();
        }

        void limpaCampos()
        {
            txtnome.Clear();
            txtintegrantes.Clear();
            txtranking.Clear();
            cbGenero.SelectedIndex = -1;
            txtnome.Focus();
        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnome.Text))
            {
                MessageBox.Show("Digite o nome do filme!");
                return;
            }

            if (cbGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um gênero!");
                return;
            }

            int idGenero;

            if (!int.TryParse(
                Convert.ToString(cbGenero.SelectedValue),
                out idGenero))
            {
                MessageBox.Show("Gênero inválido!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtintegrantes.Text))
            {
                MessageBox.Show("Digite o nome do diretor!");
                return;
            }

            int ano;

            if (!int.TryParse(txtranking.Text, out ano))
            {
                MessageBox.Show("Digite um ano válido!");
                return;
            }

            ConectaBanco con = new ConectaBanco();
            Filmes novoFilme = new Filmes();

            novoFilme.Nome = txtnome.Text;
            novoFilme.Genero = idGenero.ToString();
            novoFilme.Diretor = txtintegrantes.Text;
            novoFilme.Ano = ano.ToString();

            bool retorno = con.insereFilme(novoFilme);

            if (retorno == false)
            {
                MessageBox.Show(
                    "Erro ao inserir o filme: " + con.Mensagem);
            }
            else
            {
                MessageBox.Show("Filme inserido com sucesso!");
                limpaCampos();
                lista_grindFilmes();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtAlteraNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbAlteraGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAlteraIntegrantes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlteraRanking_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
