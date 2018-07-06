using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace jcconsultingti.winerie.web.Controllers
{
    public interface IController<T>
    {
        #region [ Metodos Comum ]
        ActionResult BuscarPorId(int id);
        ActionResult Salvar(T obj);
        #endregion

        #region [ Metodos CRUD ]
        //ActionResult Index();
        ActionResult Cadastrar();
        ActionResult Editar(int id);
        ActionResult Excluir(int id);
        #endregion

        #region [ HttpPost ]
        [HttpPost]
        ActionResult Cadastrar(T obj);

        [HttpPost]
        ActionResult Detalhe(int id);

        [HttpPost, ActionName("Excluir")]
        ActionResult ConfirmarExcluir(int id);

        [HttpPost]
        ActionResult Editar(T obj);
        #endregion

    }
}
