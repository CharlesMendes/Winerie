using System;
using System.Collections.Generic;
using System.Linq;
using jcconsultingti.winerie.model;
using jcconsultingti.utils;

namespace jcconsultingti.winerie.data
{
    public class TipoRelatorioDAL
    {
        private readonly _Contexto contexto;

        public TipoRelatorioDAL()
        {
            contexto = new _Contexto();
        }

        public List<TipoRelatorio> ListarTodos()
        {
            var retornoLista = new List<TipoRelatorio>();
            var commandText = TipoRelatorioSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new TipoRelatorio
                {
                    id = row["id"].ToLong(),
                    nomeTipoRelatorio = row["nomeTipoRelatorio"],
                    versaoTipoRelatorio = row["versaoTipoRelatorio"].ToInt32(),
                    descricao = row["descricao"]
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(TipoRelatorio obj)
        {
            var commandText = TipoRelatorioSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"nomeTipoRelatorio", obj.nomeTipoRelatorio},
                {"versaoTipoRelatorio", obj.versaoTipoRelatorio},
                {"descricao", obj.descricao}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(TipoRelatorio obj)
        {
            var commandText = TipoRelatorioSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"nomeTipoRelatorio", obj.nomeTipoRelatorio},
                {"versaoTipoRelatorio", obj.versaoTipoRelatorio},
                {"descricao", obj.descricao}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(TipoRelatorio obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = TipoRelatorioSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public TipoRelatorio ListarPorId(long id)
        {
            var retorno = new List<TipoRelatorio>();
            var commandText = TipoRelatorioSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempTipoRelatorio = new TipoRelatorio
                {
                    id = row["id"].ToLong(),
                    nomeTipoRelatorio = row["nomeTipoRelatorio"],
                    versaoTipoRelatorio = row["versaoTipoRelatorio"].ToInt32(),
                    descricao = row["descricao"]
                };

                retorno.Add(tempTipoRelatorio);
            }

            return retorno.FirstOrDefault();
        }
    }
}
