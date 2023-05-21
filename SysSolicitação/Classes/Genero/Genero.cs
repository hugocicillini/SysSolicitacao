/****************************************************************************************
 *                Nome: Genero
 *                Obs.: Representa a Classe de Entidade Genero com Atributos Privados e 
 *                      métodos de Get e Set Públicos
 *         Dt. Criação: 16/03/2023
 *       Dt. Alteração: --/--/----
 *          Criada por: Hugo
 ****************************************************************************************/

namespace SysSolicitação
{
    public class Genero
    {

        ~Genero()
        {

        }

        #region Atributos Privados
        private int v_Cod_Genero = -1;
        private string v_Nm_Genero = "";


        #endregion

        #region Métodos Públicos
        public int Cod_Genero
        {
            get => v_Cod_Genero;
            set => v_Cod_Genero = value;
        }

        public string Nm_Genero
        {
            get => v_Nm_Genero;
            set => v_Nm_Genero = value;
        }

        #endregion

    }
}
