using SysSolicitação;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysSolicitação
{
    public partial class Frm_Genero : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Genero obj_Genero_Atual = new Genero();

        public Frm_Genero()
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
            //instacia do objeto BDGenero
            BDGenero obj_BDGenero = new BDGenero();

            //Instacia da lista que receberá a lista que chegará do Banco
            List<Genero> LstGenero = new List<Genero>();

            //Limpa Lista
            lbox_Genero.Items.Clear();

            LstGenero = obj_BDGenero.FindAll();

            if (LstGenero != null)
            {
                for (int i = 0; i < LstGenero.Count; i++)
                {
                    lbox_Genero.Items.Add(LstGenero[i].Cod_Genero.ToString() + "-" + LstGenero[i].Nm_Genero);
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
        private void PopulaTela(Genero pobj_Genero)
        {
            if (pobj_Genero.Cod_Genero != -1)
            {
                tbox_Cod_Genero.Text = pobj_Genero.Cod_Genero.ToString();
                tbox_Nm_Genero.Text = pobj_Genero.Nm_Genero;
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
        private Genero PopulaObjeto()
        {
            Genero obj_Genero = new Genero();

            if (tbox_Cod_Genero.Text != "")
            {
                obj_Genero.Cod_Genero = int.Parse(tbox_Cod_Genero.Text);
            }

            obj_Genero.Nm_Genero = tbox_Nm_Genero.Text;

            return obj_Genero;
        }


        private void btn_Novo_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Limpa os componentes da tela para edição
            obj_FuncGeral.LimpaTela(this);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Nm_Genero.Focus();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Nm_Genero.Focus();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            //Desabilita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, false);

            if (obj_Genero_Atual.Cod_Genero != -1)
            {
                PopulaTela(obj_Genero_Atual);
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
            BDGenero obj_BDGenero = new BDGenero();


            DialogResult varResp = MessageBox.Show("Confima a Exclusão deste Registro?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (varResp == DialogResult.Yes)
            {
                if (obj_BDGenero.Excluir(obj_Genero_Atual))
                {
                    MessageBox.Show("A cor " + obj_Genero_Atual.Nm_Genero + " foi excluida com sucesso.", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            BDGenero obj_BDGenero = new BDGenero();

            obj_Genero_Atual = PopulaObjeto();

            if (obj_Genero_Atual.Cod_Genero != -1)
            {
                obj_BDGenero.Alterar(obj_Genero_Atual);
                MessageBox.Show("O Gênero " + obj_Genero_Atual.Nm_Genero + " foi alterado com sucesso.", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj_Genero_Atual.Cod_Genero = obj_BDGenero.Incluir(obj_Genero_Atual);
                PopulaTela(obj_Genero_Atual);
                MessageBox.Show("O Gênero " + obj_Genero_Atual.Nm_Genero + " foi Incluido com sucesso.", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);

        }

        private void lbox_Genero_Click(object sender, EventArgs e)
        {
            BDGenero obj_BDCor = new BDGenero();

            string sLinha = lbox_Genero.Items[lbox_Genero.SelectedIndex].ToString();
            int iPos = 0;

            for (int t = 0; t < sLinha.Length; t++)
            {
                if (sLinha.Substring(t, 1) == "-")
                {
                    iPos = t;
                    break;
                }
            }

            obj_Genero_Atual.Cod_Genero = int.Parse(sLinha.Substring(0, iPos));
            obj_Genero_Atual = obj_BDCor.FindByCod(obj_Genero_Atual);
            PopulaTela(obj_Genero_Atual);
            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);

        }
    }
}
