using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.data
{
    /// <summary>
    /// TBD_TIPORELATORIO
    /// TBD = Tabela de dominio
    /// </summary>
    public static class TipoRelatorioSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBD_TIPORELATORIO";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBD_TIPORELATORIO WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBD_TIPORELATORIO (nomeTipoRelatorio, versaoTipoRelatorio, descricao) VALUES (@nomeTipoRelatorio, @versaoTipoRelatorio, @descricao)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBD_TIPORELATORIO SET nomeTipoRelatorio = @nomeTipoRelatorio, descricao = @descricao, versaoTipoRelatorio = @versaoTipoRelatorio WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBD_TIPORELATORIO WHERE id = @id";
            }
        }
    }
}
