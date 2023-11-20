using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace formulario_passes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string cadastro;


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://buscacepinter.correios.com.br/app/endereco/index.php");

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://buscacepinter.correios.com.br/app/endereco/index.php");

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnSelecionarArquivos_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Multiselect = true;
            this.ofd1.Title = "Selecionar Fotos";
            ofd1.InitialDirectory = @"C:\Users\macoratti\Pictures";
            //filtra para exibir somente arquivos de imagens
            ofd1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 2;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = true;

            DialogResult dr = this.ofd1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Le os arquivos selecionados 
                foreach (String arquivo in ofd1.FileNames)
                {
                    txtArquivo.Text += arquivo;
                    // cria um PictureBox
                    try
                    {
                        PictureBox pb = new PictureBox();
                        Image Imagem = Image.FromFile(arquivo);
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        //para exibir as imagens em tamanho natural 
                        //descomente as linhas abaixo e comente as duas seguintes
                        //pb.Height = loadedImage.Height;
                        //pb.Width = loadedImage.Width;
                        pb.Height = 100;
                        pb.Width = 100;
                        //atribui a imagem ao PictureBox - pb
                        pb.Image = Imagem;
                        //inclui a imagem no containter flowLayoutPanel
                        flowLayoutPanel1.Controls.Add(pb);
                    }
                    catch (SecurityException ex)
                    {
                        // O usuário  não possui permissão para ler arquivos
                        MessageBox.Show("Erro de segurança Contate o administrador de segurança da rede.\n\n" +
                                                    "Mensagem : " + ex.Message + "\n\n" +
                                                    "Detalhes (enviar ao suporte):\n\n" + ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        // Não pode carregar a imagem (problemas de permissão)
                        MessageBox.Show("Não é possível exibir a imagem");
                                                
                    }
                }
            }
        }

        private void txtArquivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void nome2_TextChanged(object sender, EventArgs e)
        {

        }

        private void nome1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cep1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviarPasseNormal_Click(object sender, EventArgs e)
        {
            if (txtNomePasseNormal.Text == "")
            {
                MessageBox.Show("Preencha o nome");
                txtNomePasseNormal.Focus();
                return;
            }
            if (!txtRAPasseNormal.MaskCompleted)
            {
                MessageBox.Show("RA invalido");
                txtRAPasseNormal.Focus();
                return;
            }
            if (!txtRGPasseNormal.MaskCompleted)
            {
                MessageBox.Show("RG invalido");
                txtRGPasseNormal.Focus();
                return;
            }
            if (!txtCpfPasseNormal.MaskCompleted)
            {
                MessageBox.Show("CPF invalido");
                txtCpfPasseNormal.Focus();
                return;
            }
            if (!txtCepPasseNormal.MaskCompleted)
            {
                MessageBox.Show("CEP Invalido");
                txtCepPasseNormal.Focus();
                return;
            }
            try
            {
                string pasta = Application.StartupPath + @"\BD\BDSafire.accdb";
                OleDbConnection conexao = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pasta);
                conexao.Open();

                string query = "INSERT INTO FormularioMeia (Nome, RA, Curso, Semestre, RG, DataExpedicao, DataNascimento, CPF, Telefone, Email, NomeMae, Endereco, NumCasa, CEP, TipoPasse, TipoSolicitacao, Status, Obs) VALUES ";
                query += $"('{txtNomePasseNormal.Text}', '{txtRAPasseNormal.Text}', '{cbxCursoPasseNormal.Text}', '{txtSemestrePasseNormal.Text}', '{txtRGPasseNormal.Text}','{txtDataExpedicaoPasseNormal.Text}', '{txtDataDeNascimentoPasseNormal.Text}', '{txtCpfPasseNormal.Text}', '{txtTelefonePasseNormal.Text}', '{txtEmailPasseNormal.Text}', '{txtNomeMaePasseNormal.Text}', '{txtEnderecoPasseNormal.Text}', '{txtNPasseNormal.Text}', '{txtCepPasseNormal.Text}', 'Meia', '{cadastro}', '', '')";
                OleDbCommand comando = new OleDbCommand(query, conexao);
                comando.ExecuteNonQuery();

                MessageBox.Show("Dados gravados com sucesso");

                txtNomePasseNormal.Text = "";
                txtRAPasseNormal.Text = "";
                txtDataExpedicaoPasseNormal.Text = "";
                txtDataDeNascimentoPasseNormal.Text = "";
                txtCpfPasseNormal.Text = "";
                txtTelefonePasseNormal.Text = "";
                txtEmailPasseNormal.Text = "";
                txtNomeMaePasseNormal.Text = "";
                txtEnderecoPasseNormal.Text = "";
                txtNPasseNormal.Text = "";
                txtCepPasseNormal.Text = "";

                conexao.Close();
            }
          
            catch (Exception er)
            {
              
                MessageBox.Show("Erro! " + er.Message);
                
            }
        }

        private void rbtnCadastramentoEmtuPasseNormal_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnCadastramentoEmtuPasseNormal.Checked)
            {
                cadastro += "Cadastro EMTU ";
            }
        }

        private void rbtnRevalidacaoEmtuPasseNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRevalidacaoEmtuPasseNormal.Checked) 
            {
                cadastro += "Recadastramento EMTU ";
            }
        }

        private void rbtnCadastramentoSptransPasseNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCadastramentoSptransPasseNormal.Checked)
            {
                cadastro += "Cadastramento SPTRANS";
            }
        }

        private void rbtnRevalidacaoSptransPasseNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRevalidacaoSptransPasseNormal.Checked)
            {
                cadastro += "Revalidação SPTRANS";
            }
        }

        private void txtDataDeNascimentoPasseNormal_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
