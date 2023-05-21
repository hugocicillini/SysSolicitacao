namespace SysSolicitação
{
    partial class Frm_Ingresso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Ingresso));
            this.pnl_Botao = new System.Windows.Forms.Panel();
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.btn_Voltar = new System.Windows.Forms.Button();
            this.pnl_Titulo = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lv_Ingresso = new System.Windows.Forms.ListView();
            this.pnl_Botao.SuspendLayout();
            this.pnl_Titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Botao
            // 
            this.pnl_Botao.BackColor = System.Drawing.Color.Thistle;
            this.pnl_Botao.Controls.Add(this.btn_Imprimir);
            this.pnl_Botao.Controls.Add(this.btn_Voltar);
            this.pnl_Botao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Botao.Location = new System.Drawing.Point(0, 409);
            this.pnl_Botao.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Botao.Name = "pnl_Botao";
            this.pnl_Botao.Size = new System.Drawing.Size(484, 52);
            this.pnl_Botao.TabIndex = 19;
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btn_Imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Imprimir.Location = new System.Drawing.Point(415, 11);
            this.btn_Imprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(62, 30);
            this.btn_Imprimir.TabIndex = 4;
            this.btn_Imprimir.Text = "Imprimir";
            this.btn_Imprimir.UseVisualStyleBackColor = true;
            this.btn_Imprimir.Click += new System.EventHandler(this.btn_Imprimir_Click);
            // 
            // btn_Voltar
            // 
            this.btn_Voltar.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btn_Voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Voltar.Location = new System.Drawing.Point(12, 11);
            this.btn_Voltar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Voltar.Name = "btn_Voltar";
            this.btn_Voltar.Size = new System.Drawing.Size(62, 30);
            this.btn_Voltar.TabIndex = 0;
            this.btn_Voltar.Text = "Voltar";
            this.btn_Voltar.UseVisualStyleBackColor = true;
            this.btn_Voltar.Click += new System.EventHandler(this.btn_Voltar_Click);
            // 
            // pnl_Titulo
            // 
            this.pnl_Titulo.BackColor = System.Drawing.Color.Thistle;
            this.pnl_Titulo.Controls.Add(this.label5);
            this.pnl_Titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Titulo.Location = new System.Drawing.Point(0, 0);
            this.pnl_Titulo.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Titulo.Name = "pnl_Titulo";
            this.pnl_Titulo.Size = new System.Drawing.Size(484, 76);
            this.pnl_Titulo.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(371, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ingresso";
            // 
            // lv_Ingresso
            // 
            this.lv_Ingresso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Ingresso.FullRowSelect = true;
            this.lv_Ingresso.GridLines = true;
            this.lv_Ingresso.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_Ingresso.HideSelection = false;
            this.lv_Ingresso.Location = new System.Drawing.Point(0, 76);
            this.lv_Ingresso.Margin = new System.Windows.Forms.Padding(2);
            this.lv_Ingresso.MultiSelect = false;
            this.lv_Ingresso.Name = "lv_Ingresso";
            this.lv_Ingresso.Size = new System.Drawing.Size(484, 333);
            this.lv_Ingresso.TabIndex = 36;
            this.lv_Ingresso.UseCompatibleStateImageBehavior = false;
            // 
            // Frm_Ingresso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.lv_Ingresso);
            this.Controls.Add(this.pnl_Botao);
            this.Controls.Add(this.pnl_Titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Ingresso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_Ingresso";
            this.Load += new System.EventHandler(this.Frm_Ingresso_Load);
            this.pnl_Botao.ResumeLayout(false);
            this.pnl_Titulo.ResumeLayout(false);
            this.pnl_Titulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Botao;
        private System.Windows.Forms.Button btn_Imprimir;
        private System.Windows.Forms.Button btn_Voltar;
        private System.Windows.Forms.Panel pnl_Titulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lv_Ingresso;
    }
}