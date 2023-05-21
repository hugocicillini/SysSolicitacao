/****************************************************************************************
 *                Nome: BDCliente
 *                Obs.: Representa a Classe de Entidade BDCliente com Metodos Públicos que irão 
 *                      consultar, inserir, excluir e alterar os dados da tabela TB_CLIENTE.
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
    class BDCliente
    {
        ~BDCliente()
        {

        }

        /****************************************************************************************
        *              Método: Incluir
        *                Obs.: Responsável por incluir a Tupla que está no objeto Cliente na tabela
        *                      TB_CLIENTE.
        *           Parametro: Objeto Cliente
        *             Retorno: PK da Tupla inserida na tabela TB_CLIENTE.
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public int Incluir(Cliente pobj_Cliente)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "INSERT INTO TB_CLIENTE " +
                          "( " +
                          "S_NM_CLIENTE, " +
                          "S_EMAIL_CLIENTE, " +
                          "S_RG_CLIENTE, " +
                          "S_CPF_CLIENTE " +
                          ") " +
                          "VALUES " +
                          "( " +
                          "@S_NM_CLIENTE, " +
                          "@S_EMAIL_CLIENTE, " +
                          "@S_RG_CLIENTE, " +
                          "@S_CPF_CLIENTE " +
                          "); " +
                          "SELECT IDENT_CURRENT('TB_CLIENTE') AS 'CODPK'";
            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@S_NM_CLIENTE", pobj_Cliente.Nm_Cliente);
            objCmd.Parameters.AddWithValue("@S_EMAIL_CLIENTE", pobj_Cliente.Email_Cliente);
            objCmd.Parameters.AddWithValue("@S_RG_CLIENTE", pobj_Cliente.RG_Cliente);
            objCmd.Parameters.AddWithValue("@S_CPF_CLIENTE", pobj_Cliente.CPF_Cliente);

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
                return pobj_Cliente.Cod_Cliente;
            }
        }

        /****************************************************************************************
        *              Método: Alterar
        *                Obs.: Responsável por Alterar a Tupla que está no objeto Cliente na tabela
        *                      TB_CLIENTE.
        *           Parametro: Objeto Cliente
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Alterar(Cliente pobj_Cliente)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "UPDATE TB_CLIENTE SET " +
                          "S_NM_CLIENTE = @S_NM_CLIENTE," +
                          "S_EMAIL_CLIENTE  = @S_EMAIL_CLIENTE, " +
                          "S_RG_CLIENTE  = @S_RG_CLIENTE, " +
                          "S_CPF_CLIENTE = @S_CPF_CLIENTE " +
                          "WHERE I_COD_CLIENTE = @I_COD_CLIENTE";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);
            objCmd.Parameters.AddWithValue("@S_NM_CLIENTE", pobj_Cliente.Nm_Cliente);
            objCmd.Parameters.AddWithValue("@S_EMAIL_CLIENTE", pobj_Cliente.Email_Cliente);
            objCmd.Parameters.AddWithValue("@S_RG_CLIENTE", pobj_Cliente.RG_Cliente);
            objCmd.Parameters.AddWithValue("@S_CPF_CLIENTE", pobj_Cliente.CPF_Cliente);

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
        *                Obs.: Responsável por Excluir a Tupla que está no objeto Cliente na tabela
        *                      TB_CLIENTE.
        *           Parametro: Objeto Cliente
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Excluir(Cliente pobj_Cliente)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "DELETE FROM TB_CLIENTE " +
                          "WHERE I_COD_CLIENTE = @I_COD_CLIENTE";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);
            
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
        *                Obs.: Responsável por Encontrar a Tupla que está na tabela TB_CLIENTE pelo
        *                      Códido da agenda.
        *           Parametro: Objeto Cliente (Vazio)
        *             Retorno: Objeto Cliente (Cheio)
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public Cliente FindByCod(Cliente pobj_Cliente)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_CLIENTE " +
                          "WHERE I_COD_CLIENTE = @I_COD_CLIENTE";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    objDtr.Read();
                    pobj_Cliente.Cod_Cliente = Convert.ToInt16(objDtr["I_COD_CLIENTE"]);
                    pobj_Cliente.Nm_Cliente = (objDtr["S_NM_CLIENTE"]).ToString();
                    pobj_Cliente.Email_Cliente = (objDtr["S_EMAIL_CLIENTE"]).ToString();
                    pobj_Cliente.RG_Cliente = (objDtr["S_RG_CLIENTE"]).ToString();
                    pobj_Cliente.CPF_Cliente = (objDtr["S_CPF_CLIENTE"]).ToString();

                    objCon.Close();
                    objDtr.Close();

                    return pobj_Cliente;
                }
                else
                {
                    objCon.Close();
                    return pobj_Cliente;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Cliente;
            }
        }

        /****************************************************************************************
        *              Método: FindAll
        *                Obs.: Responsável por Encontrar todas as Tuplas que estão na tabela 
        *                      TB_CLIENTE.
        *             Retorno: uma lista de todos os Objeto Cliente
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public List<Cliente> FindAll()
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_CLIENTE ";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Cliente> Lista = new List<Cliente>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Cliente obj_Cliente = new Cliente();
                        obj_Cliente.Cod_Cliente = Convert.ToInt16(objDtr["I_COD_CLIENTE"]);
                        obj_Cliente.Nm_Cliente = (objDtr["S_NM_CLIENTE"]).ToString();
                        obj_Cliente.Email_Cliente = (objDtr["S_EMAIL_CLIENTE"]).ToString();
                        obj_Cliente.RG_Cliente = (objDtr["S_RG_CLIENTE"]).ToString();
                        obj_Cliente.CPF_Cliente = (objDtr["S_CPF_CLIENTE"]).ToString();


                        Lista.Add(obj_Cliente);

                    }

                }
                
                objCon.Close();
                objDtr.Close();

                return Lista;
                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Cliente>();
            }
        }
    }
}
