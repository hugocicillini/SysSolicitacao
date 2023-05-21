/****************************************************************************************
 *                Nome: Artista
 *                Obs.: Representa a Classe de Entidade Artista com Atributos Privados e 
 *                      métodos de Get e Set Públicos
 *         Dt. Criação: 16/03/2023
 *       Dt. Alteração: --/--/----
 *          Criada por: Hugo
 ****************************************************************************************/

namespace SysSolicitação
{
    public class Artista
    {

        ~Artista()
        {

        }

        #region Atributos Privados
        private int v_Cod_Artista = -1;
        private int v_Cod_Genero = -1;
        private string v_Nm_Artista = "";


        #endregion

        #region Métodos Públicos
        public int Cod_Artista
        {
            get => v_Cod_Artista;
            set => v_Cod_Artista = value;
        }

        public int Cod_Genero
        {
            get => v_Cod_Genero;
            set => v_Cod_Genero = value;
        }

        public string Nm_Artista
        {
            get => v_Nm_Artista;
            set => v_Nm_Artista = value;
        }

        #endregion

    }
}
