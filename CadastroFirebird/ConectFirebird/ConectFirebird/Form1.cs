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


        public Form1()
        {
            InitializeComponent();
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            conn = new FbConnection(acesso);
            string sqlIncluir = "INSERT INTO cadastro(ind, nome, cpf)"
            + "Values(" +textBoxNome.Text + ", ' " +textBoxCpf.Text + " ');";
            //FbCommand tb = new FbCommand("CREATE TABLE cadastro (nome, cpf);", conn);
            FbCommand cmd = new FbCommand(sqlIncluir, conn);
            try
            {
                conn.Open();
                MessageBox.Show("OKKKK!");
                // tb.ExecuteNonQuery();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao cadastrar!"+ex);

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
