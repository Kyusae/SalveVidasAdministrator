using Salve_Vidas.Db;
using Salve_VidasAdministrator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salve_VidasAdministrator
{
    public partial class AtualizaCadastro : Form
    {
        string image = "";

        public string email { get; set; }

        public string senha { get; set; }

        public AtualizaCadastro()
        {
            InitializeComponent();
        }

        private void AtualizaCadastro_Load(object sender, EventArgs e)
        {
            BuscaImagem();
            RadBtAtualizaFoto.Checked = true;
        }

        private void BtBuscaImagemNova_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog(this);
            string strFn = this.openFileDialog1.FileName;
            var teste = CarregaImagem(strFn);
        }

        protected string CarregaImagem(string strFn)
        {
            string vetorImagens = "";

            try
            {
                if (string.IsNullOrEmpty(strFn))
                    return vetorImagens;

                this.PicBxAtualizaImagem.Image = Image.FromFile(strFn);
                FileInfo arqImagem = new FileInfo(strFn);

                vetorImagens = ImageToBase64(this.PicBxAtualizaImagem.Image, this.PicBxAtualizaImagem.Image.RawFormat);

                image = vetorImagens;
                return vetorImagens;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return vetorImagens;
            }
        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        private void BuscaImagem()
        {
            try
            {
                string Email = email;
                string Senha = senha;

                string query = $@"select a.Imagem as 'Foto' from UsuarioAdmin a
                                  where a.Email = '{Email}'
                                  and a.Senha = '{Senha}'";

                var retorno = DBase.LoadData<Imagem>(query);

                if (retorno.FirstOrDefault().Foto == "")
                {
                    PicBxAtualizaImagem.Image = Properties.Resources.K;
                }
                else
                {
                    var teste = Base64ToImage(retorno.FirstOrDefault().Foto);
                    PicBxAtualizaImagem.Image = teste;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Image Base64ToImage(string base64String)
        {
            try
            {
                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void RadBtAtualizaSenha_CheckedChanged(object sender, EventArgs e)
        {
            PicBxAtualizaImagem.Visible = false;
            BtBuscaImagemNova.Visible = false;

            LblConfirmaSenha.Visible = true;
            LblNvSenha.Visible = true;
            TxtBxConfirmaSenha.Visible = true;
            TxtBxNovaSenha.Visible = true;

            BtAtualizaCadastro.Visible = true;
        }

        private void RadBtAtualizaFoto_CheckedChanged(object sender, EventArgs e)
        {
            LblConfirmaSenha.Visible = false;
            LblNvSenha.Visible = false;
            TxtBxConfirmaSenha.Visible = false;
            TxtBxNovaSenha.Visible = false;

            PicBxAtualizaImagem.Visible = true;
            BtBuscaImagemNova.Visible = true;

            BtAtualizaCadastro.Visible = true;
        }

        private void BtAtualizaCadastro_Click(object sender, EventArgs e)
        {
            if (RadBtAtualizaSenha.Checked)
            {
                AtualizaSenha();
            }

            if (RadBtAtualizaFoto.Checked)
            {
                AtualizaFoto();
            }
        }

        private void AtualizaSenha()
        {
            try
            {
                if (string.IsNullOrEmpty(TxtBxNovaSenha.Text) || string.IsNullOrEmpty(TxtBxConfirmaSenha.Text))
                {
                    MessageBox.Show("Informe a nova senha para atualizar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (TxtBxNovaSenha.Text != TxtBxConfirmaSenha.Text)
                    {
                        MessageBox.Show("As senhas devem ser iguais", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string Email = email;

                        string senhaantiga = senha;

                        string senhanova = TxtBxConfirmaSenha.Text.Trim();
                        string senhaHashnova = "";
                        senhaHashnova = Hash.criptografarSenha(senhanova);

                        if (senhaHashnova == senha)
                        {
                            MessageBox.Show("A senha nova não pode ser a mesma que a antiga", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string query = $@"select 1 from UsuarioAdmin where Email = '{Email}' and Senha = '{senhaantiga}'";

                            var retorno = DBase.LoadData<ExisteUsuarioDoador>(query);

                            if (retorno.Count() == 0)
                            {
                                MessageBox.Show("Usuario não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string query2 = $@"update a set Senha = '{senhaHashnova}'
                                                   from UsuarioAdmin a 
                                                   where Email = '{Email}'
                                                   and Senha = '{senhaHashnova}'";

                                var retorno2 = DBase.ExecuteWithReturnAffected(query2);

                                if (retorno2 == 0)
                                {
                                    MessageBox.Show("Erro ao atualizar a senha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Sucesso ao atualizar a senha", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizaFoto()
        {
            try
            {
                string Email = email;
                string Senha = senha;

                string query = $@"update a set Imagem = '{image}'
                              from UsuarioAdmin a
                              where a.Email = '{Email}' and a.Senha = '{Senha}'";

                var retorno = DBase.ExecuteWithReturnAffected(query);

                if (retorno == 0)
                {
                    MessageBox.Show("Erro ao atualizar imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Imagem Atualizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
