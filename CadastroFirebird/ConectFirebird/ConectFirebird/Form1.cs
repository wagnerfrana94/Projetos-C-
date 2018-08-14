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
        string acesso = @"DataSource=localhost; Database=C:\arq.fdb; User=SYSDBA; Password = masterkey; Port=3050; Dialect=3";
        FbConnection conn;


        public Form1()
        {
            InitializeComponent();
            

            /*
            FbConnection fb = new FbConnection(acesso);
            fb.Open();
            FbCommand connQuery = new FbCommand();
            FbTransaction transaction;

            //INICIA A TRANSACAO
            transaction = fb.BeginTransaction();

            //PASSA AS VARIAVEIS PARA AS CONEXÃO E EXECUTA A SQL
            connQuery.Connection = fb;
            connQuery.Transaction = transaction;
            FbDataReader drQuery = connQuery.ExecuteReader();
        */    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            conn = new FbConnection(acesso);
            //string sqlIncluir = "INSERT INTO cadastro(nome, cpf)"
            //+ "Values(" +textBoxNome.Text + ", ' " +textBoxCpf.Text + " ');";
            //FbCommand tb = new FbCommand("CREATE TABLE cadastro (nome, cpf);", conn);
            //FbCommand cmd = new FbCommand(sqlIncluir, conn);
            try
            {
                conn.Open();
                // tb.ExecuteNonQuery();
                //cmd.ExecuteNonQuery();

            }
            catch 
            {

                MessageBox.Show("Erro ao cadastrar!");

            }
            finally
            {
                conn.Close();
            }

            
            
            

        }

       

        private void buttonListar_Click(object sender, EventArgs e)
        {
            ListarCadastros listar = new ListarCadastros(this);
            listar.ShowDialog();

        }
    }
}
