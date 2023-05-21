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
    public partial class Frm_Funcionario : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Funcionario obj_Funcionario_Atual = new Funcionario();

        public Frm_Funcionario()
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
            //instacia do objeto BDFuncionario
            BDFuncionario obj_BDFuncionario = new BDFuncionario();

            //Instacia da lista que receberá a lista que chegará do Banco
            List<Funcionario> LstFuncionario = new List<Funcionario>();

            //Limpa Lista
            lbox_Funcionario.Items.Clear();

            LstFuncionario = obj_BDFuncionario.FindAll();

            if (LstFuncionario != null)
            {
                for (int i = 0; i < LstFuncionario.Count; i++)
                {
                    lbox_Funcionario.Items.Add(LstFuncionario[i].Cod_Funcionario.ToString() + "-" + LstFuncionario[i].Nm_Funcionario);
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
        private void PopulaTela(Funcionario pobj_Funcionario)
        {
            if (pobj_Funcionario.Cod_Funcionario != -1)
            {
                tbox_Cod_Funcionario.Text = pobj_Funcionario.Cod_Funcionario.ToString();
                tbox_Nm_Funcionario.Text = pobj_Funcionario.Nm_Funcionario;
                tbox_Mail_Funcionario.Text = pobj_Funcionario.Email_Funcionario;
                tbox_CEP_Funcionario.Text = pobj_Funcionario.CEP_Funcionario;
                tbox_Cel_Funcionario.Text = pobj_Funcionario.Cel_Funcionario;
                tbox_End_Funcionario.Text = pobj_Funcionario.End_Funcionario;
                tbox_Bai_Funcionario.Text = pobj_Funcionario.Bai_Funcionario;
                tbox_Cid_Funcionario.Text = pobj_Funcionario.Cid_Funcionario;
                tbox_UF_Funcionario.Text = pobj_Funcionario.UF_Funcionario;
                maskedTextBox2.Text = pobj_Funcionario.CPF_Funcionario;
                tbox_Nasc_Funcionario.Text = pobj_Funcionario.Nasc_Funcionario.ToString();
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
        private Funcionario PopulaObjeto()
        {
            Funcionario obj_Funcionario = new Funcionario();

            if (tbox_Cod_Funcionario.Text != "")
            {
                obj_Funcionario.Cod_Funcionario = int.Parse(tbox_Cod_Funcionario.Text);
            }

            obj_Funcionario.Nm_Funcionario = tbox_Nm_Funcionario.Text;
            obj_Funcionario.Email_Funcionario = tbox_Mail_Funcionario.Text;
            obj_Funcionario.Nm_Funcionario = tbox_Nm_Funcionario.Text;
            obj_Funcionario.CPF_Funcionario = maskedTextBox2.Text;
            obj_Funcionario.End_Funcionario = tbox_End_Funcionario.Text;
            obj_Funcionario.Bai_Funcionario = tbox_Bai_Funcionario.Text;
            obj_Funcionario.Cid_Funcionario = tbox_Cid_Funcionario.Text;
            obj_Funcionario.UF_Funcionario = tbox_UF_Funcionario.Text;
            obj_Funcionario.CEP_Funcionario = tbox_CEP_Funcionario.Text;
            obj_Funcionario.Cel_Funcionario = tbox_Cel_Funcionario.Text;
            obj_Funcionario.Nasc_Funcionario = DateTime.Parse(tbox_Nasc_Funcionario.Text).Date;

            return obj_Funcionario;
        }


        private void btn_Novo_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Limpa os componentes da tela para edição
            obj_FuncGeral.LimpaTela(this);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Nm_Funcionario.Focus();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Nm_Funcionario.Focus();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            //Desabilita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, false);

            if (obj_Funcionario_Atual.Cod_Funcionario != -1)
            {
                PopulaTela(obj_Funcionario_Atual);
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
            BDFuncionario obj_BDFuncionario = new BDFuncionario();


            DialogResult varResp = MessageBox.Show("Confima a Exclusão deste Registro?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (varResp == DialogResult.Yes)
            {
                if (obj_BDFuncionario.Excluir(obj_Funcionario_Atual))
                {
                    MessageBox.Show("O Funcionario " + obj_Funcionario_Atual.Nm_Funcionario + " foi excluida com sucesso.", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            BDFuncionario obj_BDFuncionario = new BDFuncionario();

            obj_Funcionario_Atual = PopulaObjeto();

            if (obj_Funcionario_Atual.Cod_Funcionario != -1)
            {
                obj_BDFuncionario.Alterar(obj_Funcionario_Atual);
                MessageBox.Show("O Funcionario " + obj_Funcionario_Atual.Nm_Funcionario + " foi alterado com sucesso.", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj_Funcionario_Atual.Cod_Funcionario = obj_BDFuncionario.Incluir(obj_Funcionario_Atual);
                PopulaTela(obj_Funcionario_Atual);
                MessageBox.Show("O Funcionario " + obj_Funcionario_Atual.Nm_Funcionario + " foi Incluido com sucesso.", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);

        }

        private void lbox_Funcionario_Click(object sender, EventArgs e)
        {
            BDFuncionario obj_BDFuncionario = new BDFuncionario();

            string sLinha = lbox_Funcionario.Items[lbox_Funcionario.SelectedIndex].ToString();
            int iPos = 0;

            for (int t = 0; t < sLinha.Length; t++)
            {
                if (sLinha.Substring(t, 1) == "-")
                {
                    iPos = t;
                    break;
                }
            }

            obj_Funcionario_Atual.Cod_Funcionario = int.Parse(sLinha.Substring(0, iPos));
            obj_Funcionario_Atual = obj_BDFuncionario.FindByCod(obj_Funcionario_Atual);
            PopulaTela(obj_Funcionario_Atual);
            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);


        }
    }
}
