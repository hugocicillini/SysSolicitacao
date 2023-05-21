/****************************************************************************************
 *                Nome: BDGenero
 *                Obs.: Representa a Classe de Entidade BDGenero com Metodos Públicos que irão 
 *                      consultar, inserir, excluir e alterar os dados da tabela TB_GENERO.
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
    class BDGenero
    {
        ~BDGenero()
        {

        }

        /****************************************************************************************
        *              Método: Incluir
        *                Obs.: Responsável por incluir a Tupla que está no objeto Genero na tabela
        *                      TB_GENERO.
        *           Parametro: Objeto Genero
        *             Retorno: PK da Tupla inserida na tabela TB_GENERO.
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public int Incluir(Genero pobj_Genero)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "INSERT INTO TB_GENERO " +
                          "( " +
                          "S_NM_GENERO " +
                          ") " +
                          "VALUES " +
                          "( " +
                          "@S_NM_GENERO " +
                          "); " +
                          "SELECT IDENT_CURRENT('TB_GENERO') AS 'CODPK'";
            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@S_NM_GENERO", pobj_Genero.Nm_Genero);

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
                return pobj_Genero.Cod_Genero;
            }
        }

        /****************************************************************************************
        *              Método: Alterar
        *                Obs.: Responsável por Alterar a Tupla que está no objeto Genero na tabela
        *                      TB_GENERO.
        *           Parametro: Objeto Genero
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Alterar(Genero pobj_Genero)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "UPDATE TB_GENERO SET " +
                          "S_NM_GENERO = @S_NM_GENERO " +
                          "WHERE I_COD_GENERO = @I_COD_GENERO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_GENERO", pobj_Genero.Cod_Genero);
            objCmd.Parameters.AddWithValue("@S_NM_GENERO", pobj_Genero.Nm_Genero);

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
        *                Obs.: Responsável por Excluir a Tupla que está no objeto Genero na tabela
        *                      TB_GENERO.
        *           Parametro: Objeto Genero
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Excluir(Genero pobj_Genero)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "DELETE FROM TB_GENERO " +
                          "WHERE I_COD_GENERO = @I_COD_GENERO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_GENERO", pobj_Genero.Cod_Genero);
            
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
        *                Obs.: Responsável por Encontrar a Tupla que está na tabela TB_GENERO pelo
        *                      Códido da agenda.
        *           Parametro: Objeto Genero (Vazio)
        *             Retorno: Objeto Genero (Cheio)
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public Genero FindByCod(Genero pobj_Genero)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_GENERO " +
                          "WHERE I_COD_GENERO = @I_COD_GENERO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_GENERO", pobj_Genero.Cod_Genero);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    objDtr.Read();
                    pobj_Genero.Cod_Genero = Convert.ToInt16(objDtr["I_COD_GENERO"]);
                    pobj_Genero.Nm_Genero = (objDtr["S_NM_GENERO"]).ToString();

                    objCon.Close();
                    objDtr.Close();

                    return pobj_Genero;
                }
                else
                {
                    objCon.Close();
                    return pobj_Genero;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Genero;
            }
        }

        /****************************************************************************************
        *              Método: FindAll
        *                Obs.: Responsável por Encontrar todas as Tuplas que estão na tabela 
        *                      TB_GENERO.
        *             Retorno: uma lista de todos os Objeto Genero
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public List<Genero> FindAll()
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_GENERO ";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Genero> Lista = new List<Genero>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Genero obj_Genero = new Genero();
                        obj_Genero.Cod_Genero = Convert.ToInt16(objDtr["I_COD_GENERO"]);
                        obj_Genero.Nm_Genero = (objDtr["S_NM_GENERO"]).ToString();

                        Lista.Add(obj_Genero);

                    }

                }
                
                objCon.Close();
                objDtr.Close();

                return Lista;
                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Genero>();
            }
        }
    }
}
