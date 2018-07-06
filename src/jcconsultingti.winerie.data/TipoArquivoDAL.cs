using System;
using System.Collections.Generic;
using System.Linq;
using jcconsultingti.winerie.model;
using jcconsultingti.utils;

namespace jcconsultingti.winerie.data
{
    public class TipoArquivoDAL
    {
        private readonly _Contexto contexto;

        public TipoArquivoDAL()
        {
            contexto = new _Contexto();
        }

        public List<TipoArquivo> ListarTodos()
        {
            var retornoLista = new List<TipoArquivo>();
            var commandText = TipoArquivoSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new TipoArquivo
                {
                    id = row["id"].ToLong(),
                    nomeTipoArquivo = row["nomeTipoArquivo"],
                    padraoFormatoNomeArquivo = row["padraoFormatoNomeArquivo"],
                    descricao = row["descricao"]
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(TipoArquivo obj)
        {
            var commandText = TipoArquivoSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"nomeTipoArquivo", obj.nomeTipoArquivo},
                {"padraoFormatoNomeArquivo", obj.padraoFormatoNomeArquivo},
                {"descricao", obj.descricao}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(TipoArquivo obj)
        {
            var commandText = TipoArquivoSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"nomeTipoArquivo", obj.nomeTipoArquivo},
                {"padraoFormatoNomeArquivo", obj.padraoFormatoNomeArquivo},
                {"descricao", obj.descricao}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(TipoArquivo obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = TipoArquivoSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public TipoArquivo ListarPorId(long id)
        {
            var retorno = new List<TipoArquivo>();
            var commandText = TipoArquivoSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempTipoArquivo = new TipoArquivo
                {
                    id = row["id"].ToLong(),
                    nomeTipoArquivo = row["nomeTipoArquivo"],
                    padraoFormatoNomeArquivo = row["padraoFormatoNomeArquivo"],
                    descricao = row["descricao"]
                };

                retorno.Add(tempTipoArquivo);
            }

            return retorno.FirstOrDefault();
        }
    }
}
