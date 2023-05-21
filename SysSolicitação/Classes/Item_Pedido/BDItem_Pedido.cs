/****************************************************************************************
 *                Nome: BDItem_Pedido
 *                Obs.: Representa a Classe de Entidade BDItem_Pedido com Metodos Públicos que irão 
 *                      consultar, inserir, excluir e alterar os dados da tabela TB_ITEM_PEDIDO.
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
    class BDItem_Pedido
    {
        ~BDItem_Pedido()
        {

        }

        /****************************************************************************************
        *              Método: Incluir
        *                Obs.: Responsável por incluir a Tupla que está no objeto Item_Pedido na tabela
        *                      TB_ITEM_PEDIDO.
        *           Parametro: Objeto Item_Pedido
        *             Retorno: PK da Tupla inserida na tabela TB_ITEM_PEDIDO.
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public int Incluir(Item_Pedido pobj_Item_Pedido)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "INSERT INTO TB_ITEM_PEDIDO " +
                          "( " +
                          "I_COD_PEDIDO, " +
                          "I_COD_ESPETACULO, " +
                          "D_VLR_ITEM_PEDIDO, " +
                          "D_DESC_ITEM_PEDIDO, " +
                          "I_QUANT_ITEM_PEDIDO " +
                          ") " +
                          "VALUES " +
                          "( " +
                          "@I_COD_PEDIDO, " +
                          "@I_COD_ESPETACULO, " +
                          "@D_VLR_ITEM_PEDIDO, " +
                          "@D_DESC_ITEM_PEDIDO, " +
                          "@I_QUANT_ITEM_PEDIDO " +
                          "); " +
                          "SELECT IDENT_CURRENT('TB_ITEM_PEDIDO') AS 'CODPK'";
            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Item_Pedido.Cod_Pedido);
            objCmd.Parameters.AddWithValue("@I_COD_ESPETACULO", pobj_Item_Pedido.Cod_Espetaculo);
            objCmd.Parameters.AddWithValue("@D_VLR_ITEM_PEDIDO", pobj_Item_Pedido.Vlr_Item_Pedido);
            objCmd.Parameters.AddWithValue("@D_DESC_ITEM_PEDIDO", pobj_Item_Pedido.Desc_Item_Pedido);
            objCmd.Parameters.AddWithValue("@I_QUANT_ITEM_PEDIDO", pobj_Item_Pedido.Quant_Item_Pedido);

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
                return pobj_Item_Pedido.Cod_Item_Pedido;
            }
        }

        /****************************************************************************************
        *              Método: Excluir
        *                Obs.: Responsável por Excluir a Tupla que está no objeto Item_Pedido na tabela
        *                      TB_ITEM_PEDIDO.
        *           Parametro: Objeto Item_Pedido
        *             Retorno: Booleano
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public bool Excluir(Item_Pedido pobj_Item_Pedido)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "DELETE FROM TB_ITEM_PEDIDO " +
                          "WHERE I_COD_PEDIDO = @I_COD_PEDIDO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Item_Pedido.Cod_Pedido);

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
        *              Método: FindAll
        *                Obs.: Responsável por Encontrar todas as Tuplas que estão na tabela 
        *                      TB_ITEM_PEDIDO.
        *             Retorno: uma lista de todos os Objeto Item_Pedido
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: Este Metodo utiliza uma classe auxiliar para conexão com o BD.
        ****************************************************************************************/
        public List<Item_Pedido> FindAll(Item_Pedido pobj_Item_Pedido)
        {
            //Criar minha Conexão
            SqlConnection objCon = new SqlConnection(Connection.PathConnection());

            string sSQL = "SELECT * FROM TB_ITEM_PEDIDO " +
                          "WHERE I_COD_PEDIDO = @I_COD_PEDIDO";

            SqlCommand objCmd = new SqlCommand(sSQL, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Item_Pedido.Cod_Pedido);

            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Item_Pedido> Lista = new List<Item_Pedido>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Item_Pedido obj_Item_Pedido = new Item_Pedido();
                        obj_Item_Pedido.Cod_Item_Pedido = Convert.ToInt16(objDtr["I_COD_ITEM_PEDIDO"]);
                        obj_Item_Pedido.Cod_Pedido = Convert.ToInt16(objDtr["I_COD_PEDIDO"]);
                        obj_Item_Pedido.Cod_Espetaculo = Convert.ToInt16(objDtr["I_COD_ESPETACULO"]); ;
                        obj_Item_Pedido.Vlr_Item_Pedido = Convert.ToDouble(objDtr["D_VLR_ITEM_PEDIDO"]);
                        obj_Item_Pedido.Desc_Item_Pedido = Convert.ToDouble(objDtr["D_DESC_ITEM_PEDIDO"]);
                        obj_Item_Pedido.Quant_Item_Pedido = Convert.ToInt16(objDtr["I_QUANT_ITEM_PEDIDO"]);

                        Lista.Add(obj_Item_Pedido);
                    }
                }

                objCon.Close();
                objDtr.Close();

                return Lista;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Item_Pedido>();
            }
        }
    }
}
