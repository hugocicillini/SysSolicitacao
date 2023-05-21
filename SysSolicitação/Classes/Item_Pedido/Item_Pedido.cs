/****************************************************************************************
 *                Nome: Item_Pedido
 *                Obs.: Representa a Classe de Entidade Item_Pedido com Atributos Privados e 
 *                      métodos de Get e Set Públicos
 *         Dt. Criação: 16/03/2023
 *       Dt. Alteração: --/--/----
 *          Criada por: Hugo
 ****************************************************************************************/
using System;
using System.Drawing;

namespace SysSolicitação
{
    public class Item_Pedido
    {

        ~Item_Pedido()
        {

        }

        #region Atributos Privados
        private int v_Cod_Item_Pedido = -1;
        private int v_Cod_Pedido = -1;
        private int v_Cod_Espetaculo = -1;
        private int v_Quant_Item_Pedido = 0;
        private double v_Desc_Item_Pedido = 0;
        private double v_Vlr_Item_Pedido = 0;


        #endregion

        #region Métodos Públicos
        public int Cod_Item_Pedido
        { 
            get => v_Cod_Item_Pedido; 
            set => v_Cod_Item_Pedido = value; 
        }

        public int Cod_Pedido
        { 
            get => v_Cod_Pedido; 
            set => v_Cod_Pedido = value; 
        }

        public int Quant_Item_Pedido
        {
            get => v_Quant_Item_Pedido;
            set => v_Quant_Item_Pedido = value;
        }

        public int Cod_Espetaculo
        {
            get => v_Cod_Espetaculo;
            set => v_Cod_Espetaculo = value;
        }

        public double Desc_Item_Pedido
        {
            get => v_Desc_Item_Pedido;
            set => v_Desc_Item_Pedido = value;
        }

        public double Vlr_Item_Pedido
        {
            get => v_Vlr_Item_Pedido;
            set => v_Vlr_Item_Pedido = value;
        }

        #endregion

    }
}
