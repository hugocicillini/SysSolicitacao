namespace SysSolicitação
{
    partial class Frm_Genero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Genero));
            this.pnl_Detalhe = new System.Windows.Forms.Panel();
            this.tbox_Nm_Genero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbox_Cod_Genero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_Lista = new System.Windows.Forms.Panel();
            this.lbox_Genero = new System.Windows.Forms.ListBox();
            this.pnl_Botao = new System.Windows.Forms.Panel();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Confirmar = new System.Windows.Forms.Button();
            this.btn_Excluir = new System.Windows.Forms.Button();
            this.btn_Alterar = new System.Windows.Forms.Button();
            this.btn_Novo = new System.Windows.Forms.Button();
            this.pnl_Titulo = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_Detalhe.SuspendLayout();
            this.pnl_Lista.SuspendLayout();
            this.pnl_Botao.SuspendLayout();
            this.pnl_Titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Detalhe
            // 
            this.pnl_Detalhe.BackColor = System.Drawing.Color.MistyRose;
            this.pnl_Detalhe.Controls.Add(this.tbox_Nm_Genero);
            this.pnl_Detalhe.Controls.Add(this.label7);
            this.pnl_Detalhe.Controls.Add(this.tbox_Cod_Genero);
            this.pnl_Detalhe.Controls.Add(this.label6);
            this.pnl_Detalhe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Detalhe.Location = new System.Drawing.Point(150, 76);
            this.pnl_Detalhe.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Detalhe.Name = "pnl_Detalhe";
            this.pnl_Detalhe.Size = new System.Drawing.Size(249, 132);
            this.pnl_Detalhe.TabIndex = 7;
            // 
            // tbox_Nm_Genero
            // 
            this.tbox_Nm_Genero.Location = new System.Drawing.Point(12, 85);
            this.tbox_Nm_Genero.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_Nm_Genero.MaxLength = 35;
            this.tbox_Nm_Genero.Name = "tbox_Nm_Genero";
            this.tbox_Nm_Genero.Size = new System.Drawing.Size(180, 20);
            this.tbox_Nm_Genero.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Nome";
            // 
            // tbox_Cod_Genero
            // 
            this.tbox_Cod_Genero.Enabled = false;
            this.tbox_Cod_Genero.Location = new System.Drawing.Point(12, 45);
            this.tbox_Cod_Genero.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_Cod_Genero.Name = "tbox_Cod_Genero";
            this.tbox_Cod_Genero.Size = new System.Drawing.Size(55, 20);
            this.tbox_Cod_Genero.TabIndex = 1;
            this.tbox_Cod_Genero.Tag = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Código";
            // 
            // pnl_Lista
            // 
            this.pnl_Lista.Controls.Add(this.lbox_Genero);
            this.pnl_Lista.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Lista.Location = new System.Drawing.Point(0, 76);
            this.pnl_Lista.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Lista.Name = "pnl_Lista";
            this.pnl_Lista.Size = new System.Drawing.Size(150, 132);
            this.pnl_Lista.TabIndex = 6;
            // 
            // lbox_Genero
            // 
            this.lbox_Genero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbox_Genero.FormattingEnabled = true;
            this.lbox_Genero.Location = new System.Drawing.Point(0, 0);
            this.lbox_Genero.Margin = new System.Windows.Forms.Padding(2);
            this.lbox_Genero.Name = "lbox_Genero";
            this.lbox_Genero.Size = new System.Drawing.Size(150, 132);
            this.lbox_Genero.TabIndex = 0;
            this.lbox_Genero.Click += new System.EventHandler(this.lbox_Genero_Click);
            // 
            // pnl_Botao
            // 
            this.pnl_Botao.BackColor = System.Drawing.Color.Thistle;
            this.pnl_Botao.Controls.Add(this.btn_Cancelar);
            this.pnl_Botao.Controls.Add(this.btn_Confirmar);
            this.pnl_Botao.Controls.Add(this.btn_Excluir);
            this.pnl_Botao.Controls.Add(this.btn_Alterar);
            this.pnl_Botao.Controls.Add(this.btn_Novo);
            this.pnl_Botao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Botao.Location = new System.Drawing.Point(0, 208);
            this.pnl_Botao.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Botao.Name = "pnl_Botao";
            this.pnl_Botao.Size = new System.Drawing.Size(399, 52);
            this.pnl_Botao.TabIndex = 5;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Location = new System.Drawing.Point(260, 11);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(62, 30);
            this.btn_Cancelar.TabIndex = 4;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Confirmar
            // 
            this.btn_Confirmar.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btn_Confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Confirmar.Location = new System.Drawing.Point(326, 11);
            this.btn_Confirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(62, 30);
            this.btn_Confirmar.TabIndex = 3;
            this.btn_Confirmar.Text = "Confirmar";
            this.btn_Confirmar.UseVisualStyleBackColor = true;
            this.btn_Confirmar.Click += new System.EventHandler(this.btn_Confirmar_Click);
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btn_Excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Excluir.Location = new System.Drawing.Point(150, 11);
            this.btn_Excluir.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Excluir.Name = "btn_Excluir";
            this.btn_Excluir.Size = new System.Drawing.Size(62, 30);
            this.btn_Excluir.TabIndex = 2;
            this.btn_Excluir.Text = "Excluir";
            this.btn_Excluir.UseVisualStyleBackColor = true;
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // btn_Alterar
            // 
            this.btn_Alterar.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btn_Alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Alterar.Location = new System.Drawing.Point(84, 11);
            this.btn_Alterar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Alterar.Name = "btn_Alterar";
            this.btn_Alterar.Size = new System.Drawing.Size(62, 30);
            this.btn_Alterar.TabIndex = 1;
            this.btn_Alterar.Text = "Alterar";
            this.btn_Alterar.UseVisualStyleBackColor = true;
            this.btn_Alterar.Click += new System.EventHandler(this.btn_Alterar_Click);
            // 
            // btn_Novo
            // 
            this.btn_Novo.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btn_Novo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Novo.Location = new System.Drawing.Point(18, 11);
            this.btn_Novo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Novo.Name = "btn_Novo";
            this.btn_Novo.Size = new System.Drawing.Size(62, 30);
            this.btn_Novo.TabIndex = 0;
            this.btn_Novo.Text = "Novo";
            this.btn_Novo.UseVisualStyleBackColor = true;
            this.btn_Novo.Click += new System.EventHandler(this.btn_Novo_Click);
            // 
            // pnl_Titulo
            // 
            this.pnl_Titulo.BackColor = System.Drawing.Color.Thistle;
            this.pnl_Titulo.Controls.Add(this.label5);
            this.pnl_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Titulo.Location = new System.Drawing.Point(0, 0);
            this.pnl_Titulo.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Titulo.Name = "pnl_Titulo";
            this.pnl_Titulo.Size = new System.Drawing.Size(399, 76);
            this.pnl_Titulo.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(280, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gênero";
            // 
            // Frm_Genero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 260);
            this.Controls.Add(this.pnl_Detalhe);
            this.Controls.Add(this.pnl_Lista);
            this.Controls.Add(this.pnl_Botao);
            this.Controls.Add(this.pnl_Titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Genero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_Genero";
            this.pnl_Detalhe.ResumeLayout(false);
            this.pnl_Detalhe.PerformLayout();
            this.pnl_Lista.ResumeLayout(false);
            this.pnl_Botao.ResumeLayout(false);
            this.pnl_Titulo.ResumeLayout(false);
            this.pnl_Titulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Detalhe;
        private System.Windows.Forms.TextBox tbox_Nm_Genero;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbox_Cod_Genero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnl_Lista;
        private System.Windows.Forms.ListBox lbox_Genero;
        private System.Windows.Forms.Panel pnl_Botao;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Confirmar;
        private System.Windows.Forms.Button btn_Excluir;
        private System.Windows.Forms.Button btn_Alterar;
        private System.Windows.Forms.Button btn_Novo;
        private System.Windows.Forms.Panel pnl_Titulo;
        private System.Windows.Forms.Label label5;
    }
}