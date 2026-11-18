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
            lista_grindBandas();
        }
        void lista_grindBandas()
        {
            ConectaBanco con = new ConectaBanco();
            dgBandas.DataSource = con.listaBandas();
            dgBandas.Columns["idbandas"].Visible = false;



        }

        public void listaCBGeneros()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabelaDados = new DataTable();
            tabelaDados = con.listaGeneros();
            cbGenero.DataSource = tabelaDados;
            cbGenero.DisplayMember = "genero";
            cbGenero.ValueMember = "idgenero";
            cbGenero.SelectedIndex = -1;
        }


        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            (dgBandas.DataSource as DataTable).DefaultView.RowFilter =
            string.Format("nome like '{0}%'", txtBusca.Text);

        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {
            int linha = dgBandas.CurrentRow.Index;
            int id = Convert.ToInt32(
                    dgBandas.Rows[linha].Cells["idbandas"].Value.ToString());
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?",
                "Remove Banda", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.deletaBanda(id);
                if (retorno == true)
                {
                    MessageBox.Show("Banda excluida com sucesso!");
                    lista_grindBandas();
                }// fim if retorno true
                else
                    MessageBox.Show("Erro ao excluir a banda");


            }// fim if Ok Cancela
            else
                MessageBox.Show("Exclusão cancelada");

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {



        }

        private void bntAddGenero_Click(object sender, EventArgs e)
        {

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
            ConectaBanco con = new ConectaBanco();
            Banda novaBanda = new Banda();
            novaBanda.Nome = txtnome.Text;
            novaBanda.Integrantes = Convert.ToInt32(txtintegrantes.Text);
            novaBanda.Ranking = Convert.ToInt32(txtranking.Text);
            novaBanda.Genero = Convert.ToInt32(cbGenero.SelectedValue.ToString());
            bool retorno = con.insereBanda(novaBanda);
            if (retorno == false)
            {
                MessageBox.Show("Erro ao inserir a banda");

            }
            else
            {
                MessageBox.Show("Banda inserida com susesso!");
                limpaCampos();
                lista_grindBandas();
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
    }
}
