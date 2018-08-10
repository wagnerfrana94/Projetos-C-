using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FormCadastroConta : Form
    {
        private Form1 formPrincipal;
        public FormCadastroConta(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();
        }

        private void FormCadastroConta_Load(object sender, EventArgs e)
        {
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void botaoCadastrarConta_Click(object sender, EventArgs e)
        {
            Conta c = new Conta();
            c.titular = new Cliente();
            c.titular.nome = titularConta.Text;
            this.formPrincipal.adicionaConta(c);
            MessageBox.Show("Nova conta cadastrada com Sucesso!");
            this.Hide();

        }
    }
}
