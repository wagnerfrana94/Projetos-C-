using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;


namespace ConectFirebird
{
    public partial class Form1 : Form
    {
        string acesso = @"DataSource=localhost; Database=C:\Users\wagner\Desktop\test.fdb; User=SYSDBA; Password = masterkey; Port=3050; Dialect=3";
        private static FbConnection conn;
        int id;


        public Form1()
        {
            InitializeComponent();
            id = 0; 
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(textBoxNome.Text) && !String.IsNullOrEmpty(textBoxCpf.Text) &&
                !String.IsNullOrEmpty(textBoxTelefone.Text) && !String.IsNullOrEmpty(textBoxSenha.Text)){

                conn = new FbConnection(acesso);
                id++;
                string sqlIncluir = "INSERT INTO CADASTRO (id, nome, cpf, telefone, senha) Values('" + id + "','" + textBoxNome.Text + "','" + textBoxCpf.Text + "','" + textBoxTelefone.Text + "','" + textBoxSenha.Text + "');";
                FbCommand cmd = new FbCommand(sqlIncluir, conn);


                try
                {
                    conn.Open();
                    int resultado = cmd.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!" + resultado);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro ao cadastrar! " + ex);

                }
                finally
                {
                    conn.Close();
                }

            }
            else
            {
                MessageBox.Show("Insira os dados corretamente!");
            }            
            
            

        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            ListarCadastros listar = new ListarCadastros(this);
            listar.ShowDialog();

        }
    }
}
