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
    public partial class Frm_Artista : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Artista obj_Artista_Atual = new Artista();

        public Frm_Artista()
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
            //instacia do objeto BDArtista
            BDArtista obj_BDArtista = new BDArtista();

            //Instacia da lista que receberá a lista que chegará do Banco
            List<Artista> LstArtista = new List<Artista>();

            //Limpa Lista
            lbox_Artista.Items.Clear();

            LstArtista = obj_BDArtista.FindAll();

            if (LstArtista != null)
            {
                for (int i = 0; i < LstArtista.Count; i++)
                {
                    lbox_Artista.Items.Add(LstArtista[i].Cod_Artista.ToString() + "-" + LstArtista[i].Nm_Artista);
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
        private void PopulaTela(Artista pobj_Artista)
        {
            if (pobj_Artista.Cod_Artista != -1)
            {
                tbox_Cod_Artista.Text = pobj_Artista.Cod_Artista.ToString();
                tbox_Cod_Genero.Text = pobj_Artista.Cod_Genero.ToString();
                tbox_Nm_Artista.Text = pobj_Artista.Nm_Artista;
                
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
        private Artista PopulaObjeto()
        {
            Artista obj_Artista = new Artista();

            if (tbox_Cod_Artista.Text != "")
            {
                obj_Artista.Cod_Artista = int.Parse(tbox_Cod_Artista.Text);
            }

            obj_Artista.Nm_Artista = tbox_Nm_Artista.Text;
            obj_Artista.Cod_Genero = int.Parse(tbox_Cod_Genero.Text);

            return obj_Artista;
        }


        private void btn_Novo_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Limpa os componentes da tela para edição
            obj_FuncGeral.LimpaTela(this);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Cod_Artista.Focus();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Cod_Artista.Focus();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            //Desabilita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, false);

            if (obj_Artista_Atual.Cod_Artista != -1)
            {
                PopulaTela(obj_Artista_Atual);
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
            BDArtista obj_BDArtista = new BDArtista();


            DialogResult varResp = MessageBox.Show("Confima a Exclusão deste Registro?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (varResp == DialogResult.Yes)
            {
                if (obj_BDArtista.Excluir(obj_Artista_Atual))
                {
                    MessageBox.Show("O Artista " + obj_Artista_Atual.Nm_Artista + " foi excluida com sucesso.", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            BDArtista obj_BDArtista = new BDArtista();

            obj_Artista_Atual = PopulaObjeto();

            if (obj_Artista_Atual.Cod_Artista != -1)
            {
                obj_BDArtista.Alterar(obj_Artista_Atual);
                MessageBox.Show("A Artista " + obj_Artista_Atual.Nm_Artista + " foi Alterada com sucesso.", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj_Artista_Atual.Cod_Artista = obj_BDArtista.Incluir(obj_Artista_Atual);
                PopulaTela(obj_Artista_Atual);
                MessageBox.Show("A Artista " + obj_Artista_Atual.Nm_Artista + " foi Incluida com sucesso.", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);

        }

        private void lbox_Artista_Click(object sender, EventArgs e)
        {
            {
                BDArtista obj_BDArtista = new BDArtista();

                string sLinha = lbox_Artista.Items[lbox_Artista.SelectedIndex].ToString();
                int iPos = 0;

                for (int t = 0; t < sLinha.Length; t++)
                {
                    if (sLinha.Substring(t, 1) == "-")
                    {
                        iPos = t;
                        break;
                    }
                }

                obj_Artista_Atual.Cod_Artista = int.Parse(sLinha.Substring(0, iPos));
                obj_Artista_Atual = obj_BDArtista.FindByCod(obj_Artista_Atual);
                PopulaTela(obj_Artista_Atual);
                obj_FuncGeral.StatusBtn(this, 2);
                obj_FuncGeral.HabilitaTela(this, false);

            }
        }

        private void btn_Genero_Click(object sender, EventArgs e)
        {
            Frm_Genero obj_Frm_Genero = new Frm_Genero();
            obj_Frm_Genero.ShowDialog();
            tbox_Cod_Genero.Text = obj_Frm_Genero.obj_Genero_Atual.Cod_Genero.ToString();
            tbox_Cod_Genero_Leave(sender, e);
        }

        private void tbox_Cod_Genero_Leave(object sender, EventArgs e)
        {
            if (tbox_Cod_Genero.Text != "")
            {
                Genero obj_Genero = new Genero();
                BDGenero obj_BDGenero = new BDGenero();

                obj_Genero.Cod_Genero = int.Parse(tbox_Cod_Genero.Text);

                obj_Genero = obj_BDGenero.FindByCod(obj_Genero);

                if (obj_Genero.Cod_Genero != -1)
                {
                    lb_Nm_Genero.Text = obj_Genero.Nm_Genero;
                }
                else
                {
                    tbox_Cod_Genero.Clear();
                    lb_Nm_Genero.Text = "";
                }

            }

        }


    }
}
