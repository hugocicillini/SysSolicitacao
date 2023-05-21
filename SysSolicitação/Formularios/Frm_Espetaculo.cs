using SysSolicitação;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysSolicitação
{
    public partial class Frm_Espetaculo : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Espetaculo obj_Espetaculo_Atual = new Espetaculo();

        public Frm_Espetaculo()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.HabilitaTela(this, false);
            obj_FuncGeral.StatusBtn(this, 1);
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
            //instacia do objeto BDEspetaculo
            BDEspetaculo obj_BDEspetaculo = new BDEspetaculo();

            //Instacia da lista que receberá a lista que chegará do Banco
            List<Espetaculo> LstEspetaculo = new List<Espetaculo>();

            //Limpa Lista
            lbox_Espetaculo.Items.Clear();

            LstEspetaculo = obj_BDEspetaculo.FindAll();

            if (LstEspetaculo != null)
            {
                for (int i = 0; i < LstEspetaculo.Count; i++)
                {
                    lbox_Espetaculo.Items.Add(LstEspetaculo[i].Cod_Espetaculo.ToString() + "-" + LstEspetaculo[i].Nm_Espetaculo);
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
        private void PopulaTela(Espetaculo pobj_Espetaculo)
        {
            if (pobj_Espetaculo.Cod_Espetaculo != -1)
            {
                tbox_Cod_Espetaculo.Text = pobj_Espetaculo.Cod_Espetaculo.ToString();
                tbox_Cod_Artista.Text = pobj_Espetaculo.Cod_Artista.ToString();
                tbox_Nm_Espetaculo.Text = pobj_Espetaculo.Nm_Espetaculo.ToString();
                tbox_Data_Espetaculo.Text = pobj_Espetaculo.DtHr_Espetaculo.ToString("dd/MM/yyyy");
                tbox_Hora_Espetaculo.Text = pobj_Espetaculo.DtHr_Espetaculo.ToString("HH:mm");

            }
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
        private Espetaculo PopulaObjeto()
        {
            Espetaculo obj_Espetaculo = new Espetaculo();

            if (tbox_Cod_Espetaculo.Text != "")
            {
                obj_Espetaculo.Cod_Espetaculo = int.Parse(tbox_Cod_Espetaculo.Text);
            }

            obj_Espetaculo.Cod_Artista = int.Parse(tbox_Cod_Artista.Text);
            obj_Espetaculo.Nm_Espetaculo= (tbox_Nm_Espetaculo.Text).ToString();
            obj_Espetaculo.DtHr_Espetaculo = Convert.ToDateTime(tbox_Data_Espetaculo.Text + " " + tbox_Hora_Espetaculo.Text);

            return obj_Espetaculo;
        }


        private void btn_Novo_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Limpa os componentes da tela para edição
            obj_FuncGeral.LimpaTela(this);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Cod_Espetaculo.Focus();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Nm_Espetaculo.Focus();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            //Desabilita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, false);

            if (obj_Espetaculo_Atual.Cod_Espetaculo != -1)
            {
                PopulaTela(obj_Espetaculo_Atual);
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
            BDEspetaculo obj_BDEspetaculo = new BDEspetaculo();


            DialogResult varResp = MessageBox.Show("Confima a Exclusão deste Registro?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (varResp == DialogResult.Yes)
            {
                if (obj_BDEspetaculo.Excluir(obj_Espetaculo_Atual))
                {
                    MessageBox.Show("O Espetaculo " + obj_Espetaculo_Atual.Nm_Espetaculo + " foi excluido com sucesso.", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            BDEspetaculo obj_BDEspetaculo = new BDEspetaculo();

            obj_Espetaculo_Atual = PopulaObjeto();

            if (obj_Espetaculo_Atual.Cod_Espetaculo != -1)
            {
                obj_BDEspetaculo.Alterar(obj_Espetaculo_Atual);
                MessageBox.Show("O Espetaculo " + obj_Espetaculo_Atual.Nm_Espetaculo + " foi Alterada com sucesso.", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj_Espetaculo_Atual.Cod_Espetaculo = obj_BDEspetaculo.Incluir(obj_Espetaculo_Atual);
                PopulaTela(obj_Espetaculo_Atual);
                MessageBox.Show("O Espetaculo " + obj_Espetaculo_Atual.Nm_Espetaculo + " foi Incluida com sucesso.", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);

        }

        private void lbox_Espetaculo_Click(object sender, EventArgs e)
        {
            {
                BDEspetaculo obj_BDEspetaculo = new BDEspetaculo();

                string sLinha = lbox_Espetaculo.Items[lbox_Espetaculo.SelectedIndex].ToString();
                int iPos = 0;

                for (int t = 0; t < sLinha.Length; t++)
                {
                    if (sLinha.Substring(t, 1) == "-")
                    {
                        iPos = t;
                        break;
                    }
                }

                obj_Espetaculo_Atual.Cod_Espetaculo = int.Parse(sLinha.Substring(0, iPos));
                obj_Espetaculo_Atual = obj_BDEspetaculo.FindByCod(obj_Espetaculo_Atual);
                PopulaTela(obj_Espetaculo_Atual);
                obj_FuncGeral.StatusBtn(this, 2);
                obj_FuncGeral.HabilitaTela(this, false);

            }
        }

        private void btn_Artista_Click(object sender, EventArgs e)
        {
            Frm_Artista obj_Frm_Artista = new Frm_Artista();
            obj_Frm_Artista.ShowDialog();
            tbox_Cod_Artista.Text = obj_Frm_Artista.obj_Artista_Atual.Cod_Artista.ToString();
            tbox_Cod_Artista_Leave(sender, e);
        }

        private void tbox_Cod_Artista_Leave(object sender, EventArgs e)
        {
            if (tbox_Cod_Artista.Text != "")
            {
                Artista obj_Artista = new Artista();
                BDArtista obj_BDArtista = new BDArtista();

                obj_Artista.Cod_Artista = int.Parse(tbox_Cod_Artista.Text);

                obj_Artista = obj_BDArtista.FindByCod(obj_Artista);

                if (obj_Artista.Cod_Artista != -1)
                {
                    lb_Nm_Artista.Text = obj_Artista.Nm_Artista;
                }
                else
                {
                    tbox_Cod_Artista.Clear();
                    lb_Nm_Artista.Text = "";
                }

            }

        }
    }
}
