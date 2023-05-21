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
    public partial class Frm_Acesso : Form
    {
        public Login obj_Login_Atual = new Login();

        FuncGeral obj_FuncGeral = new FuncGeral();


        public Frm_Acesso()
        {
            InitializeComponent();
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            BDLogin obj_BDLogin = new BDLogin();

            if (tbox_PW_Login.Text != "")
            {
                if (tbox_UNm_Login.Text != "")
                {
                    obj_Login_Atual.UNm_Login = tbox_UNm_Login.Text;

                    obj_Login_Atual = obj_BDLogin.FindByUNm(obj_Login_Atual);

                    if (tbox_PW_Login.Text == obj_FuncGeral.DesCriptografa(obj_Login_Atual.PW_Login))
                    {
                        Frm_Principal obj_Frm_Principal = new Frm_Principal();
                        obj_Frm_Principal.obj_Login_Atual = obj_Login_Atual;
                        obj_Frm_Principal.ShowDialog();
                        Close();
                    }
                }
                else
                {
                    tbox_UNm_Login.Focus();
                }
            }
            else
            {
                tbox_PW_Login.Focus();
            }
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
