using System;
using System.Collections.Generic;
using System.Linq;
using jcconsultingti.winerie.model;
using jcconsultingti.utils;

namespace jcconsultingti.winerie.data
{
    public class PerfilUsuarioDAL
    {
        private readonly _Contexto contexto;

        public PerfilUsuarioDAL()
        {
            contexto = new _Contexto();
        }

        public List<PerfilUsuario> ListarTodos()
        {
            var retornoLista = new List<PerfilUsuario>();
            var commandText = PerfilUsuarioSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new PerfilUsuario
                {
                    id = row["id"].ToLong(),
                    nomePerfil = row["nomePerfil"],
                    descricao = row["descricao"]
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(PerfilUsuario obj)
        {
            var commandText = PerfilUsuarioSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"nomePerfil", obj.nomePerfil},
                {"descricao", obj.descricao}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(PerfilUsuario obj)
        {
            var commandText = PerfilUsuarioSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"nomePerfil", obj.nomePerfil},
                {"descricao", obj.descricao}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(PerfilUsuario obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = PerfilUsuarioSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public PerfilUsuario ListarPorId(long id)
        {
            var retorno = new List<PerfilUsuario>();
            var commandText = PerfilUsuarioSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempPerfilUsuario = new PerfilUsuario
                {
                    id = row["id"].ToLong(),
                    nomePerfil = row["nomePerfil"],
                    descricao = row["descricao"]
                };

                retorno.Add(tempPerfilUsuario);
            }

            return retorno.FirstOrDefault();
        }
    }
}
