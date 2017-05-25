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
    public partial class ControledeMoradores : Form
    {
        Moradores moradores = new Moradores();
        public ControledeMoradores()
        {
            InitializeComponent();
            clear();
            listarua();
            listarMoradores();
        }

        public void clear()
        {
            mtbRg.Text = "";
            txtNome.Text = "";
            cbRua.Text = "";
            cbNumero.Text = "";
        }

        public bool validar()
        {
            if (mtbRg.Text != "" && txtNome.Text != "" && cbRua.Text != "" && cbNumero.Text != "")
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
            moradores.Rg = mtbRg.Text;
            moradores.Nome = txtNome.Text;
            moradores.Rua = cbRua.Text;
            moradores.Numero = int.Parse(cbNumero.Text);
        }

        public void listarua()
        {
            try
            {
                Endereco endereco = new Endereco();
                List<Endereco> listarRua = endereco.listarRua();

                foreach (Endereco end in listarRua)
                {
                    cbRua.Items.Add(end.Rua);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void cbRuaSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Endereco endereco = new Endereco();
                endereco.Rua = cbRua.Text;
                List<Endereco> lista = endereco.listarNumeros();
                cbNumero.Items.Clear();
                foreach (Endereco end in lista) 
                {
                    
                    cbNumero.Items.Add(end.Numero);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        public void listarMoradores()
        {
            try
            {
                dgvMoradores.DataSource = moradores.listarMoradores();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (validar() == true)
            {
                try
                {
                    recuperarValores();
                    moradores.cadastrar();
                    listarMoradores();
                    clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (mtbRg.Text != "" && cbRua.Text != "" && cbNumero.Text != "")
            {
                try
                {
                    moradores.Rg = mtbRg.Text;
                    moradores.Rua = cbRua.Text;
                    moradores.Numero = int.Parse(cbNumero.Text);
                    moradores.DeletarEndereco();

                    clear();
                    listarMoradores();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Preencha os campos 'RG', 'Rua', 'Numero' para deletar um registro completo!");
            }
        }

        private void btnDeletarReg_Click(object sender, EventArgs e)
        {
            if (mtbRg.Text != "")
            {
                try
                {
                    moradores.Rg = mtbRg.Text;
                    moradores.DeletarRegistro();
                    clear();
                    listarMoradores();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("O campo Rg deve ser preenchido");
            }
        }
    }
}
