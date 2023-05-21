using SysSolicitação;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysSolicitação
{
    public partial class Frm_Pedido : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Pedido obj_Pedido_Atual = new Pedido();

        public Frm_Pedido()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.HabilitaTela(this, false);
            obj_FuncGeral.StatusBtn(this, 1);
            PopulaTitulos_Lv();
        }

        private void PopulaTitulos_Lv()
        {
            lv_Item_Pedido.View = View.Details;
            lv_Item_Pedido.Columns.Add("Código", 60);
            lv_Item_Pedido.Columns.Add("Espetáculo", 150);
            lv_Item_Pedido.Columns.Add("Valor", 100);
            lv_Item_Pedido.Columns.Add("Desconto", 100);
            lv_Item_Pedido.Columns.Add("Quantidade", 100);
            lv_Item_Pedido.Columns.Add("Sub Total", 100);
        }

        /****************************************************************************************
        *              Método: PopulaLista
        *                Obs.: Responsável por preencher a lista com os registros que estão no 
        *                      banco de dados
        *         Dt. Criação: 18/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: --
        ****************************************************************************************/
        private void PopulaLista()
        {
            //instacia do objeto BDPedido
            BDPedido obj_BDPedido = new BDPedido();

            //Instacia da lista que receberá a lista que chegará do Banco
            List<Pedido> LstPedido = new List<Pedido>();

            //Limpa Lista
            lbox_Pedido.Items.Clear();

            LstPedido = obj_BDPedido.FindAll();

            if (LstPedido != null)
            {
                for (int i = 0; i < LstPedido.Count; i++)
                {
                    lbox_Pedido.Items.Add(LstPedido[i].Cod_Pedido.ToString() + "-" + "Compra n°" + i);
                }
            }
        }


        /****************************************************************************************
        *              Método: PopulaTela
        *                Obs.: Responsável por preencher os objetos editáveis da Tela.
        *         Dt. Criação: 18/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: --
        ****************************************************************************************/
        private void PopulaTela(Pedido pobj_Pedido)
        {
            EventArgs e = new EventArgs();

            if (pobj_Pedido.Cod_Pedido != -1)
            {
                tbox_Cod_Pedido.Text = pobj_Pedido.Cod_Pedido.ToString();
                tbox_Cod_Funcionario.Text = pobj_Pedido.Cod_Funcionario.ToString();
                tbox_Cod_Funcionario_Leave(tbox_Cod_Funcionario, e);
                tbox_Cod_Cliente.Text = pobj_Pedido.Cod_Cliente.ToString();
                tbox_Cod_Cliente_Leave(tbox_Cod_Cliente, e);    
                lb_Hora_Pedido.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            }

            lb_Total.Text = obj_FuncGeral.CalTotPedido(lv_Item_Pedido).ToString("f");
        }


        /****************************************************************************************
        *              Método: PopulaObjeto
        *                Obs.: Responsável por preencher o objeto com o conteúdo dos objetos 
        *                      editáveis da Tela.
        *         Dt. Criação: 18/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: --
        ****************************************************************************************/
        private Pedido PopulaObjeto()
        {
            Pedido obj_Pedido = new Pedido();

            if (tbox_Cod_Pedido.Text != "")
            {
                obj_Pedido.Cod_Pedido = int.Parse(tbox_Cod_Pedido.Text);
            }

            obj_Pedido.Cod_Funcionario = int.Parse(tbox_Cod_Funcionario.Text);
            obj_Pedido.Cod_Cliente = int.Parse(tbox_Cod_Cliente.Text);
            obj_Pedido.DtHr_Pedido = Convert.ToDateTime(lb_Hora_Pedido.Text);

            return obj_Pedido;
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Limpa os componentes da tela para edição
            obj_FuncGeral.LimpaTela(this);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Cod_Funcionario.Focus();

            lb_Nm_Cliente.Text = "";
            lb_Nm_Funcionario.Text = "";
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Cod_Funcionario.Focus();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            //Desabilita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, false);

            if (obj_Pedido_Atual.Cod_Pedido != -1)
            {
                PopulaTela(obj_Pedido_Atual);
                obj_FuncGeral.StatusBtn(this, 2);
            }
            else
            {
                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.StatusBtn(this, 1);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            BDPedido obj_BDPedido = new BDPedido();
            BDItem_Pedido obj_BDItemPedido = new BDItem_Pedido();

            Item_Pedido obj_Item_Pedido = new Item_Pedido();

            DialogResult varResp = MessageBox.Show("Confima a Exclusão deste Registro?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (varResp == DialogResult.Yes)
            {
                if(lv_Item_Pedido.Items.Count != 0)
                {
                    obj_Item_Pedido.Cod_Pedido = obj_Pedido_Atual.Cod_Pedido;

                    obj_BDItemPedido.Excluir(obj_Item_Pedido);
                }

                if (obj_BDPedido.Excluir(obj_Pedido_Atual))
                {
                    MessageBox.Show("O Pedido " + obj_Pedido_Atual.Cod_Pedido + " foi excluida com sucesso.", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Halibita os componentes da tela para edição
                obj_FuncGeral.HabilitaTela(this, false);

                //Limpa os componentes da tela para edição
                obj_FuncGeral.LimpaTela(this);

                //Ajustar o status dos Botões
                obj_FuncGeral.StatusBtn(this, 1);

                //pupulo a lista novamente
                PopulaLista();

            }

        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            BDPedido obj_BDPedido = new BDPedido();
            
            BDItem_Pedido obj_BDItem_Pedido = new BDItem_Pedido();

            Item_Pedido obj_Item_Pedido = new Item_Pedido();

            Frm_Ingresso obj_Frm_Ingresso = new Frm_Ingresso();

            obj_Pedido_Atual = PopulaObjeto();

            if (obj_Pedido_Atual.Cod_Pedido != -1)
            {
                obj_BDPedido.Alterar(obj_Pedido_Atual);
                MessageBox.Show("O Pedido " + obj_Pedido_Atual.Cod_Pedido + " foi Alterado com sucesso.", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                obj_Pedido_Atual.Cod_Pedido = obj_BDPedido.Incluir(obj_Pedido_Atual);
                PopulaTela(obj_Pedido_Atual);
                MessageBox.Show("O Pedido " + obj_Pedido_Atual.Cod_Pedido + " foi Incluido com sucesso.", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);

            if (lv_Item_Pedido.Items.Count != 0)
            {
                obj_Item_Pedido.Cod_Pedido = Convert.ToInt16(tbox_Cod_Pedido.Text);

                obj_BDItem_Pedido.Excluir(obj_Item_Pedido);

                for (int t = 0; t < lv_Item_Pedido.Items.Count; t++)
                {
                    obj_Item_Pedido.Cod_Pedido = Convert.ToInt16(tbox_Cod_Pedido.Text);
                    obj_Item_Pedido.Cod_Espetaculo = Convert.ToInt16(lv_Item_Pedido.Items[t].SubItems[0].Text);
                    obj_Item_Pedido.Vlr_Item_Pedido = Convert.ToDouble(lv_Item_Pedido.Items[t].SubItems[2].Text);
                    obj_Item_Pedido.Desc_Item_Pedido = Convert.ToDouble(lv_Item_Pedido.Items[t].SubItems[3].Text);
                    obj_Item_Pedido.Quant_Item_Pedido = Convert.ToInt16(lv_Item_Pedido.Items[t].SubItems[4].Text);

                    obj_BDItem_Pedido.Incluir(obj_Item_Pedido);
                }

            }
            obj_Frm_Ingresso.obj_Pedido_Atual.Cod_Pedido = obj_Pedido_Atual.Cod_Pedido;
            obj_Frm_Ingresso.ShowDialog();


        }

        private void lbox_Pedido_Click(object sender, EventArgs e)
        {
            {
                BDPedido obj_BDPedido = new BDPedido();
                BDItem_Pedido obj_BDItem_Pedido = new BDItem_Pedido();
                Item_Pedido obj_Item_Pedido = new Item_Pedido();

                List<Item_Pedido> ListaItens = new List<Item_Pedido>();

                string sLinha = lbox_Pedido.Items[lbox_Pedido.SelectedIndex].ToString();
                int iPos = 0;   

                for (int t = 0; t < sLinha.Length; t++)
                {
                    if (sLinha.Substring(t, 1) == "-")
                    {
                        iPos = t;
                        break;
                    }
                }


                obj_Pedido_Atual.Cod_Pedido = int.Parse(sLinha.Substring(0, iPos));
                obj_Pedido_Atual = obj_BDPedido.FindByCod(obj_Pedido_Atual);
                obj_Item_Pedido.Cod_Pedido = obj_Pedido_Atual.Cod_Pedido;

                ListaItens = obj_BDItem_Pedido.FindAll(obj_Item_Pedido);

                double d_VrlDesc = 0;

                lv_Item_Pedido.Items.Clear();

                if (ListaItens != null)
                {
                    for (int i = 0; i < ListaItens.Count; i++)
                    {
                        d_VrlDesc = obj_FuncGeral.CalSubTotItem(ListaItens[i].Vlr_Item_Pedido, ListaItens[i].Desc_Item_Pedido, ListaItens[i].Quant_Item_Pedido);

                        PopulaLinhaLv(lv_Item_Pedido, ListaItens[i].Cod_Espetaculo.ToString(), ListaItens[i].Vlr_Item_Pedido.ToString(), ListaItens[i].Desc_Item_Pedido.ToString(), ListaItens[i].Quant_Item_Pedido.ToString(), d_VrlDesc.ToString("f"));
                    }
                }

                PopulaTela(obj_Pedido_Atual);
                obj_FuncGeral.StatusBtn(this, 2);
                obj_FuncGeral.HabilitaTela(this, false);

            }
        }

        private void btn_Funcionario_Click(object sender, EventArgs e)
        {
            Frm_Funcionario obj_Frm_Funcionario = new Frm_Funcionario();
            obj_Frm_Funcionario.ShowDialog();
            tbox_Cod_Funcionario.Text = obj_Frm_Funcionario.obj_Funcionario_Atual.Cod_Funcionario.ToString();
            tbox_Cod_Funcionario_Leave(sender, e);
        }

        private void btn_Cliente_Click(object sender, EventArgs e)
        {
            Frm_Cliente obj_Frm_Cliente = new Frm_Cliente();
            obj_Frm_Cliente.ShowDialog();
            tbox_Cod_Cliente.Text = obj_Frm_Cliente.obj_Cliente_Atual.Cod_Cliente.ToString();
            tbox_Cod_Cliente_Leave(sender, e);
        }


        private void btn_Espetaculo_Click(object sender, EventArgs e)
        {
            Frm_Espetaculo obj_Frm_Espetaculo = new Frm_Espetaculo();
            obj_Frm_Espetaculo.ShowDialog();
            tbox_Cod_Espetaculo.Text = obj_Frm_Espetaculo.obj_Espetaculo_Atual.Cod_Espetaculo.ToString();
            tbox_Cod_Espetaculo_Leave(sender, e);
        }



        private void tbox_Cod_Cliente_Leave(object sender, EventArgs e)
        {
            if (tbox_Cod_Cliente.Text != "")
            {
                Cliente obj_Cliente = new Cliente();
                BDCliente obj_BDCliente = new BDCliente();

                obj_Cliente.Cod_Cliente = int.Parse(tbox_Cod_Cliente.Text);

                obj_Cliente = obj_BDCliente.FindByCod(obj_Cliente);

                if (obj_Cliente.Cod_Cliente != -1)
                {
                    lb_Nm_Cliente.Text = obj_Cliente.Nm_Cliente;
                }
                else
                {
                    tbox_Cod_Cliente.Clear();
                    lb_Nm_Cliente.Text = "";
                }

            }
        }


        private void tbox_Cod_Funcionario_Leave(object sender, EventArgs e)
        {
            if (tbox_Cod_Funcionario.Text != "")
            {
                Funcionario obj_Funcionario = new Funcionario();
                BDFuncionario obj_BDFuncionario = new BDFuncionario();

                obj_Funcionario.Cod_Funcionario = int.Parse(tbox_Cod_Funcionario.Text);

                obj_Funcionario = obj_BDFuncionario.FindByCod(obj_Funcionario);

                if (obj_Funcionario.Cod_Funcionario != -1)
                {
                    lb_Nm_Funcionario.Text = obj_Funcionario.Nm_Funcionario;
                }
                else
                {
                    tbox_Cod_Funcionario.Clear();
                    lb_Nm_Funcionario.Text = "";
                }
            }
        }

        private void tbox_Cod_Espetaculo_Leave(object sender, EventArgs e)
        {
            if (tbox_Cod_Espetaculo.Text != "")
            {
                Espetaculo obj_Espetaculo = new Espetaculo();
                BDEspetaculo obj_BDEspetaculo = new BDEspetaculo();

                obj_Espetaculo.Cod_Espetaculo = int.Parse(tbox_Cod_Espetaculo.Text);

                obj_Espetaculo = obj_BDEspetaculo.FindByCod(obj_Espetaculo);

                if (obj_Espetaculo.Cod_Espetaculo != -1)
                {
                    lb_Nm_Espetaculo.Text = obj_Espetaculo.Nm_Espetaculo;
                }
                else
                {
                    tbox_Cod_Espetaculo.Clear();
                    lb_Nm_Espetaculo.Text = "";
                }
            }
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            if (tbox_Vlr.Text != "")
            {
                if (tbox_Dsct.Text == "")
                {
                    tbox_Dsct.Text = "0";
                }

                if (tbox_Qntd.Text == "")
                {
                    tbox_Qntd.Text = "1";
                }

                PopulaLinhaLv(lv_Item_Pedido, tbox_Cod_Espetaculo.Text, tbox_Vlr.Text, tbox_Dsct.Text, tbox_Qntd.Text, lb_SubTotal.Text);

                tbox_Cod_Espetaculo.Clear();
                tbox_Vlr.Clear();
                tbox_Dsct.Clear();
                tbox_Qntd.Clear();
                lb_SubTotal.Text = "";
                lb_Nm_Espetaculo.Text = "";

                lb_Total.Text = obj_FuncGeral.CalTotPedido(lv_Item_Pedido).ToString("f");

            }
            else
            {
                MessageBox.Show("Preencha todos os campos do Item.", "Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PopulaLinhaLv(ListView lv_Atual,string CodEspetaculo, string VlrIngresso, string Desct, string Quant, string SubTotal)
        {
            //Pedido obj_Pedido = new Pedido();
            //BDPedido obj_BDPedido= new BDPedido();

            //obj_Pedido.Cod_Pedido = Convert.ToInt16(CodEspetaculo);

            //obj_Pedido = obj_BDPedido.FindByCod(obj_Pedido);

            Espetaculo obj_Espetaculo = new Espetaculo();
            BDEspetaculo obj_BDEspetaculo = new BDEspetaculo();

            obj_Espetaculo.Cod_Espetaculo = Convert.ToInt16(CodEspetaculo);

            obj_Espetaculo = obj_BDEspetaculo.FindByCod(obj_Espetaculo);

            ListViewItem item = new ListViewItem(new[] { CodEspetaculo, obj_Espetaculo.Nm_Espetaculo, VlrIngresso, Desct, Quant, SubTotal });
            lv_Atual.Items.Add(item);
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            if (lv_Item_Pedido.SelectedItems != null)
            {
                var Confirma = MessageBox.Show("Deseja retirar este item da lista?", "Retira Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Confirma == DialogResult.Yes)
                {
                    for (int i = 0; i < lv_Item_Pedido.Items.Count; i++)
                    {
                        if (lv_Item_Pedido.Items[i].Selected)
                        {
                            tbox_Cod_Espetaculo.Text = lv_Item_Pedido.Items[i].SubItems[0].Text;
                            tbox_Cod_Espetaculo_Leave(tbox_Cod_Espetaculo, e);

                            tbox_Vlr.Text = lv_Item_Pedido.Items[i].SubItems[2].Text;
                            tbox_Dsct.Text = lv_Item_Pedido.Items[i].SubItems[3].Text;
                            tbox_Qntd.Text = lv_Item_Pedido.Items[i].SubItems[4].Text;
                            lb_SubTotal.Text = lv_Item_Pedido.Items[i].SubItems[5].Text;

                            lv_Item_Pedido.Items[i].Remove();
                            i--;
                        }
                    }

                    lb_Total.Text = obj_FuncGeral.CalTotPedido(lv_Item_Pedido).ToString("f");
                }

            }
            else
            {
                MessageBox.Show("Item não selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calSubTot_Leave(object sender, EventArgs e)
        {
            double d_vlr = 0, d_desc = 0;
            int i_quant = 0;

            if (tbox_Vlr.Text != "")
            {
                d_vlr = Convert.ToDouble(tbox_Vlr.Text);

                if (tbox_Dsct.Text != "")
                {
                    d_desc = Convert.ToDouble(tbox_Dsct.Text);
                }
                else
                {
                    d_desc = 0;
                }

                if (tbox_Qntd.Text != "")
                {
                    i_quant= Convert.ToInt16(tbox_Qntd.Text);
                }
                else
                {
                    i_quant = 1;
                }

                lb_SubTotal.Text = obj_FuncGeral.CalSubTotItem(d_vlr, d_desc, i_quant).ToString("f");
            }
        }


        private void tbox_Vlr_Leave(object sender, EventArgs e)
        {
            calSubTot_Leave(sender, e);
        }

        private void tbox_Dsct_Leave(object sender, EventArgs e)
        {
            calSubTot_Leave(sender, e);
        }

        private void tbox_Qntd_Leave(object sender, EventArgs e)
        {
            calSubTot_Leave(sender, e);
        }

        private void Frm_Pedido_Load(object sender, EventArgs e)
        {
            lb_Hora_Pedido.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
    }
}   
