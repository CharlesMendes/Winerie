using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.data
{
    /// <summary>
    /// TBD_STATUS
    /// TBD = Tabela de dominio
    /// </summary>
    public static class StatusSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBD_STATUS";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBD_STATUS WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBD_STATUS (nomeStatus, descricao) VALUES (@nomeStatus, @descricao)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBD_STATUS SET nomeStatus = @nomeStatus, descricao = @descricao WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBD_STATUS WHERE id = @id";
            }
        }
    }
}
