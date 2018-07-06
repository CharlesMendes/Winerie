using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using jcconsultingti.winerie.business;
using jcconsultingti.winerie.model;
using jcconsultingti.winerie.business.security;

namespace jcconsultingti.winerie.web.Controllers
{
    public class UsuarioController : BaseController, IController<Usuario>
    {
        private UsuarioBLL _bll;
        private PerfilUsuarioBLL _bllPerfilUsuario;

        public UsuarioController()
        {
            _bll = new UsuarioBLL();
            _bllPerfilUsuario = new PerfilUsuarioBLL();
        }

        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult BuscarPorId(int id)
        {
            var obj = _bll.Detalhe(id);

            if (obj == null)
                return HttpNotFound();

            this.MontarCombo_PerfilUsuario(obj.idPerfilUsuario);

            return View(obj);
        }

        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult Cadastrar()
        {
            this.MontarCombo_PerfilUsuario(0);

            return View();
        }

        [HttpPost]
        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult Cadastrar(Usuario obj)
        {
            this.MontarCombo_PerfilUsuario(obj.idPerfilUsuario);

            return this.Salvar(obj);
        }

        [HttpPost, ActionName("Excluir")]
        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult ConfirmarExcluir(int id)
        {
            _bll.Excluir(id);
            return RedirectToAction("Index");
        }

        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult Detalhe(int id)
        {
            return this.BuscarPorId(id);
        }

        [HttpPost]
        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult Editar(Usuario obj)
        {
            return this.Salvar(obj);
        }

        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult Editar(int id)
        {
            return this.BuscarPorId(id);
        }

        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult Excluir(int id)
        {
            return this.BuscarPorId(id);
        }

        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult Index()
        {
            var lista = _bll.ListarTodos();
            return View(lista);
        }

        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult Salvar(Usuario obj)
        {
            this.MontarCombo_PerfilUsuario(obj.idPerfilUsuario);

            if (ModelState.IsValid)
            {
                _bll.Salvar(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region Combobox

        private void MontarCombo_PerfilUsuario(long id)
        {
            var listaPerfilUsuario = _bllPerfilUsuario.ListarTodos();

            //Se usuário é ADMIN, remove perfil STARK
            if (User.IsInRole("ADMIN"))
            {
                listaPerfilUsuario.Remove(listaPerfilUsuario.FirstOrDefault(p => p.id == 1));
            }

            if (id.Equals(0)) // nao seleciona valor, carrega lista sem default
                ViewBag.listaPerfilUsuario = new SelectList
                (
                    listaPerfilUsuario.ToList(),
                    "id",
                    "nomePerfil"
                );
            else // carrega lista com o combo pre selecionado de acordo com o id
                ViewBag.listaPerfilUsuario = new SelectList
                (
                    listaPerfilUsuario.ToList(),
                    "id",
                    "nomePerfil",
                    id
                );
        }

        #endregion
    }
}
