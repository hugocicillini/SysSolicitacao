/****************************************************************************************
 *                Nome: Cliente
 *                Obs.: Representa a Classe de Entidade Cliente com Atributos Privados e 
 *                      métodos de Get e Set Públicos
 *         Dt. Criação: 16/03/2023
 *       Dt. Alteração: --/--/----
 *          Criada por: Hugo
 ****************************************************************************************/
using System;

namespace SysSolicitação
{
    public class Cliente
    {

        ~Cliente()
        {

        }

        #region Atributos Privados
        private int v_Cod_Cliente = -1;
        private string v_Nm_Cliente = "";
        private string v_Email_Cliente = "";
        private string v_RG_Cliente = "";
        private string v_CPF_Cliente = "";


        #endregion

        #region Métodos Públicos
        public int Cod_Cliente
        { 
            get => v_Cod_Cliente; 
            set => v_Cod_Cliente = value; 
        }

        public string Nm_Cliente
        { 
            get => v_Nm_Cliente; 
            set => v_Nm_Cliente = value; 
        }

        public string Email_Cliente
        {
            get => v_Email_Cliente;
            set => v_Email_Cliente = value;
        }

        public string RG_Cliente
        {
            get => v_RG_Cliente;
            set => v_RG_Cliente = value;
        }

        public string CPF_Cliente
        {
            get => v_CPF_Cliente;
            set => v_CPF_Cliente = value;
        }

        #endregion

    }
}
