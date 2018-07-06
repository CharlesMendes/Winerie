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
    public class ConfiguracoesController : BaseController
    {
        private ConfiguracoesBLL _bll;
        private ExportacaoBLL _bllExportacao;

        public ConfiguracoesController()
        {
            _bll = new ConfiguracoesBLL();
            _bllExportacao = new ExportacaoBLL();
        }

        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult Index()
        {
            return View();
        }

        [PermissoesFiltro(Roles = "ADMIN")]
        public ActionResult ZerarBase()
        {
            //_bll.ZerarBase();
            return View("Index");
        }
    }
}
