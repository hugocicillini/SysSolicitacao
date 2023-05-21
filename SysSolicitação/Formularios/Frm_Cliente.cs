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
    public partial class Frm_Cliente : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Cliente obj_Cliente_Atual = new Cliente();

        public Frm_Cliente()
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
            //instacia do objeto BDCliente
            BDCliente obj_BDCliente = new BDCliente();

            //Instacia da lista que receberá a lista que chegará do Banco
            List<Cliente> LstCliente = new List<Cliente>();

            //Limpa Lista
            lbox_Cliente.Items.Clear();

            LstCliente = obj_BDCliente.FindAll();

            if (LstCliente != null)
            {
                for (int i = 0; i < LstCliente.Count; i++)
                {
                    lbox_Cliente.Items.Add(LstCliente[i].Cod_Cliente.ToString() + "-" + LstCliente[i].Nm_Cliente);
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
        private void PopulaTela(Cliente pobj_Cliente)
        {
            if (pobj_Cliente.Cod_Cliente != -1)
            {
                tbox_Cod_Cliente.Text = pobj_Cliente.Cod_Cliente.ToString();
                tbox_Nm_Cliente.Text = pobj_Cliente.Nm_Cliente;
                tbox_Mail_Cliente.Text = pobj_Cliente.Nm_Cliente;
                tbox_RG_Cliente.Text = pobj_Cliente.Nm_Cliente;
                tbox_CPF_Cliente.Text = pobj_Cliente.Nm_Cliente;
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
        private Cliente PopulaObjeto()
        {
            Cliente obj_Cliente = new Cliente();

            if (tbox_Cod_Cliente.Text != "")
            {
                obj_Cliente.Cod_Cliente = int.Parse(tbox_Cod_Cliente.Text);
            }

            obj_Cliente.Nm_Cliente = tbox_Nm_Cliente.Text;
            obj_Cliente.Email_Cliente = tbox_Mail_Cliente.Text;
            obj_Cliente.RG_Cliente = tbox_RG_Cliente.Text;
            obj_Cliente.CPF_Cliente = tbox_CPF_Cliente.Text;

            return obj_Cliente;
        }


        private void btn_Novo_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Limpa os componentes da tela para edição
            obj_FuncGeral.LimpaTela(this);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Nm_Cliente.Focus();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_Nm_Cliente.Focus();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            //Desabilita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, false);

            if (obj_Cliente_Atual.Cod_Cliente != -1)
            {
                PopulaTela(obj_Cliente_Atual);
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
            BDCliente obj_BDCliente = new BDCliente();


            DialogResult varResp = MessageBox.Show("Confima a Exclusão deste Registro?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (varResp == DialogResult.Yes)
            {
                if (obj_BDCliente.Excluir(obj_Cliente_Atual))
                {
                    MessageBox.Show("O Cliente " + obj_Cliente_Atual.Nm_Cliente + " foi excluida com sucesso.", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            BDCliente obj_BDCliente = new BDCliente();

            obj_Cliente_Atual = PopulaObjeto();

            if (obj_Cliente_Atual.Cod_Cliente != -1)
            {
                obj_BDCliente.Alterar(obj_Cliente_Atual);
                MessageBox.Show("O Cliente " + obj_Cliente_Atual.Nm_Cliente + " foi alterado com sucesso.", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj_Cliente_Atual.Cod_Cliente = obj_BDCliente.Incluir(obj_Cliente_Atual);
                PopulaTela(obj_Cliente_Atual);
                MessageBox.Show("O Cliente " + obj_Cliente_Atual.Nm_Cliente + " foi Incluido com sucesso.", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);

        }

        private void lbox_Cliente_Click(object sender, EventArgs e)
        {
            BDCliente obj_BDCliente = new BDCliente();

            string sLinha = lbox_Cliente.Items[lbox_Cliente.SelectedIndex].ToString();
            int iPos = 0;

            for (int t = 0; t < sLinha.Length; t++)
            {
                if (sLinha.Substring(t, 1) == "-")
                {
                    iPos = t;
                    break;
                }
            }

            obj_Cliente_Atual.Cod_Cliente = int.Parse(sLinha.Substring(0, iPos));
            obj_Cliente_Atual = obj_BDCliente.FindByCod(obj_Cliente_Atual);
            PopulaTela(obj_Cliente_Atual);
            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);



        }
    }
}
