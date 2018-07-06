using System;
using System.Collections.Generic;
using System.Linq;
using jcconsultingti.winerie.model;
using jcconsultingti.utils;

namespace jcconsultingti.winerie.data
{
    public class StatusDAL
    {
        private readonly _Contexto contexto;

        public StatusDAL()
        {
            contexto = new _Contexto();
        }

        public List<Status> ListarTodos()
        {
            var retornoLista = new List<Status>();
            var commandText = StatusSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new Status
                {
                    id = row["id"].ToLong(),
                    nomeStatus = row["nomeStatus"],
                    descricao = row["descricao"]
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(Status obj)
        {
            var commandText = StatusSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"nomeStatus", obj.nomeStatus},
                {"descricao", obj.descricao}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(Status obj)
        {
            var commandText = StatusSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"nomeStatus", obj.nomeStatus},
                {"descricao", obj.descricao}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(Status obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = StatusSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public Status ListarPorId(long id)
        {
            var retorno = new List<Status>();
            var commandText = StatusSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempStatus = new Status
                {
                    id = row["id"].ToLong(),
                    nomeStatus = row["nomeStatus"],
                    descricao = row["descricao"]
                };

                retorno.Add(tempStatus);
            }

            return retorno.FirstOrDefault();
        }
    }
}
