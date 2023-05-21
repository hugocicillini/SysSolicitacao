/****************************************************************************************
 *                Nome: Pedido
 *                Obs.: Representa a Classe de Entidade Pedido com Atributos Privados e 
 *                      métodos de Get e Set Públicos
 *         Dt. Criação: 16/03/2023
 *       Dt. Alteração: --/--/----
 *          Criada por: Hugo
 ****************************************************************************************/
using System;
using System.Drawing;

namespace SysSolicitação
{
    public class Pedido
    {

        ~Pedido()
        {

        }

        #region Atributos Privados
        private int v_Cod_Pedido = -1;
        private int v_Cod_Funcionario = -1;
        private int v_Cod_Cliente = -1;
        private double v_Vlr_Pedido = 0;
        private DateTime v_DtHr_Pedido = DateTime.MinValue;


        #endregion

        #region Métodos Públicos
        public int Cod_Pedido
        { 
            get => v_Cod_Pedido; 
            set => v_Cod_Pedido = value; 
        }

        public int Cod_Funcionario
        { 
            get => v_Cod_Funcionario; 
            set => v_Cod_Funcionario = value; 
        }

        public int Cod_Cliente
        {
            get => v_Cod_Cliente;
            set => v_Cod_Cliente = value;
        }

        public double Vlr_Pedido
        {
            get => v_Vlr_Pedido;
            set => v_Vlr_Pedido = value;
        }

        public DateTime DtHr_Pedido
        {
            get => v_DtHr_Pedido;
            set => v_DtHr_Pedido = value;
        }

        #endregion

    }
}
