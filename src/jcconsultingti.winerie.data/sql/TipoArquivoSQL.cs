using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.data
{
    /// <summary>
    /// TBD_TIPOARQUIVO
    /// TBD = Tabela de dominio
    /// </summary>
    public static class TipoArquivoSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBD_TIPOARQUIVO";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBD_TIPOARQUIVO WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBD_TIPOARQUIVO (nomeTipoArquivo, padraoFormatoNomeArquivo, descricao) VALUES (@nomeTipoArquivo, @padraoFormatoNomeArquivo, @descricao)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBD_TIPOARQUIVO SET nomeTipoArquivo = @nomeTipoArquivo, padraoFormatoNomeArquivo = @padraoFormatoNomeArquivo, descricao = @descricao WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBD_TIPOARQUIVO WHERE id = @id";
            }
        }
    }
}
