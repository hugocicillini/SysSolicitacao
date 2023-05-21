/****************************************************************************************
 *                Nome: Funcionario
 *                Obs.: Representa a Classe de Entidade Funcionario com Atributos Privados e 
 *                      métodos de Get e Set Públicos
 *         Dt. Criação: 16/03/2023
 *       Dt. Alteração: --/--/----
 *          Criada por: Hugo
 ****************************************************************************************/
using System;

namespace SysSolicitação
{
    public class Funcionario
    {

        ~Funcionario()
        {

        }

        #region Atributos Privados
        private int v_Cod_Funcionario = -1;
        private string v_Nm_Funcionario = "";
        private string v_CPF_Funcionario = "";
        private string v_End_Funcionario = "";
        private string v_Bai_Funcionario = "";
        private string v_Cid_Funcionario = "";
        private string v_UF_Funcionario = "";
        private string v_CEP_Funcionario = "";
        private string v_Email_Funcionario = "";
        private string v_Cel_Funcionario = "";
        private DateTime v_Nasc_Funcionario = DateTime.MinValue;


        #endregion

        #region Métodos Públicos
        public int Cod_Funcionario
        {
            get => v_Cod_Funcionario;
            set => v_Cod_Funcionario = value;
        }

        public string Nm_Funcionario
        {
            get => v_Nm_Funcionario;
            set => v_Nm_Funcionario = value;
        }

        public string CPF_Funcionario
        {
            get => v_CPF_Funcionario;
            set => v_CPF_Funcionario = value;
        }

        public string End_Funcionario
        {
            get => v_End_Funcionario;
            set => v_End_Funcionario = value;
        }

        public string Bai_Funcionario
        {
            get => v_Bai_Funcionario;
            set => v_Bai_Funcionario = value;
        }

        public string Cid_Funcionario
        {
            get => v_Cid_Funcionario;
            set => v_Cid_Funcionario = value;
        }

        public string UF_Funcionario
        {
            get => v_UF_Funcionario;
            set => v_UF_Funcionario = value;
        }

        public string CEP_Funcionario
        {
            get => v_CEP_Funcionario;
            set => v_CEP_Funcionario = value;
        }

        public string Email_Funcionario
        {
            get => v_Email_Funcionario;
            set => v_Email_Funcionario = value;
        }

        public string Cel_Funcionario
        {
            get => v_Cel_Funcionario;
            set => v_Cel_Funcionario = value;
        }

        public DateTime Nasc_Funcionario
        {
            get => v_Nasc_Funcionario;
            set => v_Nasc_Funcionario = value;
        }

        #endregion

    }
}
