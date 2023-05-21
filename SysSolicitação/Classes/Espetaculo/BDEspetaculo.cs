/****************************************************************************************
 *                Nome: BDEspetaculo
 *                Obs.: Representa a Classe de Entidade BDEspetaculo com Metodos Públicos que irão 
 *                      consultar, inserir, excluir e alterar os dados da tabela TB_ESPETACULO.
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
    class BDEspetaculo
    {
        ~BDEspetaculo()
        {

        }

        /****************************************************************************************
        *              Método: Incluir
        *                Obs.: Responsável por incluir a Tupla que está no objeto Espetaculo na tabela
        *                      TB_ESPETACULO.
        *           Parametro: Objeto Espetaculo
        *             Retorno: PK da Tupla inserida na tabela TB_ESPETACULO.
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public int Incluir(Espetaculo pobj_Espetaculo)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "INSERT INTO TB_ESPETACULO " +
                          "( " +
                          "I_COD_ARTISTA, " +
                          "S_NM_ESPETACULO, " +
                          "DT_DTHR_ESPETACULO " +
                          ") " +
                          "VALUES " +
                          "( " +
                          "@I_COD_ARTISTA, " +
                          "@S_NM_ESPETACULO, " +
                          "@DT_DTHR_ESPETACULO " +
                          "); " +
                          "SELECT IDENT_CURRENT('TB_ESPETACULO') AS 'CODPK'";
            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_ARTISTA", pobj_Espetaculo.Cod_Artista);
            objCmd.Parameters.AddWithValue("@DT_DTHR_ESPETACULO", pobj_Espetaculo.DtHr_Espetaculo);
            objCmd.Parameters.AddWithValue("@S_NM_ESPETACULO", pobj_Espetaculo.Nm_Espetaculo);

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
                return pobj_Espetaculo.Cod_Espetaculo;
            }
        }

        /****************************************************************************************
        *              Método: Alterar
        *                Obs.: Responsável por Alterar a Tupla que está no objeto Espetaculo na tabela
        *                      TB_ESPETACULO.
        *           Parametro: Objeto Espetaculo
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Alterar(Espetaculo pobj_Espetaculo)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "UPDATE TB_ESPETACULO SET " +
                          "I_COD_ARTISTA = @I_COD_ARTISTA, " +
                          "S_NM_ESPETACULO = @S_NM_ESPETACULO, " +
                          "DT_DTHR_ESPETACULO = @DT_DTHR_ESPETACULO " +
                          "WHERE I_COD_ESPETACULO = @I_COD_ESPETACULO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_ESPETACULO", pobj_Espetaculo.Cod_Espetaculo);
            objCmd.Parameters.AddWithValue("@I_COD_ARTISTA", pobj_Espetaculo.Cod_Artista);
            objCmd.Parameters.AddWithValue("@S_NM_ESPETACULO", pobj_Espetaculo.Nm_Espetaculo);
            objCmd.Parameters.AddWithValue("@DT_DTHR_ESPETACULO", pobj_Espetaculo.DtHr_Espetaculo);

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
        *                Obs.: Responsável por Excluir a Tupla que está no objeto Espetaculo na tabela
        *                      TB_ESPETACULO.
        *           Parametro: Objeto Espetaculo
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Excluir(Espetaculo pobj_Espetaculo)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "DELETE FROM TB_ESPETACULO " +
                          "WHERE I_COD_ESPETACULO = @I_COD_ESPETACULO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_ESPETACULO", pobj_Espetaculo.Cod_Espetaculo);
            
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
        *                Obs.: Responsável por Encontrar a Tupla que está na tabela TB_ESPETACULO pelo
        *                      Códido da agenda.
        *           Parametro: Objeto Espetaculo (Vazio)
        *             Retorno: Objeto Espetaculo (Cheio)
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public Espetaculo FindByCod(Espetaculo pobj_Espetaculo)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_ESPETACULO " +
                          "WHERE I_COD_ESPETACULO = @I_COD_ESPETACULO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_ESPETACULO", pobj_Espetaculo.Cod_Espetaculo);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    objDtr.Read();
                    pobj_Espetaculo.Cod_Espetaculo = Convert.ToInt16(objDtr["I_COD_ESPETACULO"]);
                    pobj_Espetaculo.Cod_Artista = Convert.ToInt16(objDtr["I_COD_ARTISTA"]);
                    pobj_Espetaculo.Nm_Espetaculo = (objDtr["S_NM_ESPETACULO"]).ToString();
                    pobj_Espetaculo.DtHr_Espetaculo = Convert.ToDateTime(objDtr["DT_DTHR_ESPETACULO"]);

                    objCon.Close();
                    objDtr.Close();

                    return pobj_Espetaculo;
                }
                else
                {
                    objCon.Close();
                    return pobj_Espetaculo;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Espetaculo;
            }
        }

        /****************************************************************************************
        *              Método: FindAll
        *                Obs.: Responsável por Encontrar todas as Tuplas que estão na tabela 
        *                      TB_ESPETACULO.
        *             Retorno: uma lista de todos os Objeto Espetaculo
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public List<Espetaculo> FindAll()
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_ESPETACULO ";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Espetaculo> Lista = new List<Espetaculo>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Espetaculo obj_Espetaculo = new Espetaculo();
                        obj_Espetaculo.Cod_Espetaculo = Convert.ToInt16(objDtr["I_COD_ESPETACULO"]);
                        obj_Espetaculo.Cod_Artista = Convert.ToInt16(objDtr["I_COD_ARTISTA"]);
                        obj_Espetaculo.DtHr_Espetaculo = Convert.ToDateTime(objDtr["DT_DTHR_ESPETACULO"]);
                        obj_Espetaculo.Nm_Espetaculo = (objDtr["S_NM_ESPETACULO"]).ToString();

                        Lista.Add(obj_Espetaculo);

                    }

                }
                
                objCon.Close();
                objDtr.Close();

                return Lista;
                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Espetaculo>();
            }
        }
    }
}
