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
    public partial class Form1 : Form
    {
        private Conta[] c;
        private int totalContas;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            totalContas = 3;
            c = new Conta[50];
            
            this.c[0] = new Conta();
            this.c[0].titular = new Cliente();
            c[0].titular.nome = "victor";
            c[0].numero = 3450;


            this.c[1] = new Conta();
            this.c[1].titular = new Cliente();
            c[1].titular.nome = "wagner";
            c[1].numero = 3451;

            this.c[2] = new Conta();
            this.c[2].titular = new Cliente();
            c[2].titular.nome = "osni";
            c[2].numero = 3452;



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void botaoBuscar_Click(object sender, EventArgs e)
        {
            int ind = 0;
            if (int.TryParse(indice.Text, out ind) && (ind > -1 && ind < totalContas))
            {

                titular.Text = c[ind].titular.nome;
                saldo.Text = Convert.ToString(c[ind].saldo);    
            }
            else
            {
                titular.Text = "";
                saldo.Text = "";
                valor.Text = "";
                MessageBox.Show("Informe uma conta válida!");
            }
        }

        private void botaoDepositar_Click(object sender, EventArgs e)
        {
            int ind = 0;
            double valDeposito = 0.0;

            if (int.TryParse(indice.Text, out ind) && (ind > -1 && ind < totalContas))
            {
                if (double.TryParse(valor.Text, out valDeposito))
                {
                    c[ind].Deposita(valDeposito);
                    saldo.Text = Convert.ToString(c[ind].saldo);
                    valor.Text = "";
                }
                else
                {
                    MessageBox.Show("Informe um valor para depósito corretamente!");
                }
            }
            else
            {
                MessageBox.Show("Informe uma conta válida!");
            }
        }

        private void botaoNovaConta_Click(object sender, EventArgs e)
        {
            FormCadastroConta formularioDeCadastro = new FormCadastroConta(this);
            formularioDeCadastro.ShowDialog();
        }

        public void adicionaConta(Conta novaConta)
        {
            this.c[this.totalContas] = novaConta;
            this.totalContas++;
        }
    }


}
