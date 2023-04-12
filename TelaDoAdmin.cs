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
    public partial class TelaDoAdmin : Form
    {
        string image = "";

        public string email { get; set; }

        public string senha { get; set; }

        public TelaDoAdmin()
        {
            InitializeComponent();
        }

        private void TelaDoAdmin_Load(object sender, EventArgs e)
        {
            BuscaNome();
            BuscaImagem();
            BuscaEstado();
        }

        private void TelaDoAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PnlCadastraHospital.Visible = true;
            PnlCadastraUsuario.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PnlCadastraHospital.Visible = false;
            PnlCadastraUsuario.Visible = true;
        }

        public string NotAllowed = @"'><@{}[]#&()/|*-+$%~\!¨_?:,.;ºª°""§¹²³£¢¬1234567890=";
        public const string NotAllowed2 = @"'%";
        public string NotAllowed3 = @"'><{}[]#&()/|*+$%~\!¨?:,;ºª°""§¹²³£¢¬=´^`";

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed3.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed3.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BuscaImagem()
        {
            try
            {
                string Email = email;
                string Senha = senha;

                string query = $@"select Imagem as 'Foto' from UsuarioAdmin a
                                  where a.Email = '{Email}'
                                  and a.Senha = '{Senha}'";

                var retorno = DBase.LoadData<Imagem>(query);

                if (retorno.Count() == 0 || retorno.FirstOrDefault().Foto == "")
                {
                    PicBxLogin.Image = Properties.Resources.Logo;
                }
                else
                {
                    var teste = Base64ToImage(retorno.FirstOrDefault().Foto);
                    PicBxLogin.Image = teste;
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

        private void BuscaNome()
        {
            try
            {
                string Email = email;
                string Senha = senha;

                string query = $@"select Nome from UsuarioAdmin 
                              where Email = '{Email}' and Senha = '{Senha}'";

                var retorno = DBase.LoadData<NomeAdmin>(query);

                if (retorno.Count() == 0)
                {
                    MessageBox.Show("Erro ao buscar nome do usuario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LblNome.Text = "";
                }
                else
                {
                    LblNome.Text = retorno.FirstOrDefault().Nome;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Banco de Dados, tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                ViaCep viaCep = new ViaCep();

                var resposta = viaCep.consultaCEP(TxtBxCEP.Text.Trim());

                if (resposta != null)
                {
                    TxtBxEndereco.Text = resposta.Logradouro;
                    TxtBxBairro.Text = resposta.Bairro;
                    TxtBxUF.Text = resposta.UF;
                    TxtBxCidade.Text = resposta.localidade;

                    BuscaEstado(resposta.UF);
                }
                else
                {
                    TxtBxEndereco.Text = null;
                    TxtBxBairro.Text = null;
                    TxtBxUF.Text = null;
                    TxtBxCidade.Text = null;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaEstado(string UF)
        {
            try
            {
                string query = $@"select Nome from Estado where UF = '{UF}' order by Nome desc";

                var retorno = DBase.LoadData<EstadosNome>(query);

                TxtBxEstado.Text = retorno.FirstOrDefault().Nome.ToString();
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotCadastraHospital_Click(object sender, EventArgs e)
        {
            try
            {
                string Nome = TxtBxNome.Text.Trim();
                string CNPJ = TxtBxCNPJ.Text.Trim();
                string Razao = TxtBxRazao.Text.Trim();
                string Telefone = TxtBxTelefone.Text.Trim();
                string Endereco = TxtBxEndereco.Text.Trim();
                string Numero = TxtBxNumero.Text.Trim();
                string Complemento = TxtBxComplemento.Text.Trim();
                string Bairro = TxtBxBairro.Text.Trim();
                string Cidade = TxtBxCidade.Text.Trim();
                string Estado = TxtBxEstado.Text.Trim();
                string UF = TxtBxUF.Text.Trim();
                string CEP = TxtBxCEP.Text.Trim();
                string IE = TxtBxIE.Text.Trim();

                if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(CNPJ) || string.IsNullOrEmpty(Razao)
                    || string.IsNullOrEmpty(Telefone) || string.IsNullOrEmpty(Endereco) || string.IsNullOrEmpty(Numero)
                    || string.IsNullOrEmpty(Bairro) || string.IsNullOrEmpty(Cidade) || string.IsNullOrEmpty(Estado)
                    || string.IsNullOrEmpty(UF) || string.IsNullOrEmpty(CEP) || string.IsNullOrEmpty(IE))
                {
                    MessageBox.Show("Preencha todas as informações para realizar o cadastro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query = $@"select Nome from Hospital where CNPJ = '{CNPJ}'";

                    var retorno = DBase.LoadData<NomeHospital>(query);

                    if (retorno.Count() > 1)
                    {
                        MessageBox.Show("CNPJ já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (Complemento == "" || Complemento == null)
                            Complemento = "";

                        string query2 = $@"insert into Hospital values (newid(), '{Nome}', '{CNPJ}', '{Razao}', '{Telefone}', '{Endereco}', '{Numero}', '{Complemento}', '{Bairro}', '{Cidade}', '{Estado}', '{UF}', '{CEP}', '{IE}', getdate(), null)";

                        var retorno2 = DBase.ExecuteWithReturnAffected(query2);

                        if (retorno2 > 0)
                        {
                            MessageBox.Show("Hospital Cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TxtBxNome.Text = null;
                            TxtBxCNPJ.Text = null;
                            TxtBxRazao.Text = null;
                            TxtBxTelefone.Text = null;
                            TxtBxEndereco.Text = null;
                            TxtBxNumero.Text = null;
                            TxtBxComplemento.Text = null;
                            TxtBxBairro.Text = null;
                            TxtBxCidade.Text = null;
                            TxtBxEstado.Text = null;
                            TxtBxUF.Text = null;
                            TxtBxCEP.Text = null;
                            TxtBxIE.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("Erro ao cadastrar Hospital.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscaEstado()
        {
            try
            {
                string query = $@"select Nome, Id from Estado Order by Nome";

                var retorno = DBase.LoadData<Estados>(query);

                if (retorno.Count() == 0)
                {
                    MessageBox.Show("Erro ao buscar Estados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CBBxEstado.DataSource = retorno;
                    CBBxEstado.DisplayMember = "Nome";
                    CBBxEstado.ValueMember = "Id";
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
                if (strFn.Contains(".mp4") || strFn.Contains(".MKV") || strFn.Contains(".AVI") || strFn.Contains(".WMV")
                    || strFn.Contains(".MOV") || strFn.Contains(".QT") || strFn.Contains(".AVCHD") || strFn.Contains(".FLV") || strFn.Contains(".SWF"))
                {
                    MessageBox.Show("Formato de foto invalido. Utilize imagens em formato JPG, PNG.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return vetorImagens;
                }
                else
                {
                    if (string.IsNullOrEmpty(strFn))
                        return vetorImagens;

                    this.PicBxFoto.Image = Image.FromFile(strFn);
                    FileInfo arqImagem = new FileInfo(strFn);

                    vetorImagens = ImageToBase64(this.PicBxFoto.Image, this.PicBxFoto.Image.RawFormat);

                    image = vetorImagens;
                    return vetorImagens;
                }
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

        private void CBBxEstado_Click(object sender, EventArgs e)
        {
            CBBxCidade.DataSource = null;
            CBBxHospital.DataSource = null;
        }

        private void CBBxCidade_Click(object sender, EventArgs e)
        {
            BuscaCidade();
        }

        private void BuscaCidade()
        {
            try
            {
                string Estado = CBBxEstado.SelectedValue.ToString();

                string query = $@"select Nome from Cidades where IdEstado = '{Estado}' order by Nome";

                var retorno = DBase.LoadData<Cidade>(query);

                if (retorno.Count() == 0)
                {
                    MessageBox.Show("Erro ao buscar Cidades.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CBBxCidade.DataSource = retorno;
                    CBBxCidade.DisplayMember = "Nome";
                    CBBxCidade.ValueMember = "Nome";
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBBxHospital_Click(object sender, EventArgs e)
        {
            BuscaHospitaisCadastrados();
        }

        private void BuscaHospitaisCadastrados()
        {
            try
            {
                string Estado = CBBxEstado.Text;
                string Cidade = CBBxCidade.SelectedValue.ToString();

                string query = $@"select distinct a.Nome, a.Id from Hospital a
                                  join EstoqueDeSangue b on b.IdHospital = a.Id 
                                  where a.Estado = '{Estado}' and a.Cidade = '{Cidade}'";

                var retorno = DBase.LoadData<Hospitais>(query);

                if (retorno.Count() == 0)
                {
                    MessageBox.Show("Erro ao buscar Hospitais dessa cidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CBBxHospital.DataSource = retorno;
                    CBBxHospital.DisplayMember = "Nome";
                    CBBxHospital.ValueMember = "Id";
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Nome = TxtBxNomeUsuario.Text.Trim();
                string Sobrenome = TxtBxSobrenome.Text.Trim();
                string Email = TxtBxEmail.Text.Trim();
                string Telefone = TxtBxTelefoneUsuario.Text.Trim();

                string SenhaDescriptografada = TxtBxSenha.Text.Trim();
                string senhaHash = "";
                senhaHash = Hash.criptografarSenha(SenhaDescriptografada);

                string IdHospital = CBBxHospital.SelectedValue.ToString();
                string Imagem = image;

                string query = $@"select Nome from Usuario where Email = '{Email}' and Senha = '{senhaHash}'";

                var retorno = DBase.LoadData<NomeUsuario>(query);

                if (retorno.Count() > 0)
                {
                    MessageBox.Show("Email já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(Sobrenome) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Telefone)
                        || string.IsNullOrEmpty(SenhaDescriptografada))
                    {
                        MessageBox.Show("Preencha todos os dados para cadastrar um usuario.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ExecutaInsereUsuario(Nome, Sobrenome, Email, Telefone, senhaHash, IdHospital, Imagem);
                        TxtBxNomeUsuario.Text = null;
                        TxtBxSobrenome.Text = null;
                        TxtBxEmail.Text = null;
                        TxtBxSenha.Text = null;
                        TxtBxTelefone.Text = null;
                        PicBxFoto.Image = Properties.Resources.K;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Bando de Dados, tentando novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecutaInsereUsuario(string Nome, string Sobrenome, string Email, string Telefone, string senhaHash, string IdHospital, string Imagem)
        {
            try
            {
                string ExecutaProc = null;

                ExecutaProc = @"'" + Nome + "', '" + Sobrenome + "', '" + Email + "', '" + Telefone + "', '" + senhaHash + "', '" + IdHospital + "', '" + Imagem + "'";

                var retorno = DBase.RunProcedure("CriaUsuarioHospital", new
                {
                    Nome = Nome,
                    Sobrenome = Sobrenome,
                    Email = Email,
                    Telefone = Telefone,
                    Senha = senhaHash,
                    IdHospital = IdHospital,
                    Imagem = Imagem
                });

                if (retorno > 0)
                {
                    MessageBox.Show("Sucesso ao criar o usuario", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Erro, tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtBxNomeUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed3.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtBxSobrenome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtBxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed2.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtBxSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed2.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtBxTelefoneUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed3.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CBBxEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CBBxCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled= true;
        }

        private void CBBxHospital_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var retorno = DBase.TestaConexao();

            if (retorno == "Erro")
            {

            }
            else
            {
                AtualizaCadastro atualizacadastro = new AtualizaCadastro();
                    atualizacadastro.email = email;
                    atualizacadastro.senha = senha;
                    atualizacadastro.ShowDialog();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void TelaDoAdmin_Activated(object sender, EventArgs e)
        {
            BuscaNome();
            BuscaImagem();
        }

        private void pictureBox2_MouseHover_1(object sender, EventArgs e)
        {
            
        }
    }
}
