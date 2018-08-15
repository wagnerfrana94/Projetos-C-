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
        string acesso = @"DataSource=localhost; Database=C:\Users\wagner\Desktop\teste.fdb; username= SYSDBA; password = masterkey";
        FbConnection conn;

        public ListarCadastros(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();
        }

        private void ListarCadastros_Load(object sender, EventArgs e)
        {
            conn = new FbConnection(acesso);
            FbCommand cmd = new FbCommand("SELECT * FROM teste", conn);
            FbDataAdapter DA = new FbDataAdapter(cmd);
            DataSet DS = new DataSet();

            try
            {
                conn.Open();
                DA.Fill(DS, "teste");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "teste";
                conn.Close();
            }
            catch
            {

            }    
        }
    }
}
