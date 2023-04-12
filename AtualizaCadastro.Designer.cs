namespace Salve_VidasAdministrator
{
    partial class AtualizaCadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtualizaCadastro));
            this.label3 = new System.Windows.Forms.Label();
            this.PicBxLogin = new System.Windows.Forms.PictureBox();
            this.BtAtualizaCadastro = new System.Windows.Forms.Button();
            this.BtBuscaImagemNova = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PicBxAtualizaImagem = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RadBtAtualizaSenha = new System.Windows.Forms.RadioButton();
            this.RadBtAtualizaFoto = new System.Windows.Forms.RadioButton();
            this.TxtBxConfirmaSenha = new System.Windows.Forms.TextBox();
            this.LblConfirmaSenha = new System.Windows.Forms.Label();
            this.LblNvSenha = new System.Windows.Forms.Label();
            this.TxtBxNovaSenha = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxAtualizaImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.label3.Location = new System.Drawing.Point(141, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 33);
            this.label3.TabIndex = 10;
            this.label3.Text = "ATUALIZAR CADASTRO";
            // 
            // PicBxLogin
            // 
            this.PicBxLogin.Image = global::Salve_VidasAdministrator.Properties.Resources.Logo;
            this.PicBxLogin.Location = new System.Drawing.Point(12, 68);
            this.PicBxLogin.Name = "PicBxLogin";
            this.PicBxLogin.Size = new System.Drawing.Size(246, 145);
            this.PicBxLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBxLogin.TabIndex = 9;
            this.PicBxLogin.TabStop = false;
            // 
            // BtAtualizaCadastro
            // 
            this.BtAtualizaCadastro.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtAtualizaCadastro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(211)))), ((int)(((byte)(192)))));
            this.BtAtualizaCadastro.Location = new System.Drawing.Point(212, 262);
            this.BtAtualizaCadastro.Name = "BtAtualizaCadastro";
            this.BtAtualizaCadastro.Size = new System.Drawing.Size(124, 26);
            this.BtAtualizaCadastro.TabIndex = 11;
            this.BtAtualizaCadastro.Text = "Atualizar Cadastro";
            this.BtAtualizaCadastro.UseVisualStyleBackColor = false;
            this.BtAtualizaCadastro.Click += new System.EventHandler(this.BtAtualizaCadastro_Click);
            // 
            // BtBuscaImagemNova
            // 
            this.BtBuscaImagemNova.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtBuscaImagemNova.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(211)))), ((int)(((byte)(192)))));
            this.BtBuscaImagemNova.Location = new System.Drawing.Point(439, 188);
            this.BtBuscaImagemNova.Name = "BtBuscaImagemNova";
            this.BtBuscaImagemNova.Size = new System.Drawing.Size(71, 41);
            this.BtBuscaImagemNova.TabIndex = 12;
            this.BtBuscaImagemNova.Text = "Buscar Foto";
            this.BtBuscaImagemNova.UseVisualStyleBackColor = true;
            this.BtBuscaImagemNova.Click += new System.EventHandler(this.BtBuscaImagemNova_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PicBxAtualizaImagem
            // 
            this.PicBxAtualizaImagem.Image = global::Salve_VidasAdministrator.Properties.Resources.K;
            this.PicBxAtualizaImagem.Location = new System.Drawing.Point(299, 135);
            this.PicBxAtualizaImagem.Name = "PicBxAtualizaImagem";
            this.PicBxAtualizaImagem.Size = new System.Drawing.Size(134, 94);
            this.PicBxAtualizaImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBxAtualizaImagem.TabIndex = 13;
            this.PicBxAtualizaImagem.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(28, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "* Somente um item é atualizado por vez";
            // 
            // RadBtAtualizaSenha
            // 
            this.RadBtAtualizaSenha.AutoSize = true;
            this.RadBtAtualizaSenha.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RadBtAtualizaSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.RadBtAtualizaSenha.Location = new System.Drawing.Point(282, 92);
            this.RadBtAtualizaSenha.Name = "RadBtAtualizaSenha";
            this.RadBtAtualizaSenha.Size = new System.Drawing.Size(111, 19);
            this.RadBtAtualizaSenha.TabIndex = 21;
            this.RadBtAtualizaSenha.TabStop = true;
            this.RadBtAtualizaSenha.Text = "Atualizar Senha";
            this.RadBtAtualizaSenha.UseVisualStyleBackColor = true;
            this.RadBtAtualizaSenha.CheckedChanged += new System.EventHandler(this.RadBtAtualizaSenha_CheckedChanged);
            // 
            // RadBtAtualizaFoto
            // 
            this.RadBtAtualizaFoto.AutoSize = true;
            this.RadBtAtualizaFoto.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RadBtAtualizaFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.RadBtAtualizaFoto.Location = new System.Drawing.Point(421, 92);
            this.RadBtAtualizaFoto.Name = "RadBtAtualizaFoto";
            this.RadBtAtualizaFoto.Size = new System.Drawing.Size(102, 19);
            this.RadBtAtualizaFoto.TabIndex = 22;
            this.RadBtAtualizaFoto.TabStop = true;
            this.RadBtAtualizaFoto.Text = "Atualizar Foto";
            this.RadBtAtualizaFoto.UseVisualStyleBackColor = true;
            this.RadBtAtualizaFoto.CheckedChanged += new System.EventHandler(this.RadBtAtualizaFoto_CheckedChanged);
            // 
            // TxtBxConfirmaSenha
            // 
            this.TxtBxConfirmaSenha.Location = new System.Drawing.Point(299, 207);
            this.TxtBxConfirmaSenha.Name = "TxtBxConfirmaSenha";
            this.TxtBxConfirmaSenha.PlaceholderText = "Confirmar Senha";
            this.TxtBxConfirmaSenha.Size = new System.Drawing.Size(202, 23);
            this.TxtBxConfirmaSenha.TabIndex = 26;
            this.TxtBxConfirmaSenha.Visible = false;
            // 
            // LblConfirmaSenha
            // 
            this.LblConfirmaSenha.AutoSize = true;
            this.LblConfirmaSenha.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblConfirmaSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblConfirmaSenha.Location = new System.Drawing.Point(299, 189);
            this.LblConfirmaSenha.Name = "LblConfirmaSenha";
            this.LblConfirmaSenha.Size = new System.Drawing.Size(101, 15);
            this.LblConfirmaSenha.TabIndex = 25;
            this.LblConfirmaSenha.Text = "Confirmar Senha:";
            this.LblConfirmaSenha.Visible = false;
            // 
            // LblNvSenha
            // 
            this.LblNvSenha.AutoSize = true;
            this.LblNvSenha.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblNvSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.LblNvSenha.Location = new System.Drawing.Point(299, 132);
            this.LblNvSenha.Name = "LblNvSenha";
            this.LblNvSenha.Size = new System.Drawing.Size(74, 15);
            this.LblNvSenha.TabIndex = 24;
            this.LblNvSenha.Text = "Nova Senha:";
            this.LblNvSenha.Visible = false;
            // 
            // TxtBxNovaSenha
            // 
            this.TxtBxNovaSenha.Location = new System.Drawing.Point(299, 150);
            this.TxtBxNovaSenha.Name = "TxtBxNovaSenha";
            this.TxtBxNovaSenha.PlaceholderText = "Nova Senha";
            this.TxtBxNovaSenha.Size = new System.Drawing.Size(202, 23);
            this.TxtBxNovaSenha.TabIndex = 23;
            this.TxtBxNovaSenha.Visible = false;
            // 
            // AtualizaCadastro
            // 
            this.AcceptButton = this.BtBuscaImagemNova;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(547, 300);
            this.Controls.Add(this.TxtBxConfirmaSenha);
            this.Controls.Add(this.LblConfirmaSenha);
            this.Controls.Add(this.LblNvSenha);
            this.Controls.Add(this.TxtBxNovaSenha);
            this.Controls.Add(this.RadBtAtualizaFoto);
            this.Controls.Add(this.RadBtAtualizaSenha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PicBxAtualizaImagem);
            this.Controls.Add(this.BtBuscaImagemNova);
            this.Controls.Add(this.BtAtualizaCadastro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PicBxLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AtualizaCadastro";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizar Cadastro";
            this.Load += new System.EventHandler(this.AtualizaCadastro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBxLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBxAtualizaImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label3;
        private PictureBox PicBxLogin;
        private Button BtAtualizaCadastro;
        private Button BtBuscaImagemNova;
        private OpenFileDialog openFileDialog1;
        private PictureBox PicBxAtualizaImagem;
        private Label label1;
        private RadioButton RadBtAtualizaSenha;
        private RadioButton RadBtAtualizaFoto;
        private TextBox TxtBxConfirmaSenha;
        private Label LblConfirmaSenha;
        private Label LblNvSenha;
        private TextBox TxtBxNovaSenha;
    }
}