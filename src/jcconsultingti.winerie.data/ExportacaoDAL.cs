using System;
using System.Collections.Generic;
using System.Linq;
using jcconsultingti.winerie.model;
using jcconsultingti.utils;

namespace jcconsultingti.winerie.data
{
    public class ExportacaoDAL
    {
        private readonly _Contexto contexto;

        public ExportacaoDAL()
        {
            contexto = new _Contexto();
        }

        public List<Exportacao> ListarTodos(int? TipoArquivo)
        {
            var retornoLista = new List<Exportacao>();
            var commandText = ExportacaoSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new Exportacao
                {
                    id = row["id"].ToLong(),
                    idTipoArquivo = row["idTipoArquivo"].ToLong(),
                    idUsuarioExportacao = row["idUsuarioExportacao"].ToLong(),
                    dataInicioProcessamento = row["dataInicioProcessamento"].ToDateTime(),
                    dataFimProcessamento = row["dataFimProcessamento"].ToDateTime(),
                    idStatus = row["idStatus"].ToLong(),
                    qtdSucesso = row["qtdSucesso"].ToInt32(),
                    qtdIgnorada = row["qtdIgnorada"].ToInt32(),
                    nomeArquivoGerado = row["nomeArquivoGerado"],
                    nomeArquivoErro = row["nomeArquivoErro"]
                };

                retornoLista.Add(retorno);
            }

            if (TipoArquivo.HasValue)
                return retornoLista.Where(w => w.idTipoArquivo.Equals(TipoArquivo.Value)).ToList();
            else
                return retornoLista;
        }

        private long Inserir(Exportacao obj)
        {
            var commandText = ExportacaoSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"idTipoArquivo", obj.idTipoArquivo},
                {"idUsuarioExportacao", obj.idUsuarioExportacao},
                {"dataInicioProcessamento", obj.dataInicioProcessamento},
                {"dataFimProcessamento", obj.dataFimProcessamento},
                {"idStatus", obj.idStatus},
                {"qtdSucesso", obj.qtdSucesso},
                {"qtdIgnorada", obj.qtdIgnorada},
                {"nomeArquivoGerado", obj.nomeArquivoGerado},
                {"nomeArquivoErro", obj.nomeArquivoErro}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(Exportacao obj)
        {
            var commandText = ExportacaoSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"idTipoArquivo", obj.idTipoArquivo},
                {"idUsuarioExportacao", obj.idUsuarioExportacao},
                {"dataInicioProcessamento", obj.dataInicioProcessamento},
                {"dataFimProcessamento", obj.dataFimProcessamento},
                {"idStatus", obj.idStatus},
                {"qtdSucesso", obj.qtdSucesso},
                {"qtdIgnorada", obj.qtdIgnorada},
                {"nomeArquivoGerado", obj.nomeArquivoGerado},
                {"nomeArquivoErro", obj.nomeArquivoErro}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(Exportacao obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = ExportacaoSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public Exportacao ListarPorId(long id)
        {
            var retorno = new List<Exportacao>();
            var commandText = ExportacaoSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempExportacao = new Exportacao
                {
                    id = row["id"].ToLong(),
                    idTipoArquivo = row["idTipoArquivo"].ToLong(),
                    idUsuarioExportacao = row["idUsuarioExportacao"].ToLong(),
                    dataInicioProcessamento = row["dataInicioProcessamento"].ToDateTime(),
                    dataFimProcessamento = row["dataFimProcessamento"].ToDateTime(),
                    idStatus = row["idStatus"].ToLong(),
                    qtdSucesso = row["qtdSucesso"].ToInt32(),
                    qtdIgnorada = row["qtdIgnorada"].ToInt32(),
                    nomeArquivoGerado = row["nomeArquivoGerado"],
                    nomeArquivoErro = row["nomeArquivoErro"]
                };

                retorno.Add(tempExportacao);
            }

            return retorno.FirstOrDefault();
        }

        public bool AtualizarStatusExportacao(long idStatusAtual, long idStatusNovo)
        {
            try
            {
                var commandText = ExportacaoSQL.AtualizarStatusExportacao;
                var parametros = new Dictionary<string, object>
                {
                    { "idStatusAtual", idStatusAtual },
                    { "idStatusNovo", idStatusNovo }
                };

                contexto.ExecutaComando(commandText, parametros);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AtualizarStatusExportacao(long idExportacao, long idStatusAtual, long idStatusNovo)
        {
            try
            {
                var commandText = ExportacaoSQL.AtualizarStatusExportacaoPorId;
                var parametros = new Dictionary<string, object>
                {
                    { "idExportacao", idExportacao },
                    { "idStatusAtual", idStatusAtual },
                    { "idStatusNovo", idStatusNovo }
                };

                contexto.ExecutaComando(commandText, parametros);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
