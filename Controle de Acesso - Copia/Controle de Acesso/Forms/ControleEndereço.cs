using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controle_de_Acesso.Modelos;

namespace Controle_de_Acesso.Forms
{
    public partial class ControleEndereço : Form
    {
        Endereco endereco = new Endereco();
        public ControleEndereço()
        {
            InitializeComponent();
            dgvEndereco.DataSource = endereco.listar();
            clear();
        }

        public void clear()
        {
            txtRua.Text = "";
            txtNumero.Text = "";
        }

        public bool validar()
        {
            if (txtRua.Text != "" && txtNumero.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void recuperarValores()
        {
            endereco.Rua = txtRua.Text;
            endereco.Numero = int.Parse(txtNumero.Text);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar() == true)
                {
                    recuperarValores();
                    endereco.cadastrar();
                    dgvEndereco.DataSource = endereco.listar();
                    clear();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar() == true)
                {
                    recuperarValores();
                    endereco.deletar();
                    dgvEndereco.DataSource = endereco.listar();
                    clear();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }
    }
}
