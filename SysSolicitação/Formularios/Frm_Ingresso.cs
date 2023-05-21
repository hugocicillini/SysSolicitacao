using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SysSolicitação
{
    public partial class Frm_Ingresso : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Pedido obj_Pedido_Atual = new Pedido();
        public Frm_Ingresso()
        {
            InitializeComponent();
            obj_FuncGeral.HabilitaTela(this, false);
            obj_FuncGeral.StatusBtn(this, 1);
            PopulaTitulos_Lv();
        }

        private void PopulaTitulos_Lv()
        {
            lv_Ingresso.View = View.Details;
            lv_Ingresso.Columns.Add("Código", 60);
            lv_Ingresso.Columns.Add("Espetáculo", 100);
            lv_Ingresso.Columns.Add("Valor", 80);
            lv_Ingresso.Columns.Add("Desconto", 80);
            lv_Ingresso.Columns.Add("Quantidade", 80);
            lv_Ingresso.Columns.Add("Sub Total", 80);
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoArquivo = Path.Combine(diretorioBase, "Agenda.txt");

            System.Diagnostics.Process.Start(caminhoArquivo);

            DialogResult varResp = MessageBox.Show("Ingresso Impresso!", "Impressão", MessageBoxButtons.OK);
            if (varResp == DialogResult.OK)
            {
                Close();
            }
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_Ingresso_Load(object sender, EventArgs e)
        {
            Item_Pedido obj_Item_Pedido = new Item_Pedido();
            obj_Item_Pedido.Cod_Pedido = obj_Pedido_Atual.Cod_Pedido;

            BDItem_Pedido obj_BDItem_Pedido = new BDItem_Pedido();

            List<Item_Pedido> ListaItens = new List<Item_Pedido>();
            ListaItens = obj_BDItem_Pedido.FindAll(obj_Item_Pedido);

            double d_VrlDesc = 0;

            for (int i = 0; i < ListaItens.Count; i++)
            {
                d_VrlDesc = obj_FuncGeral.CalSubTotItem(ListaItens[i].Vlr_Item_Pedido, ListaItens[i].Desc_Item_Pedido, ListaItens[i].Quant_Item_Pedido);

                PopulaLinhaLv(lv_Ingresso, ListaItens[i].Cod_Espetaculo.ToString(), ListaItens[i].Vlr_Item_Pedido.ToString(), ListaItens[i].Desc_Item_Pedido.ToString(), ListaItens[i].Quant_Item_Pedido.ToString(), d_VrlDesc.ToString("f"));
            }

            for (int t = 0; t < lv_Ingresso.Items.Count; t++)
            {
                obj_Item_Pedido.Cod_Espetaculo = Convert.ToInt16(lv_Ingresso.Items[t].SubItems[0].Text);
                obj_Item_Pedido.Desc_Item_Pedido = Convert.ToDouble(lv_Ingresso.Items[t].SubItems[2].Text);
                obj_Item_Pedido.Quant_Item_Pedido = Convert.ToInt16(lv_Ingresso.Items[t].SubItems[3].Text);
            }
        }

        private void PopulaLinhaLv(ListView lv_Atual, string CodEspetaculo, string VlrIngresso, string Desct, string Quant, string SubTotal)
        {
            Espetaculo obj_Espetaculo = new Espetaculo();
            BDEspetaculo obj_BDEspetaculo = new BDEspetaculo();

            obj_Espetaculo.Cod_Espetaculo = Convert.ToInt16(CodEspetaculo);

            obj_Espetaculo = obj_BDEspetaculo.FindByCod(obj_Espetaculo);


            ListViewItem item = new ListViewItem(new[] { CodEspetaculo, obj_Espetaculo.Nm_Espetaculo, VlrIngresso, Desct, Quant, SubTotal });
            lv_Atual.Items.Add(item);


            geraTicket(obj_Espetaculo.Nm_Espetaculo, VlrIngresso, Desct, Quant);
        }

        private void geraTicket(string Nm_Espetaculo, string VlrIngresso, string Desct, string Quant)
        {


            string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoArquivo = Path.Combine(diretorioBase, "Agenda.txt");
            StreamWriter psw = new StreamWriter(caminhoArquivo, true);

            Random random = new Random(DateTime.Now.Millisecond);
            int randomNumber;

            for (int i = 0; i < Convert.ToInt16(Quant); i++)
            {
                randomNumber = random.Next();
                psw.WriteLine("-------------------------------------------");
                psw.WriteLine("        Código:             " + randomNumber);
                psw.WriteLine("    Espetáculo:             " + Nm_Espetaculo);
                psw.WriteLine("         Valor:             " + "R$" + Convert.ToDouble(VlrIngresso) * (1 - Convert.ToDouble(Desct) / 100));
                psw.WriteLine("          Desc:             " + Desct + "%");
                psw.WriteLine("-------------------------------------------");
            }
            psw.Close();
        }
    }
}
