/****************************************************************************************
 *                Nome: Connection
 *                Obs.: Representa a Classe de conexão com o banco de dados
 *         Dt. Criação: 16/03/2022
 *       Dt. Alteração: --/--/----
 *          Criada por: Hugo
 ****************************************************************************************/

namespace SysSolicitação
{
    class Connection
    {
        ~Connection()
        {

        }

        /****************************************************************************************
        *              Método: PathConnection
        *                Obs.: Responsável por retornar o caminho de onde o banco está
        *                      salvo na máquina local
        *             Retorno: Path do BD.
        *         Dt. Criação: 16/03/2022
        *       Dt. Alteração: --/--/----
        *          Criada por: Hugo
        ****************************************************************************************/
        public static string PathConnection()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=<--Caminho do Banco de Dados (.mdf)-->;Integrated Security=True;Connect Timeout = 15";
        }

    }
}
