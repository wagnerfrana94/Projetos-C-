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
    public partial class ListarCadastros : Form
    {
        public Form1 formPrincipal;
        string acesso = @"DataSource=localhost; Database=C:\Users\wagner\Desktop\test.fdb; User=SYSDBA; Password = masterkey; Port=3050; Dialect=3";
        private static FbConnection conn;

        public ListarCadastros(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();
        }

        private void ListarCadastros_Load(object sender, EventArgs e)
        {
            conn = new FbConnection(acesso);
            FbCommand cmd = new FbCommand("SELECT * FROM cadastro", conn);
            FbDataAdapter DA = new FbDataAdapter(cmd);
            DataSet DS = new DataSet();

            try
            {
                conn.Open();
                DA.Fill(DS, "cadastro");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "cadastro";
                
            }
            catch
            {
                MessageBox.Show("Erro na listagem dos dados!");
            }
            finally
            {
                conn.Close();
            }    
        }
    }
}
