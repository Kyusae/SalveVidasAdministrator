namespace Salve_VidasAdministrator
{
    partial class SalveVidasAdministrator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalveVidasAdministrator));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BotLoginAdmin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBxEmail = new System.Windows.Forms.TextBox();
            this.TxtBxSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PcBxInvisivel = new System.Windows.Forms.PictureBox();
            this.PcBxVisivel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxInvisivel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxVisivel)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Salve_VidasAdministrator.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(30, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 239);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BotLoginAdmin
            // 
            this.BotLoginAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotLoginAdmin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BotLoginAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(206)))), ((int)(((byte)(193)))));
            this.BotLoginAdmin.Location = new System.Drawing.Point(428, 260);
            this.BotLoginAdmin.Name = "BotLoginAdmin";
            this.BotLoginAdmin.Size = new System.Drawing.Size(108, 30);
            this.BotLoginAdmin.TabIndex = 1;
            this.BotLoginAdmin.Text = "Login";
            this.BotLoginAdmin.UseVisualStyleBackColor = true;
            this.BotLoginAdmin.Click += new System.EventHandler(this.BotLoginAdmin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.label1.Location = new System.Drawing.Point(350, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login Administrador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.label2.Location = new System.Drawing.Point(368, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email:";
            // 
            // TxtBxEmail
            // 
            this.TxtBxEmail.Location = new System.Drawing.Point(368, 140);
            this.TxtBxEmail.Name = "TxtBxEmail";
            this.TxtBxEmail.PlaceholderText = "Email";
            this.TxtBxEmail.Size = new System.Drawing.Size(224, 23);
            this.TxtBxEmail.TabIndex = 4;
            this.TxtBxEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBxEmail_KeyPress);
            // 
            // TxtBxSenha
            // 
            this.TxtBxSenha.Location = new System.Drawing.Point(368, 212);
            this.TxtBxSenha.Name = "TxtBxSenha";
            this.TxtBxSenha.PlaceholderText = "Senha";
            this.TxtBxSenha.Size = new System.Drawing.Size(224, 23);
            this.TxtBxSenha.TabIndex = 6;
            this.TxtBxSenha.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(57)))), ((int)(((byte)(109)))));
            this.label3.Location = new System.Drawing.Point(368, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Senha:";
            // 
            // PcBxInvisivel
            // 
            this.PcBxInvisivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PcBxInvisivel.Image = global::Salve_VidasAdministrator.Properties.Resources.Mostrar_Senha;
            this.PcBxInvisivel.Location = new System.Drawing.Point(567, 212);
            this.PcBxInvisivel.Name = "PcBxInvisivel";
            this.PcBxInvisivel.Size = new System.Drawing.Size(25, 23);
            this.PcBxInvisivel.TabIndex = 7;
            this.PcBxInvisivel.TabStop = false;
            this.PcBxInvisivel.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // PcBxVisivel
            // 
            this.PcBxVisivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PcBxVisivel.Image = global::Salve_VidasAdministrator.Properties.Resources.Mostrar_Senha2;
            this.PcBxVisivel.Location = new System.Drawing.Point(567, 212);
            this.PcBxVisivel.Name = "PcBxVisivel";
            this.PcBxVisivel.Size = new System.Drawing.Size(25, 23);
            this.PcBxVisivel.TabIndex = 8;
            this.PcBxVisivel.TabStop = false;
            this.PcBxVisivel.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // SalveVidasAdministrator
            // 
            this.AcceptButton = this.BotLoginAdmin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 329);
            this.Controls.Add(this.PcBxVisivel);
            this.Controls.Add(this.PcBxInvisivel);
            this.Controls.Add(this.TxtBxSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtBxEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BotLoginAdmin);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SalveVidasAdministrator";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salve+Vidas Administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SalveVidasAdministrator_FormClosing);
            this.Load += new System.EventHandler(this.SalveVidasAdministrator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxInvisivel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PcBxVisivel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button BotLoginAdmin;
        private Label label1;
        private Label label2;
        private TextBox TxtBxEmail;
        private TextBox TxtBxSenha;
        private Label label3;
        private PictureBox PcBxInvisivel;
        private PictureBox PcBxVisivel;
    }
}