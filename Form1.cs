using Salve_Vidas.Db;
using Salve_VidasAdministrator.Model;

namespace Salve_VidasAdministrator
{
    public partial class SalveVidasAdministrator : Form
    {
        public SalveVidasAdministrator()
        {
            InitializeComponent();
        }

        private void SalveVidasAdministrator_Load(object sender, EventArgs e)
        {

        }

        private void SalveVidasAdministrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public const string NotAllowed2 = @"'%";

        private void TxtBxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NotAllowed2.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TxtBxSenha.UseSystemPasswordChar = false;
            PcBxInvisivel.Visible = false;
            PcBxVisivel.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TxtBxSenha.UseSystemPasswordChar = true;
            PcBxVisivel.Visible = false;
            PcBxInvisivel.Visible = true;
        }

        private void BotLoginAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtBxEmail.Text) || string.IsNullOrEmpty(TxtBxSenha.Text))
                {
                    MessageBox.Show("Preencha os dados para fazer login", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string Email = TxtBxEmail.Text.Trim();
                    string SenhaDescriptografada = TxtBxSenha.Text.Trim();

                    string senhaHash = "";
                    senhaHash = Hash.criptografarSenha(SenhaDescriptografada);

                    string query = $@"select Nome from UsuarioAdmin
                              where Email = '{Email}'";

                    var retorno = DBase.LoadData<NomeAdmin>(query);

                    if (retorno.Count() == 0)
                    {
                        MessageBox.Show("Email não cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string query2 = $@"select Nome from UsuarioAdmin
                                       where Email = '{Email}' and Senha = '{senhaHash}'";

                        var retorno2 = DBase.LoadData<NomeAdmin>(query2);

                        if (retorno2.Count() == 0)
                        {
                            MessageBox.Show("Senha Incorreta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            TelaDoAdmin telaDoAdmin = new TelaDoAdmin();
                            telaDoAdmin.email = TxtBxEmail.Text.Trim();
                            telaDoAdmin.senha = senhaHash;
                            this.Visible = false;
                            telaDoAdmin.ShowDialog();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao Conectar ao Banco de Dados, tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}