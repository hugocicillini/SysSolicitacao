/****************************************************************************************
 *                Nome: BDArtista
 *                Obs.: Representa a Classe de Entidade BDArtista com Metodos Públicos que irão 
 *                      consultar, inserir, excluir e alterar os dados da tabela TB_ARTISTA.
 *         Dt. Criação: 16/03/2023
 *       Dt. Alteração: --/--/----
 *          Criada por: Hugo
 ****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SysSolicitação
{
    class BDArtista
    {
        ~BDArtista()
        {

        }

        /****************************************************************************************
        *              Método: Incluir
        *                Obs.: Responsável por incluir a Tupla que está no objeto Artista na tabela
        *                      TB_ARTISTA.
        *           Parametro: Objeto Artista
        *             Retorno: PK da Tupla inserida na tabela TB_ARTISTA.
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public int Incluir(Artista pobj_Artista)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "INSERT INTO TB_ARTISTA " +
                          "( " +
                          "S_NM_ARTISTA, " +
                          "I_COD_GENERO " +
                          ") " +
                          "VALUES " +
                          "( " +
                          "@S_NM_ARTISTA, " +
                          "@I_COD_GENERO " +
                          "); " +
                          "SELECT IDENT_CURRENT('TB_ARTISTA') AS 'CODPK'";
            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@S_NM_ARTISTA", pobj_Artista.Nm_Artista);
            objCmd.Parameters.AddWithValue("@I_COD_GENERO", pobj_Artista.Cod_Genero);

            try
            {
                objCon.Open();
                int iCod = Convert.ToInt16(objCmd.ExecuteScalar());
                objCon.Close();
                return iCod;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Artista.Cod_Artista;
            }
        }

        /****************************************************************************************
        *              Método: Alterar
        *                Obs.: Responsável por Alterar a Tupla que está no objeto Artista na tabela
        *                      TB_ARTISTA.
        *           Parametro: Objeto Artista
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Alterar(Artista pobj_Artista)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "UPDATE TB_ARTISTA SET " +
                          "S_NM_ARTISTA = @S_NM_ARTISTA," +
                          "I_COD_GENERO  = @I_COD_GENERO " +
                          "WHERE I_COD_ARTISTA = @I_COD_ARTISTA";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_ARTISTA", pobj_Artista.Cod_Artista);
            objCmd.Parameters.AddWithValue("@S_NM_ARTISTA", pobj_Artista.Nm_Artista);
            objCmd.Parameters.AddWithValue("@I_COD_GENERO", pobj_Artista.Cod_Genero);

            try
            {
                objCon.Open();
                objCmd.ExecuteNonQuery();
                objCon.Close();
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /****************************************************************************************
        *              Método: Excluir
        *                Obs.: Responsável por Excluir a Tupla que está no objeto Artista na tabela
        *                      TB_ARTISTA.
        *           Parametro: Objeto Artista
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Excluir(Artista pobj_Artista)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "DELETE FROM TB_ARTISTA " +
                          "WHERE I_COD_ARTISTA = @I_COD_ARTISTA";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_ARTISTA", pobj_Artista.Cod_Artista);
            
            try
            {
                objCon.Open();
                objCmd.ExecuteNonQuery();
                objCon.Close();
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /****************************************************************************************
        *              Método: FindByCod
        *                Obs.: Responsável por Encontrar a Tupla que está na tabela TB_ARTISTA pelo
        *                      Códido da agenda.
        *           Parametro: Objeto Artista (Vazio)
        *             Retorno: Objeto Artista (Cheio)
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public Artista FindByCod(Artista pobj_Artista)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_ARTISTA " +
                          "WHERE I_COD_ARTISTA = @I_COD_ARTISTA";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_ARTISTA", pobj_Artista.Cod_Artista);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    objDtr.Read();
                    pobj_Artista.Cod_Artista = Convert.ToInt16(objDtr["I_COD_ARTISTA"]);
                    pobj_Artista.Nm_Artista = (objDtr["S_NM_ARTISTA"]).ToString();
                    pobj_Artista.Cod_Genero = Convert.ToInt16(objDtr["I_COD_GENERO"]);

                    objCon.Close();
                    objDtr.Close();

                    return pobj_Artista;
                }
                else
                {
                    objCon.Close();
                    return pobj_Artista;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Artista;
            }
        }

        /****************************************************************************************
        *              Método: FindAll
        *                Obs.: Responsável por Encontrar todas as Tuplas que estão na tabela 
        *                      TB_ARTISTA.
        *             Retorno: uma lista de todos os Objeto Artista
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public List<Artista> FindAll()
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_ARTISTA ";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Artista> Lista = new List<Artista>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Artista obj_Artista = new Artista();
                        obj_Artista.Cod_Artista = Convert.ToInt16(objDtr["I_COD_ARTISTA"]);
                        obj_Artista.Nm_Artista = (objDtr["S_NM_ARTISTA"]).ToString();
                        obj_Artista.Cod_Genero = Convert.ToInt16(objDtr["I_COD_GENERO"]);

                        Lista.Add(obj_Artista);

                    }

                }
                
                objCon.Close();
                objDtr.Close();

                return Lista;
                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Artista>();
            }
        }
    }
}
