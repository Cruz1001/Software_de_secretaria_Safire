using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Data.SqlClient;



namespace consulta_secretaria
{
    public partial class Safire : Form
    {
        public Safire()
        {
            InitializeComponent();
        }

        private void aprovar_Click(object sender, EventArgs e)
        {
            DialogResult aprovar = MessageBox.Show("Confirmar envio?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //confirma o envio ou não
        }

        private void rejeitar_Click(object sender, EventArgs e)
        {
            Form2 justificativaForm = new Form2();
            DialogResult result = justificativaForm.ShowDialog(); //abre a tela de justificativa
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            //labelAluno.Text = string.Empty; //deixa a caixa de procurar vazia
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) //botão procurar
        {

            string BDSafire = @"C:\Safire\BD\BDSafire.accdb";
            string conectar = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={BDSafire};Persist Security Info=False;";

            OleDbConnection conexao = new OleDbConnection(conectar);

            try
            {
                conexao.Open();

                string query = "SELECT * FROM FormularioMeia";

                if (!string.IsNullOrEmpty(labelAluno.Text))
                {
                    query += " WHERE Nome LIKE ?"; 
                }

                OleDbCommand cmd = new OleDbCommand(query, conexao);

                if (!string.IsNullOrEmpty(labelAluno.Text))
                {
                    cmd.Parameters.AddWithValue("nomeParam", "%" + labelAluno.Text + "%");
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro: " + er.Message);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnProcurar2_Click(object sender, EventArgs e)
        {
           

            string BDSafire = @"C:\Safire\Software_de_secretaria_Safire\BD\BDSafire.accdb";
            string conectar = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={BDSafire};Persist Security Info=False;";

            OleDbConnection conexao = new OleDbConnection(conectar);

            try
            {
                conexao.Open();

                string query = "SELECT * FROM FormularioLivre";

                if (!string.IsNullOrEmpty(labelAluno2.Text))
                {
                    query += " WHERE Nome LIKE ?";
                }

                OleDbCommand cmd = new OleDbCommand(query, conexao);

                if (!string.IsNullOrEmpty(labelAluno2.Text))
                {
                    cmd.Parameters.AddWithValue("nomeParam", "%" + labelAluno2.Text + "%");
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = dataTable;
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro: " + er.Message);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                    conexao.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aprovarBtn2_Click(object sender, EventArgs e)
        {
            DialogResult aprovar = MessageBox.Show("Confirmar envio?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //confirma o envio ou não
        }

        private void button3_Click(object sender, EventArgs e) //botão rejeitar
        {
            Form2 justificativaForm = new Form2();
            DialogResult result = justificativaForm.ShowDialog(); //abre a tela de justificativa
        }

        private void cancelarBtn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}