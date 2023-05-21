/****************************************************************************************
 *                Nome: BDPedido
 *                Obs.: Representa a Classe de Entidade BDPedido com Metodos Públicos que irão 
 *                      consultar, inserir, excluir e alterar os dados da tabela TB_PEDIDO.
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
    class BDPedido
    {
        ~BDPedido()
        {

        }

        /****************************************************************************************
        *              Método: Incluir
        *                Obs.: Responsável por incluir a Tupla que está no objeto Pedido na tabela
        *                      TB_PEDIDO.
        *           Parametro: Objeto Pedido
        *             Retorno: PK da Tupla inserida na tabela TB_PEDIDO.
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public int Incluir(Pedido pobj_Pedido)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "INSERT INTO TB_PEDIDO " +
                          "( " +
                          "I_COD_FUNCIONARIO, " +
                          "I_COD_CLIENTE, " +
                          "DT_DTHR_PEDIDO " +
                          ") " +
                          "VALUES " +
                          "( " +
                          "@I_COD_FUNCIONARIO, " +
                          "@I_COD_CLIENTE, " +
                          "@DT_DTHR_PEDIDO " +
                          "); " +
                          "SELECT IDENT_CURRENT('TB_PEDIDO') AS 'CODPK'";
            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_FUNCIONARIO", pobj_Pedido.Cod_Funcionario);
            objCmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Pedido.Cod_Cliente);
            objCmd.Parameters.AddWithValue("@DT_DTHR_PEDIDO", pobj_Pedido.DtHr_Pedido);

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
                return pobj_Pedido.Cod_Pedido;
            }
        }

        /****************************************************************************************
        *              Método: Alterar
        *                Obs.: Responsável por Alterar a Tupla que está no objeto Pedido na tabela
        *                      TB_PEDIDO.
        *           Parametro: Objeto Pedido
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Alterar(Pedido pobj_Pedido)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "UPDATE TB_PEDIDO SET " +
                          "I_COD_FUNCIONARIO = @I_COD_FUNCIONARIO," +
                          "I_COD_CLIENTE  = @I_COD_CLIENTE, " +
                          "DT_DTHR_PEDIDO  = @DT_DTHR_PEDIDO " +
                          "WHERE I_COD_PEDIDO = @I_COD_PEDIDO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Pedido.Cod_Pedido);
            objCmd.Parameters.AddWithValue("@I_COD_FUNCIONARIO", pobj_Pedido.Cod_Funcionario);
            objCmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Pedido.Cod_Cliente);
            objCmd.Parameters.AddWithValue("@DT_DTHR_PEDIDO", pobj_Pedido.DtHr_Pedido);

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
        *                Obs.: Responsável por Excluir a Tupla que está no objeto Pedido na tabela
        *                      TB_PEDIDO.
        *           Parametro: Objeto Pedido
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Excluir(Pedido pobj_Pedido)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "DELETE FROM TB_PEDIDO " +
                          "WHERE I_COD_PEDIDO = @I_COD_PEDIDO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Pedido.Cod_Pedido);
            
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
        *                Obs.: Responsável por Encontrar a Tupla que está na tabela TB_PEDIDO pelo
        *                      Códido da agenda.
        *           Parametro: Objeto Pedido (Vazio)
        *             Retorno: Objeto Pedido (Cheio)
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public Pedido FindByCod(Pedido pobj_Pedido)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_PEDIDO " +
                          "WHERE I_COD_PEDIDO = @I_COD_PEDIDO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Pedido.Cod_Pedido);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    objDtr.Read();
                    pobj_Pedido.Cod_Pedido = Convert.ToInt16(objDtr["I_COD_PEDIDO"]);
                    pobj_Pedido.Cod_Funcionario = Convert.ToInt16(objDtr["I_COD_FUNCIONARIO"]);
                    pobj_Pedido.Cod_Cliente = Convert.ToInt16(objDtr["I_COD_CLIENTE"]);
                    pobj_Pedido.DtHr_Pedido = Convert.ToDateTime(objDtr["DT_DTHR_PEDIDO"]);

                    objCon.Close();
                    objDtr.Close();

                    return pobj_Pedido;
                }
                else
                {
                    objCon.Close();
                    return pobj_Pedido;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Pedido;
            }
        }

        /****************************************************************************************
        *              Método: FindAll
        *                Obs.: Responsável por Encontrar todas as Tuplas que estão na tabela 
        *                      TB_PEDIDO.
        *             Retorno: uma lista de todos os Objeto Pedido
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public List<Pedido> FindAll()
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_PEDIDO ";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Pedido> Lista = new List<Pedido>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Pedido obj_Pedido = new Pedido();
                        obj_Pedido.Cod_Pedido = Convert.ToInt16(objDtr["I_COD_PEDIDO"]);
                        obj_Pedido.Cod_Funcionario = Convert.ToInt16(objDtr["I_COD_FUNCIONARIO"]);
                        obj_Pedido.Cod_Cliente = Convert.ToInt16(objDtr["I_COD_CLIENTE"]);
                        obj_Pedido.DtHr_Pedido = Convert.ToDateTime(objDtr["DT_DTHR_PEDIDO"]);


                        Lista.Add(obj_Pedido);

                    }

                }
                
                objCon.Close();
                objDtr.Close();

                return Lista;
                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Pedido>();
            }
        }
    }
}
