namespace SysStudioTattoo
{
    partial class Frm_Acesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Acesso));
            this.pnl_Detalhe = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbox_Visual = new System.Windows.Forms.CheckBox();
            this.tbox_PW_Login = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbox_UNm_Login = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnl_Botao = new System.Windows.Forms.Panel();
            this.btn_Confirmar = new System.Windows.Forms.Button();
            this.pnl_Titulo = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_Detalhe.SuspendLayout();
            this.pnl_Botao.SuspendLayout();
            this.pnl_Titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Detalhe
            // 
            this.pnl_Detalhe.BackColor = System.Drawing.Color.MistyRose;
            this.pnl_Detalhe.Controls.Add(this.label9);
            this.pnl_Detalhe.Controls.Add(this.cbox_Visual);
            this.pnl_Detalhe.Controls.Add(this.tbox_PW_Login);
            this.pnl_Detalhe.Controls.Add(this.label8);
            this.pnl_Detalhe.Controls.Add(this.tbox_UNm_Login);
            this.pnl_Detalhe.Controls.Add(this.label7);
            this.pnl_Detalhe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Detalhe.Location = new System.Drawing.Point(0, 72);
            this.pnl_Detalhe.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Detalhe.Name = "pnl_Detalhe";
            this.pnl_Detalhe.Size = new System.Drawing.Size(217, 121);
            this.pnl_Detalhe.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(150, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Visualizar";
            // 
            // cbox_Visual
            // 
            this.cbox_Visual.AutoSize = true;
            this.cbox_Visual.Location = new System.Drawing.Point(177, 76);
            this.cbox_Visual.Margin = new System.Windows.Forms.Padding(2);
            this.cbox_Visual.Name = "cbox_Visual";
            this.cbox_Visual.Size = new System.Drawing.Size(15, 14);
            this.cbox_Visual.TabIndex = 6;
            this.cbox_Visual.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cbox_Visual.UseVisualStyleBackColor = true;
            this.cbox_Visual.Click += new System.EventHandler(this.cbox_Visual_Click);
            // 
            // tbox_PW_Login
            // 
            this.tbox_PW_Login.Location = new System.Drawing.Point(13, 73);
            this.tbox_PW_Login.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_PW_Login.MaxLength = 35;
            this.tbox_PW_Login.Name = "tbox_PW_Login";
            this.tbox_PW_Login.Size = new System.Drawing.Size(154, 20);
            this.tbox_PW_Login.TabIndex = 5;
            this.tbox_PW_Login.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 57);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Senha";
            // 
            // tbox_UNm_Login
            // 
            this.tbox_UNm_Login.Location = new System.Drawing.Point(12, 31);
            this.tbox_UNm_Login.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_UNm_Login.MaxLength = 35;
            this.tbox_UNm_Login.Name = "tbox_UNm_Login";
            this.tbox_UNm_Login.Size = new System.Drawing.Size(191, 20);
            this.tbox_UNm_Login.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Nome Usuário";
            // 
            // pnl_Botao
            // 
            this.pnl_Botao.BackColor = System.Drawing.Color.Thistle;
            this.pnl_Botao.Controls.Add(this.btn_Confirmar);
            this.pnl_Botao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Botao.Location = new System.Drawing.Point(0, 193);
            this.pnl_Botao.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Botao.Name = "pnl_Botao";
            this.pnl_Botao.Size = new System.Drawing.Size(217, 40);
            this.pnl_Botao.TabIndex = 12;
            // 
            // btn_Confirmar
            // 
            this.btn_Confirmar.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btn_Confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Confirmar.Location = new System.Drawing.Point(77, 4);
            this.btn_Confirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(62, 30);
            this.btn_Confirmar.TabIndex = 8;
            this.btn_Confirmar.Text = "Confirmar";
            this.btn_Confirmar.UseVisualStyleBackColor = true;
            this.btn_Confirmar.Click += new System.EventHandler(this.btn_Confirmar_Click);
            // 
            // pnl_Titulo
            // 
            this.pnl_Titulo.BackColor = System.Drawing.Color.Thistle;
            this.pnl_Titulo.Controls.Add(this.label5);
            this.pnl_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Titulo.Location = new System.Drawing.Point(0, 0);
            this.pnl_Titulo.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Titulo.Name = "pnl_Titulo";
            this.pnl_Titulo.Size = new System.Drawing.Size(217, 72);
            this.pnl_Titulo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(107, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Acesso";
            // 
            // Frm_Acesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 233);
            this.Controls.Add(this.pnl_Detalhe);
            this.Controls.Add(this.pnl_Botao);
            this.Controls.Add(this.pnl_Titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Acesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Acesso";
            this.pnl_Detalhe.ResumeLayout(false);
            this.pnl_Detalhe.PerformLayout();
            this.pnl_Botao.ResumeLayout(false);
            this.pnl_Titulo.ResumeLayout(false);
            this.pnl_Titulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Detalhe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbox_Visual;
        private System.Windows.Forms.TextBox tbox_PW_Login;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbox_UNm_Login;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnl_Botao;
        private System.Windows.Forms.Panel pnl_Titulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Confirmar;
    }
}