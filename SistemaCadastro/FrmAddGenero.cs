
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class FrmAddGenero : Form
    {
        public FrmAddGenero()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Sistema sistema = new Sistema();
            this.Hide();
            sistema.ShowDialog();
            this.Close();

        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtaddgenero.Text))
            {
                MessageBox.Show("Digite o nome do gênero!");
                return;
            }

            ConectaBanco con = new ConectaBanco();

            string novoGenero = txtaddgenero.Text.Trim();

            bool retorno = con.insereGenero(novoGenero);

            if (retorno == false)
            {
                MessageBox.Show(
                    "Erro ao cadastrar gênero: " + con.Mensagem);
            }
            else
            {
                MessageBox.Show("Gênero cadastrado com sucesso!");

                txtaddgenero.Clear();
                txtaddgenero.Focus();
            }
        }

        private void txtaddgenero_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
