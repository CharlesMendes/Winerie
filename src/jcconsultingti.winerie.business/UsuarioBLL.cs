using System;
using System.Collections.Generic;
using jcconsultingti.winerie.model;
using jcconsultingti.winerie.data;
using System.Web.Security;
using System.Web;

namespace jcconsultingti.winerie.business
{
    public class UsuarioBLL : ICrud<Usuario>
    {
        private UsuarioDAL _dal;

        //relacionamentos
        private PerfilUsuarioBLL _bllPerfilUsuario;

        public UsuarioBLL()
        {
            _dal = new UsuarioDAL();
            _bllPerfilUsuario = new PerfilUsuarioBLL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public Usuario Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);

            //relacionamentos
            retorno.perfilUsuario = _bllPerfilUsuario.Detalhe(retorno.idPerfilUsuario);

            return retorno;
        }

        public Usuario BuscarPorLogin(string login)
        {
            var _login = login.Split('|')[2].Split(':')[1];
            var retorno = _dal.BuscarPorLogin(_login);

            //relacionamentos
            if (retorno != null)
            {
                retorno.perfilUsuario = _bllPerfilUsuario.Detalhe(retorno.idPerfilUsuario);
            }

            return retorno;
        }

        public List<Usuario> ListarTodos()
        {
            var lista = new List<Usuario>();

            //relacionamentos
            foreach (var item in _dal.ListarTodos())
            {
                item.perfilUsuario = _bllPerfilUsuario.Detalhe(item.idPerfilUsuario);

                lista.Add(item);
            }

            return lista;
        }

        public long Salvar(Usuario obj)
        {
            return _dal.Salvar(obj);
        }

        public bool AutenticarUsuario(string login, string senha)
        {
            var usuarioLogado = _dal.AutenticarUsuario(login, senha);

            //Se nao encontrou usuario, retorna false
            if (usuarioLogado == null)
                return false;

            //Seta um cookie encriptado com o login do usuario autenticado
            var usuarioSessao = string.Format("idUsuario:{0}|x|login:{1}|nome:{2}|dataUltimoLoginFeito:{3}|idPerfilUsuario:{4}", usuarioLogado.id, usuarioLogado.login, usuarioLogado.nome, usuarioLogado.dataUltimoLoginFeito, usuarioLogado.idPerfilUsuario);
            FormsAuthentication.SetAuthCookie(usuarioSessao, false);

            usuarioLogado.dataUltimoLogin = DateTime.Now;
            _dal.Salvar(usuarioLogado);
            
            return true;
        }

        public Usuario GetUsuarioLogado()
        {
            //Pegamos o login do usuario logado
            var _cookie = HttpContext.Current.User.Identity.Name;
            var _login = _cookie.Split('|')[2].Split(':')[1];

            //Não existe usuario logado, retorna null
            if (string.IsNullOrEmpty(_login))
                return null;
            else
            {
                //Busca no banco de dados o usuario que esta logado
                var usuarioLogado = BuscarPorLogin(_login);
                return usuarioLogado;
            }
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
