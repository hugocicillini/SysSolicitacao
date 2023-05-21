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

namespace SysStudioTattoo
{
    public partial class Frm_Login : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Login obj_Login_Atual = new Login();

        public Frm_Login()
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
        *         Dt. Criação: 11/04/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: --
        ****************************************************************************************/
        private void PopulaLista()
        {
            //instacia do objeto BDLogin
            BDLogin obj_BDLogin = new BDLogin();

            //Instacia da lista que receberá a lista que chegará do Banco
            List<Login> LstLogin = new List<Login>();

            //Limpa Lista
            lbox_Logins.Items.Clear();

            LstLogin = obj_BDLogin.FindAll();

            if (LstLogin != null)
            {
                for (int i = 0; i < LstLogin.Count; i++)
                {
                    lbox_Logins.Items.Add(LstLogin[i].Cod_Login.ToString() + "-" + LstLogin[i].UNm_Login);
                }
            }
        }

        /****************************************************************************************
        *              Método: PopulaTela
        *                Obs.: Responsável por preencher os objetos editáveis da Tela.
        *         Dt. Criação: 11/04/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: --
        ****************************************************************************************/
        private void PopulaTela(Login pobj_Login)
        {
            if (pobj_Login.Cod_Login != -1)
            {
                tbox_Cod_Login.Text = pobj_Login.Cod_Login.ToString();
                tbox_UNm_Login.Text = pobj_Login.UNm_Login;
                tbox_PW_Login.Text = obj_FuncGeral.DesCriptografa(pobj_Login.PW_Login);
            }
        }

        /****************************************************************************************
        *              Método: PopulaObjeto
        *                Obs.: Responsável por preencher o objeto com o conteúdo dos objetos 
        *                      editáveis da Tela.
        *         Dt. Criação: 11/04/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: --
        ****************************************************************************************/
        private Login PopulaObjeto()
        {
            Login obj_Login = new Login();

            if (tbox_Cod_Login.Text != "")
            {
                obj_Login.Cod_Login = int.Parse(tbox_Cod_Login.Text);
            }

            obj_Login.UNm_Login = tbox_UNm_Login.Text;
            obj_Login.PW_Login = obj_FuncGeral.Criptografa(tbox_PW_Login.Text);

            return obj_Login;
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Limpa os componentes da tela para edição
            obj_FuncGeral.LimpaTela(this);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_UNm_Login.Focus();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            //Halibita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, true);

            //Ajustar o status dos Botões
            obj_FuncGeral.StatusBtn(this, 3);

            tbox_UNm_Login.Focus();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            //Desabilita os componentes da tela para edição
            obj_FuncGeral.HabilitaTela(this, false);

            if (obj_Login_Atual.Cod_Login == -1)
            {
                PopulaTela(obj_Login_Atual);
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
            BDLogin obj_BDLogin = new BDLogin();


            DialogResult varResp = MessageBox.Show("Confima a Exclusão deste Registro?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (varResp == DialogResult.Yes)
            {
                if (obj_BDLogin.Excluir(obj_Login_Atual))
                {
                    MessageBox.Show("O Login " + obj_Login_Atual.UNm_Login + " foi excluido com sucesso.", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            BDLogin obj_BDLogin = new BDLogin();

            obj_Login_Atual = PopulaObjeto();

            if (obj_Login_Atual.Cod_Login != -1)
            {
                obj_BDLogin.Alterar(obj_Login_Atual);
                MessageBox.Show("O Login " + obj_Login_Atual.UNm_Login + " foi Alterado com sucesso.", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj_Login_Atual.Cod_Login = obj_BDLogin.Incluir(obj_Login_Atual);
                PopulaTela(obj_Login_Atual);
                MessageBox.Show("O Login " + obj_Login_Atual.UNm_Login + " foi Incluido com sucesso.", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);

        }

        private void lbox_Logins_Click(object sender, EventArgs e)
        {
            BDLogin obj_BDLogin = new BDLogin();

            string sLinha = lbox_Logins.Items[lbox_Logins.SelectedIndex].ToString();
            int iPos = 0;

            for (int t = 0; t < sLinha.Length; t++)
            {
                if (sLinha.Substring(t, 1) == "-")
                {
                    iPos = t;
                    break;
                }
            }

            obj_Login_Atual.Cod_Login = int.Parse(sLinha.Substring(0, iPos));
            obj_Login_Atual = obj_BDLogin.FindByCod(obj_Login_Atual);
            PopulaTela(obj_Login_Atual);
            obj_FuncGeral.StatusBtn(this, 2);
            obj_FuncGeral.HabilitaTela(this, false);



        }

        private void cbox_Visual_Click(object sender, EventArgs e)
        {
            if (cbox_Visual.Checked)
            {
                tbox_PW_Login.UseSystemPasswordChar = false;
            }
            else
            {
                tbox_PW_Login.UseSystemPasswordChar = true;
            }

        }
    }
}
