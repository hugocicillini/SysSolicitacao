/****************************************************************************************
 *                Nome: Login
 *                Obs.: Representa a Classe de Entidade Login com Atributos Privados e 
 *                      métodos de Get e Set Públicos
 *         Dt. Criação: 07/02/2023
 *       Dt. Alteração: --/--/----
 *          Criada por: Hugo
 ****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysSolicitação
{
    public class Login
    {
        ~Login()
        {

        }

        #region Atributos Privados
        private int v_Cod_Login = -1;
        private string v_UNm_Login = "";
        private string v_PW_Login = "";
        #endregion

        #region Metodos Publicos
        public int Cod_Login
        {
            get => v_Cod_Login;
            set => v_Cod_Login = value;
        }

        public string PW_Login
        {
            get => v_PW_Login;
            set => v_PW_Login = value;
        }

        public string UNm_Login
        {
            get => v_UNm_Login;
            set => v_UNm_Login = value;
        }
        #endregion

    }
}
