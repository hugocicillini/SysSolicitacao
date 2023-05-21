using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SysSolicitação
{
    public class FuncGeral
    {

        private static byte[] bIV =
        { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18,
        0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        /// <summary>     
        /// Representação de valor em base 64 (Chave Interna)    
        /// O Valor representa a transformação para base64 de     
        /// um conjunto de 32 caracteres (8 * 32 = 256bits)    
        /// A chave é: "Criptografias com Rijndael / AES"     
        /// </summary>     
        private const string cryptoKey =
        "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";

        /*****************************************************************************
        *                   Nome: Criptografa
        *           Procedimento: Criptografa o password do usuário e retorna o 
        *                         pass criptografado
        *             Parametros: string sPassWord
        *            Dt. Criação: 18/03/2023
        *          Dt. Alteração: --/--/----
        *             Criada por: Hugo
        *            Observações: Percorre todos os componentes do painel Detalhe.
        * ***************************************************************************/
        public string Criptografa(string sPassWord)
        {

            try
            {
                // Se a string não está vazia, executa a criptografia
                if (!string.IsNullOrEmpty(sPassWord))
                {
                    // Cria instancias de vetores de bytes com as chaves                
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                    byte[] bText = new UTF8Encoding().GetBytes(sPassWord);

                    // Instancia a classe de criptografia Rijndael
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"                
                    // Lembre-se: chaves possíves:                
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)                
                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor criptografado:                
                    MemoryStream mStream = new MemoryStream();
                    // Instancia o encriptador                 
                    CryptoStream encryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateEncryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória
                    encryptor.Write(bText, 0, bText.Length);
                    // Despeja toda a memória.                
                    encryptor.FlushFinalBlock();
                    // Pega o vetor de bytes da memória e gera a string criptografada                
                    return Convert.ToBase64String(mStream.ToArray());
                }
                else
                {
                    // Se a string for vazia retorna nulo                
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Se algum erro ocorrer, dispara a exceção            
                throw new ApplicationException("Erro ao criptografar", ex);
            }
        }

        /*****************************************************************************
        *                   Nome: DesCriptografa
        *           Procedimento: Descriptografa o password do usuário e retorna o 
        *                         pass descriptografado
        *             Parametros: sCriptoPassWord
        *            Dt. Criação: 18/03/2023
        *          Dt. Alteração: --/--/----
        *             Criada por: Hugo
        *            Observações: Percorre todos os componentes do painel Detalhe.
        * ***************************************************************************/
        public string DesCriptografa(string sCriptoPassWord)
        {
            try
            {
                // Se a string não está vazia, executa a criptografia           
                if (!string.IsNullOrEmpty(sCriptoPassWord))
                {
                    // Cria instancias de vetores de bytes com as chaves                
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                    byte[] bText = Convert.FromBase64String(sCriptoPassWord);

                    // Instancia a classe de criptografia Rijndael                
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"                
                    // Lembre-se: chaves possíves:                
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)                
                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor DEScriptografado:               
                    MemoryStream mStream = new MemoryStream();

                    // Instancia o Decriptador                 
                    CryptoStream decryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateDecryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória   
                    decryptor.Write(bText, 0, bText.Length);
                    // Despeja toda a memória.                
                    decryptor.FlushFinalBlock();
                    // Instancia a classe de codificação para que a string venha de forma correta         
                    UTF8Encoding utf8 = new UTF8Encoding();
                    // Com o vetor de bytes da memória, gera a string descritografada em UTF8       
                    return utf8.GetString(mStream.ToArray());
                }
                else
                {
                    // Se a string for vazia retorna nulo                
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Se algum erro ocorrer, dispara a exceção            
                throw new ApplicationException("Erro ao descriptografar", ex);
            }
        }

        /****************************************************************************************
        *              Método: CalTotAgendamento
        *                Obs.: Responsável por nomear a tela do formulário 
        *                      passado por parametro.
        *           Parametro: ListView plv_Itens      
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: --
        ****************************************************************************************/
        public double CalTotPedido(ListView plv_Itens)
        {
            double d_SomaTot = 0;

            for (int i = 0; i < plv_Itens.Items.Count; i++)
            {
                d_SomaTot += Convert.ToDouble(plv_Itens.Items[i].SubItems[5].Text);
            }
            return d_SomaTot;
        }

        /****************************************************************************************
        *              Método: CalSubTotItem
        *                Obs.: Responsável por nomear a tela do formulário 
        *                      passado por parametro.
        *           Parametro: double pd_vlr, double pd_desc       
        *         Dt. Criação: 16/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: --
        ****************************************************************************************/
        public double CalSubTotItem(double pd_vlr, double pd_desc, int pi_quant)
        {
            return (pd_vlr * (1 - pd_desc / 100) * pi_quant);
        }

        /****************************************************************************************
        *              Método: HabilitaTela
        *                Obs.: Responsável por Habilitar ou desabilitar a tela do formulário 
        *                      passado por parametro.
        *           Parametro: Tela do Formulário e Booleano        
        *         Dt. Criação: 18/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: --
        ****************************************************************************************/
        public void HabilitaTela(Form pobj_Form, bool b_Hab)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detalhe")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl is TextBox && Convert.ToInt16(ctrl.Tag) != 1)
                        {
                            ((TextBox)ctrl).Enabled = b_Hab;
                        }

                        if (ctrl is CheckBox)
                        {
                            ((CheckBox)ctrl).Enabled = b_Hab;
                        }

                        if (ctrl is Button)
                        {
                            ((Button)ctrl).Enabled = b_Hab;
                        }
                    }
                }
            }
        }

        /****************************************************************************************
        *              Método: LimpaTela
        *                Obs.: Responsável por Limpar a tela do formulário passado por parametro.      
        *           Parametro: Tela do Formulário   
        *         Dt. Criação: 18/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: --
        ****************************************************************************************/
        public void LimpaTela(Form pobj_Form)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detalhe")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl is Label && Convert.ToInt16(ctrl.Tag) == 1)
                        {
                            ((Label)ctrl).Text = "";
                        }

                        if (ctrl is TextBox)
                        {
                            ((TextBox)ctrl).Clear();
                        }

                        if (ctrl is CheckBox)
                        {
                            ((CheckBox)ctrl).Checked = false;
                        }

                        if (ctrl is ListView)
                        {
                            ((ListView)ctrl).Items.Clear();
                        }

                        if (ctrl is ListBox)
                        {
                            ((ListBox)ctrl).Items.Clear();
                        }
                    }
                }
            }
        }

        /****************************************************************************************
        *              Método: StatusBtn
        *                Obs.: Responsável por setar o status dos botões do formulário passado 
        *                      por parametro.      
        *           Parametro: Tela do Formulário e um int              
        *         Dt. Criação: 18/03/2023
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        *          Observação: caso o int seja:
        *                      1 - Apenas o btn novo será habilitado e os demais ficarão 
        *                      desabilitados.
        *                      2 - os btns: novo, alterar e excluir habilitados e os demais ficarão 
        *                      desabilitados.
        *                      3 - os btns: cancelar e confirmar habilitados e os demais ficarão 
        *                      desabilitados.
        *          
        ****************************************************************************************/
        public void StatusBtn(Form pobj_Form, int i_Stat)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Botao")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        switch (i_Stat)
                        {
                            case 1:
                                {
                                    if (ctrl.Name == "btn_Novo")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    if (ctrl.Name == "btn_Alterar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Excluir")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Cancelar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Confirmar")
                                    {
                                        ctrl.Enabled = false;
                                    }
                                    break;
                                }

                            case 2:
                                {
                                    if (ctrl.Name == "btn_Novo")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    if (ctrl.Name == "btn_Alterar")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    if (ctrl.Name == "btn_Excluir")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    if (ctrl.Name == "btn_Cancelar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Confirmar")
                                    {
                                        ctrl.Enabled = false;
                                    }
                                    break;
                                }

                            case 3:
                                {
                                    if (ctrl.Name == "btn_Novo")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Alterar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Excluir")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Cancelar")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    if (ctrl.Name == "btn_Confirmar")
                                    {
                                        ctrl.Enabled = true;
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
        }
    }
}
