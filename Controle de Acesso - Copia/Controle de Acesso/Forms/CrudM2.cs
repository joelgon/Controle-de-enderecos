using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controle_de_Acesso.Forms;

namespace Controle_de_Acesso.Forms
{
    public partial class CrudM2 : Form
    {
        public CrudM2()
        {
            InitializeComponent();
        }

        private void Funcionario_Click(object sender, EventArgs e)
        {
            ControleFuncionarios novaform = new ControleFuncionarios();
            novaform.Show();
        }

        private void Enderecos_Click(object sender, EventArgs e)
        {
            ControleEndereço novaform = new ControleEndereço();
            novaform.Show();
        }

        private void Moradores_Click(object sender, EventArgs e)
        {
            ControledeMoradores novaform = new ControledeMoradores();
            novaform.Show();
        }
    }
}
