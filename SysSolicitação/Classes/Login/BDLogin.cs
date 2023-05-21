/****************************************************************************************
 *                Nome: BDLogin
 *                Obs.: Representa a Classe de Entidade BDLogin com Metodos Públicos que irão 
 *                      consultar, inserir, excluir e alterar os dados da tabela TB_LOGIN.
 *         Dt. Criação: 11/04/2023
 *       Dt. Alteração: --/--/----
 *          Criada por: Hugo
 ****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SysSolicitação
{
    class BDLogin
    {
        ~BDLogin()
        {

        }

        /****************************************************************************************
        *              Método: Incluir
        *                Obs.: Responsável por incluir a Tupla que está no objeto Login na tabela
        *                      TB_LOGIN.
        *           Parametro: Objeto Login
        *             Retorno: PK da Tupla inserida na tabela TB_LOGIN.
        *         Dt. Criação: 11/04/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public int Incluir(Login pobj_Login)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "INSERT INTO TB_LOGIN " +
                          "( " +
                          "S_PW_LOGIN, " +
                          "S_UNM_LOGIN " +
                          ") " +
                          "VALUES " +
                          "( " +
                          "@S_PW_LOGIN, " +
                          "@S_UNM_LOGIN " +
                          "); " +
                          "SELECT IDENT_CURRENT('TB_LOGIN') AS 'CODPK'";
            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@S_PW_LOGIN", pobj_Login.PW_Login);
            objCmd.Parameters.AddWithValue("@S_UNM_LOGIN", pobj_Login.UNm_Login);

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
                return pobj_Login.Cod_Login;
            }
        }

        /****************************************************************************************
        *              Método: Alterar
        *                Obs.: Responsável por Alterar a Tupla que está no objeto Login na tabela
        *                      TB_LOGIN.
        *           Parametro: Objeto Login
        *             Retorno: Booleano
        *         Dt. Criação: 11/04/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Alterar(Login pobj_Login)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "UPDATE TB_LOGIN SET " +
                          "S_PW_LOGIN = @S_PW_LOGIN, " +
                          "S_UNM_LOGIN = @S_UNM_LOGIN " +
                          "WHERE I_COD_LOGIN = @I_COD_LOGIN";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_LOGIN", pobj_Login.Cod_Login);
            objCmd.Parameters.AddWithValue("@S_PW_LOGIN", pobj_Login.PW_Login);
            objCmd.Parameters.AddWithValue("@S_UNM_LOGIN", pobj_Login.UNm_Login);

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
        *                Obs.: Responsável por Excluir a Tupla que está no objeto Login na tabela
        *                      TB_LOGIN.
        *           Parametro: Objeto Login
        *             Retorno: Booleano
        *         Dt. Criação: 11/04/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Excluir(Login pobj_Login)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "DELETE FROM TB_LOGIN " +
                          "WHERE I_COD_LOGIN = @I_COD_LOGIN";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_LOGIN", pobj_Login.Cod_Login);

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
        *                Obs.: Responsável por Encontrar a Tupla que está na tabela TB_LOGIN pelo
        *                      Códido da agenda.
        *           Parametro: Objeto Login (Vazio)
        *             Retorno: Objeto Login (Cheio)
        *         Dt. Criação: 11/04/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public Login FindByCod(Login pobj_Login)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_LOGIN " +
                          "WHERE I_COD_LOGIN = @I_COD_LOGIN";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_LOGIN", pobj_Login.Cod_Login);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    objDtr.Read();

                    pobj_Login.Cod_Login = Convert.ToInt16(objDtr["I_COD_LOGIN"]);
                    pobj_Login.UNm_Login = objDtr["S_UNM_LOGIN"].ToString();
                    pobj_Login.PW_Login = objDtr["S_PW_LOGIN"].ToString();

                    objCon.Close();
                    objDtr.Close();

                    return pobj_Login;
                }
                else
                {
                    objCon.Close();
                    return pobj_Login;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Login;
            }
        }

        /****************************************************************************************
        *              Método: FindByUNm
        *                Obs.: Responsável por Encontrar a Tupla que está na tabela TB_LOGIN pelo
        *                      Códido da agenda.
        *           Parametro: Objeto Login (Vazio)
        *             Retorno: Objeto Login (Cheio)
        *         Dt. Criação: 11/04/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public Login FindByUNm(Login pobj_Login)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_LOGIN " +
                          "WHERE S_UNM_LOGIN = @S_UNM_LOGIN";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@S_UNM_LOGIN", pobj_Login.UNm_Login);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    objDtr.Read();

                    pobj_Login.Cod_Login = Convert.ToInt16(objDtr["I_COD_LOGIN"]);
                    pobj_Login.UNm_Login = objDtr["S_UNM_LOGIN"].ToString();
                    pobj_Login.PW_Login = objDtr["S_PW_LOGIN"].ToString();

                    objCon.Close();
                    objDtr.Close();

                    return pobj_Login;
                }
                else
                {
                    objCon.Close();
                    return pobj_Login;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Login;
            }
        }


        /****************************************************************************************
        *              Método: FindAll
        *                Obs.: Responsável por Encontrar todas as Tuplas que estão na tabela 
        *                      TB_LOGIN.
        *             Retorno: uma lista de todos os Objeto Login
        *         Dt. Criação: 11/04/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public List<Login> FindAll()
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_LOGIN ";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Login> Lista = new List<Login>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Login obj_Login = new Login();

                        obj_Login.Cod_Login = Convert.ToInt16(objDtr["I_COD_LOGIN"]);
                        obj_Login.UNm_Login = objDtr["S_UNM_LOGIN"].ToString();
                        obj_Login.PW_Login = objDtr["S_PW_LOGIN"].ToString();

                        Lista.Add(obj_Login);

                    }

                }

                objCon.Close();
                objDtr.Close();

                return Lista;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Login>();
            }
        }


    }
}
