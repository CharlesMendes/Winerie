using System;
using System.Collections.Generic;
using System.Linq;
using jcconsultingti.winerie.model;
using jcconsultingti.utils;

namespace jcconsultingti.winerie.data
{
    public class UsuarioDAL
    {
        private readonly _Contexto contexto;

        public UsuarioDAL()
        {
            contexto = new _Contexto();
        }

        public List<Usuario> ListarTodos()
        {
            var retornoLista = new List<Usuario>();
            var commandText = UsuarioSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new Usuario
                {
                    id = row["id"].ToLong(),
                    nome = row["nome"],
                    login = row["login"],
                    senha = row["senha"],
                    dataUltimoLogin = row["dataUltimoLogin"].ToDateTime(),
                    idPerfilUsuario = row["idPerfilUsuario"].ToLong(),
                    isAtivo = row["isAtivo"].ToBoolean(),
                    email = row["email"]
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(Usuario obj)
        {
            var commandText = UsuarioSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"nome", obj.nome},
                {"login", obj.login},
                {"senha", obj.senha},
                {"dataUltimoLogin", obj.dataUltimoLogin},
                {"idPerfilUsuario", obj.idPerfilUsuario},
                {"isAtivo", obj.isAtivo},
                {"email", obj.email}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(Usuario obj)
        {
            var commandText = UsuarioSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"nome", obj.nome},
                {"login", obj.login},
                {"senha", obj.senha},
                {"dataUltimoLogin", obj.dataUltimoLogin},
                {"idPerfilUsuario", obj.idPerfilUsuario},
                {"isAtivo", obj.isAtivo},
                {"email", obj.email}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(Usuario obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = UsuarioSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public Usuario ListarPorId(long id)
        {
            var retorno = new List<Usuario>();
            var commandText = UsuarioSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempUsuario = new Usuario
                {
                    id = row["id"].ToLong(),
                    nome = row["nome"],
                    login = row["login"],
                    senha = row["senha"],
                    dataUltimoLogin = DateTime.Now,
                    dataUltimoLoginFeito = row["dataUltimoLogin"].ToDateTime(),
                    idPerfilUsuario = row["idPerfilUsuario"].ToLong(),
                    isAtivo = row["isAtivo"].ToBoolean(),
                    email = row["email"]
                };

                retorno.Add(tempUsuario);
            }

            return retorno.FirstOrDefault();
        }

        public Usuario BuscarPorLogin(string login)
        {
            var retorno = new List<Usuario>();
            var commandText = UsuarioSQL.BuscarPorLogin;

            var parametros = new Dictionary<string, object>
            {
                {"login", login}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempUsuario = new Usuario
                {
                    id = row["id"].ToLong(),
                    nome = row["nome"],
                    login = row["login"],
                    senha = row["senha"],
                    dataUltimoLogin = DateTime.Now,
                    dataUltimoLoginFeito = row["dataUltimoLogin"].ToDateTime(),
                    idPerfilUsuario = row["idPerfilUsuario"].ToLong(),
                    isAtivo = row["isAtivo"].ToBoolean(),
                    email = row["email"]
                };

                retorno.Add(tempUsuario);
            }

            return retorno.FirstOrDefault();
        }

        public Usuario AutenticarUsuario(string login, string senha)
        {
            var retorno = new List<Usuario>();
            var commandText = UsuarioSQL.AutenticarUsuario;

            var parametros = new Dictionary<string, object>
            {
                {"login", login},
                {"senha", senha}
            };
            //{"senha", senha.Decrypt("winerie")}

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempUsuario = new Usuario
                {
                    id = row["id"].ToLong(),
                    nome = row["nome"],
                    login = row["login"],
                    senha = row["senha"],
                    dataUltimoLogin = DateTime.Now,
                    dataUltimoLoginFeito = row["dataUltimoLogin"].ToDateTime(),
                    idPerfilUsuario = row["idPerfilUsuario"].ToLong(),
                    isAtivo = row["isAtivo"].ToBoolean(),
                    email = row["email"]
                };

                retorno.Add(tempUsuario);
            }

            return retorno.FirstOrDefault();
        }
    }
}
