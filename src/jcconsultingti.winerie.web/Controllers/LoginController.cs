using jcconsultingti.winerie.business;
using jcconsultingti.winerie.model;
using jcconsultingti.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace jcconsultingti.winerie.web.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioBLL _bll;
        public LoginController()
        {
            _bll = new UsuarioBLL();
        }

        // GET: Login
        public ActionResult Index()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string _versaoSistema = string.Format("v{0}", appSettings["Versao"]);
            ViewBag.Versao = (_versaoSistema);

            return View();
        }

        [HttpPost]
        public ActionResult AutenticarUsuario(Usuario usuario)
        {
            if (_bll.AutenticarUsuario(usuario.login, usuario.senha))
                return RedirectToAction("Index", "Pedidos"); //Autenticado com sucesso redireciona para pagina principal
            else
            {
                ViewBag.MensagemErro = "O nome de usuário ou senha estão incorretos";
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Login
        public ActionResult AcessoNegado()
        {
            return View();
        }

        // GET: Logout
        public ActionResult Logout()
        {
            _bll.Logout();
            return RedirectToAction("Index", "Login");
        }
    }
}