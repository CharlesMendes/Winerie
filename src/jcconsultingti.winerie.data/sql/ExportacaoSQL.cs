using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.data
{
    /// <summary>
    /// TBR_EXPORTACAO
    /// TBR = Tabela de relacionamento
    /// </summary>
    public static class ExportacaoSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBR_EXPORTACAO";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBR_EXPORTACAO WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBR_EXPORTACAO (idTipoArquivo, idUsuarioExportacao, dataInicioProcessamento, dataFimProcessamento, idStatus, qtdSucesso, qtdIgnorada, nomeArquivoGerado, nomeArquivoErro) VALUES (@idTipoArquivo, @idUsuarioExportacao, @dataInicioProcessamento, @dataFimProcessamento, @idStatus, @qtdSucesso, @qtdIgnorada, @nomeArquivoGerado, @nomeArquivoErro)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBR_EXPORTACAO SET idTipoArquivo = @idTipoArquivo, idUsuarioExportacao = @idUsuarioExportacao, dataInicioProcessamento = @dataInicioProcessamento, dataFimProcessamento = @dataFimProcessamento, idStatus = @idStatus, qtdSucesso = @qtdSucesso, qtdIgnorada = @qtdIgnorada, nomeArquivoGerado = @nomeArquivoGerado, nomeArquivoErro = @nomeArquivoErro WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBR_EXPORTACAO WHERE id = @id";
            }
        }

        /// <summary>
        /// Atualiza o status da importação
        /// </summary>
        public static string AtualizarStatusExportacao
        {
            get
            {
                return @"UPDATE TBR_EXPORTACAO SET idStatus = @idStatusNovo WHERE idStatus= @idStatusAtual";
            }
        }

        public static string AtualizarStatusExportacaoPorId
        {
            get
            {
                return @"UPDATE TBR_EXPORTACAO SET idStatus = @idStatusNovo WHERE id = @idExportacao AND idStatus = @idStatusAtual";
            }
        }
    }
}
