/****************************************************************************************
 *                Nome: BDFuncionario
 *                Obs.: Representa a Classe de Entidade BDFuncionario com Metodos Públicos que irão 
 *                      consultar, inserir, excluir e alterar os dados da tabela TB_FUNCIONARIO.
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
    class BDFuncionario
    {
        ~BDFuncionario()
        {

        }

        /****************************************************************************************
        *              Método: Incluir
        *                Obs.: Responsável por incluir a Tupla que está no objeto Funcionario na tabela
        *                      TB_FUNCIONARIO.
        *           Parametro: Objeto Funcionario
        *             Retorno: PK da Tupla inserida na tabela TB_FUNCIONARIO.
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public int Incluir(Funcionario pobj_Funcionario)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "INSERT INTO TB_FUNCIONARIO " +
                          "( " +
                          "S_NM_FUNCIONARIO, " +
                          "S_CPF_FUNCIONARIO, " +
                          "S_END_FUNCIONARIO, " +
                          "S_BAI_FUNCIONARIO, " +
                          "S_CID_FUNCIONARIO, " +
                          "S_UF_FUNCIONARIO, " +
                          "S_CEP_FUNCIONARIO, " +
                          "S_EMAIL_FUNCIONARIO, " +
                          "S_CEL_FUNCIONARIO, " +
                          "DT_NASC_FUNCIONARIO " +
                          ") " +
                          "VALUES " +
                          "( " +
                          "@S_NM_FUNCIONARIO, " +
                          "@S_CPF_FUNCIONARIO, " +
                          "@S_END_FUNCIONARIO, " +
                          "@S_BAI_FUNCIONARIO, " +
                          "@S_CID_FUNCIONARIO, " +
                          "@S_UF_FUNCIONARIO, " +
                          "@S_CEP_FUNCIONARIO, " +
                          "@S_EMAIL_FUNCIONARIO, " +
                          "@S_CEL_FUNCIONARIO, " +
                          "@DT_NASC_FUNCIONARIO " +
                          "); " +
                          "SELECT IDENT_CURRENT('TB_FUNCIONARIO') AS 'CODPK'";
            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@S_NM_FUNCIONARIO", pobj_Funcionario.Nm_Funcionario);
            objCmd.Parameters.AddWithValue("@S_CPF_FUNCIONARIO", pobj_Funcionario.CPF_Funcionario);
            objCmd.Parameters.AddWithValue("@S_END_FUNCIONARIO", pobj_Funcionario.End_Funcionario);
            objCmd.Parameters.AddWithValue("@S_BAI_FUNCIONARIO", pobj_Funcionario.Bai_Funcionario);
            objCmd.Parameters.AddWithValue("@S_CID_FUNCIONARIO", pobj_Funcionario.Cid_Funcionario);
            objCmd.Parameters.AddWithValue("@S_UF_FUNCIONARIO", pobj_Funcionario.UF_Funcionario);
            objCmd.Parameters.AddWithValue("@S_CEP_FUNCIONARIO", pobj_Funcionario.CEP_Funcionario);
            objCmd.Parameters.AddWithValue("@S_EMAIL_FUNCIONARIO", pobj_Funcionario.Email_Funcionario);
            objCmd.Parameters.AddWithValue("@S_CEL_FUNCIONARIO", pobj_Funcionario.Cel_Funcionario);
            objCmd.Parameters.AddWithValue("@DT_NASC_FUNCIONARIO", pobj_Funcionario.Nasc_Funcionario);

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
                return pobj_Funcionario.Cod_Funcionario;
            }
        }

        /****************************************************************************************
        *              Método: Alterar
        *                Obs.: Responsável por Alterar a Tupla que está no objeto Funcionario na tabela
        *                      TB_FUNCIONARIO.
        *           Parametro: Objeto Funcionario
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Alterar(Funcionario pobj_Funcionario)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "UPDATE TB_FUNCIONARIO SET " +
                          "S_NM_FUNCIONARIO = @S_NM_FUNCIONARIO," +
                          "S_EMAIL_FUNCIONARIO  = @S_EMAIL_FUNCIONARIO " +
                          "WHERE I_COD_FUNCIONARIO = @I_COD_FUNCIONARIO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_FUNCIONARIO", pobj_Funcionario.Cod_Funcionario);
            objCmd.Parameters.AddWithValue("@S_NM_FUNCIONARIO", pobj_Funcionario.Nm_Funcionario);
            objCmd.Parameters.AddWithValue("@S_CPF_FUNCIONARIO", pobj_Funcionario.CPF_Funcionario);
            objCmd.Parameters.AddWithValue("@S_END_FUNCIONARIO", pobj_Funcionario.End_Funcionario);
            objCmd.Parameters.AddWithValue("@S_BAI_FUNCIONARIO", pobj_Funcionario.Bai_Funcionario);
            objCmd.Parameters.AddWithValue("@S_CID_FUNCIONARIO", pobj_Funcionario.Cid_Funcionario);
            objCmd.Parameters.AddWithValue("@S_UF_FUNCIONARIO", pobj_Funcionario.UF_Funcionario);
            objCmd.Parameters.AddWithValue("@S_CEP_FUNCIONARIO", pobj_Funcionario.CEP_Funcionario);
            objCmd.Parameters.AddWithValue("@S_EMAIL_FUNCIONARIO", pobj_Funcionario.Email_Funcionario);
            objCmd.Parameters.AddWithValue("@S_CEL_FUNCIONARIO", pobj_Funcionario.Cel_Funcionario);
            objCmd.Parameters.AddWithValue("@DT_NASC_FUNCIONARIO", pobj_Funcionario.Nasc_Funcionario);

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
        *                Obs.: Responsável por Excluir a Tupla que está no objeto Funcionario na tabela
        *                      TB_FUNCIONARIO.
        *           Parametro: Objeto Funcionario
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Excluir(Funcionario pobj_Funcionario)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "DELETE FROM TB_FUNCIONARIO " +
                          "WHERE I_COD_FUNCIONARIO = @I_COD_FUNCIONARIO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_FUNCIONARIO", pobj_Funcionario.Cod_Funcionario);
            
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
        *                Obs.: Responsável por Encontrar a Tupla que está na tabela TB_FUNCIONARIO pelo
        *                      Códido da agenda.
        *           Parametro: Objeto Funcionario (Vazio)
        *             Retorno: Objeto Funcionario (Cheio)
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public Funcionario FindByCod(Funcionario pobj_Funcionario)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_FUNCIONARIO " +
                          "WHERE I_COD_FUNCIONARIO = @I_COD_FUNCIONARIO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_FUNCIONARIO", pobj_Funcionario.Cod_Funcionario);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    objDtr.Read();
                    pobj_Funcionario.Cod_Funcionario = Convert.ToInt16(objDtr["I_COD_FUNCIONARIO"]);
                    pobj_Funcionario.Nm_Funcionario = (objDtr["S_NM_FUNCIONARIO"]).ToString();
                    pobj_Funcionario.CPF_Funcionario = (objDtr["S_CPF_FUNCIONARIO"]).ToString();
                    pobj_Funcionario.End_Funcionario = (objDtr["S_END_FUNCIONARIO"]).ToString();
                    pobj_Funcionario.Bai_Funcionario = (objDtr["S_BAI_FUNCIONARIO"]).ToString();
                    pobj_Funcionario.Cid_Funcionario = (objDtr["S_CID_FUNCIONARIO"]).ToString();
                    pobj_Funcionario.UF_Funcionario = (objDtr["S_UF_FUNCIONARIO"]).ToString();
                    pobj_Funcionario.CEP_Funcionario = (objDtr["S_CEP_FUNCIONARIO"]).ToString();
                    pobj_Funcionario.Email_Funcionario = (objDtr["S_EMAIL_FUNCIONARIO"]).ToString();
                    pobj_Funcionario.Cel_Funcionario = (objDtr["S_CEL_FUNCIONARIO"]).ToString();
                    pobj_Funcionario.Nasc_Funcionario = Convert.ToDateTime(objDtr["DT_NASC_FUNCIONARIO"]);

                    objCon.Close();
                    objDtr.Close();

                    return pobj_Funcionario;
                }
                else
                {
                    objCon.Close();
                    return pobj_Funcionario;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Funcionario;
            }
        }

        /****************************************************************************************
        *              Método: FindAll
        *                Obs.: Responsável por Encontrar todas as Tuplas que estão na tabela 
        *                      TB_FUNCIONARIO.
        *             Retorno: uma lista de todos os Objeto Funcionario
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public List<Funcionario> FindAll()
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_FUNCIONARIO ";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Funcionario> Lista = new List<Funcionario>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Funcionario obj_Funcionario = new Funcionario();
                        obj_Funcionario.Cod_Funcionario = Convert.ToInt16(objDtr["I_COD_FUNCIONARIO"]);
                        obj_Funcionario.Nm_Funcionario = (objDtr["S_NM_FUNCIONARIO"]).ToString();
                        obj_Funcionario.CPF_Funcionario = (objDtr["S_CPF_FUNCIONARIO"]).ToString();
                        obj_Funcionario.End_Funcionario = (objDtr["S_END_FUNCIONARIO"]).ToString();
                        obj_Funcionario.Bai_Funcionario = (objDtr["S_BAI_FUNCIONARIO"]).ToString();
                        obj_Funcionario.Cid_Funcionario = (objDtr["S_CID_FUNCIONARIO"]).ToString();
                        obj_Funcionario.UF_Funcionario = (objDtr["S_UF_FUNCIONARIO"]).ToString();
                        obj_Funcionario.CEP_Funcionario = (objDtr["S_CEP_FUNCIONARIO"]).ToString();
                        obj_Funcionario.Email_Funcionario = (objDtr["S_EMAIL_FUNCIONARIO"]).ToString();
                        obj_Funcionario.Cel_Funcionario = (objDtr["S_CEL_FUNCIONARIO"]).ToString();
                        obj_Funcionario.Nasc_Funcionario = Convert.ToDateTime(objDtr["DT_NASC_FUNCIONARIO"]);


                        Lista.Add(obj_Funcionario);

                    }

                }
                
                objCon.Close();
                objDtr.Close();

                return Lista;
                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Funcionario>();
            }
        }
    }
}
