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
using Controle_de_Acesso.Forms;

namespace Controle_de_Acesso
{
    public partial class Autentificacao : Form
    {
        public Autentificacao()
        {
            InitializeComponent();
            clear();
        }

        public void clear()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
        }
        public void logar()
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Usuario = txtUsuario.Text;
                funcionario.Senha = txtSenha.Text;
                if(funcionario.logar() == true)
                {
                    CrudM2 novaForm = new CrudM2();
                    novaForm.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Não cadastrado");
                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show("" + e.Message);
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            logar();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logar();
            }
        }
    }
}
