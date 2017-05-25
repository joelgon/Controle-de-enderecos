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
    public partial class ControleFuncionarios : Form
    {
        Funcionario funcionario = new Funcionario();
        public ControleFuncionarios()
        {
            InitializeComponent();
            dgvFuncionario.DataSource = funcionario.listar();
            clear();
        }

        public void clear()
        {
            mtbRg.Text = "";
            txtNome.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
        }

        public bool validarParaCadastrados()
        {
            if (mtbRg.Text != "" && txtNome.Text != "" && txtUsuario.Text != "" && txtSenha.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool validarParaAtualizar()
        {
            if (mtbRg.Text != "")
            {
                bool flag;
                if (txtNome.Text != "")
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }

                if (txtUsuario.Text != "")
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }

                if (txtSenha.Text != "")
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                return flag;
            }
            else
            {
                return false;
            }
        }

        public void recuperarValores()
        {
            funcionario.RG = mtbRg.Text;
            funcionario.Nome = txtNome.Text;
            funcionario.Usuario = txtUsuario.Text;
            funcionario.Senha = txtSenha.Text;
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarParaCadastrados() == true)
                {
                    recuperarValores();
                    funcionario.Cadastrar();
                    dgvFuncionario.DataSource = funcionario.listar();
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if(validarParaAtualizar() == true)
                {
                    recuperarValores();
                    funcionario.update();
                    dgvFuncionario.DataSource = funcionario.listar();
                    clear();
                }
                else
                {
                    MessageBox.Show("Digite o rg e outra propriedade para alterar");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (mtbRg.Text != "")
            {
                try
                {
                    recuperarValores();
                    funcionario.deletar();
                    dgvFuncionario.DataSource = funcionario.listar();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("digite o RG para deletar o registro");
            }
        }
    }
}
