/****************************************************************************************
 *                Nome: Espetaculo
 *                Obs.: Representa a Classe de Entidade Espetaculo com Atributos Privados e 
 *                      métodos de Get e Set Públicos
 *         Dt. Criação: 16/03/2023
 *       Dt. Alteração: --/--/----
 *          Criada por: Hugo
 ****************************************************************************************/
using System;

namespace SysSolicitação
{
    public class Espetaculo
    {

        ~Espetaculo()
        {

        }

        #region Atributos Privados
        private int v_Cod_Espetaculo = -1;
        private int v_Cod_Artista = -1;
        private string v_Nm_Espetaculo = "";
        private DateTime v_DtHr_Espetaculo = DateTime.MinValue ;


        #endregion

        #region Métodos Públicos
        public int Cod_Espetaculo
        {
            get => v_Cod_Espetaculo;
            set => v_Cod_Espetaculo = value;
        }

        public int Cod_Artista
        {
            get => v_Cod_Artista;
            set => v_Cod_Artista = value;
        }

        public string Nm_Espetaculo
        {
            get => v_Nm_Espetaculo;
            set => v_Nm_Espetaculo = value;
        }

        public DateTime DtHr_Espetaculo
        {
            get => v_DtHr_Espetaculo;
            set => v_DtHr_Espetaculo = value;
        }

        #endregion

    }
}
