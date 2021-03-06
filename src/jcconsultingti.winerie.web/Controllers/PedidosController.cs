﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using jcconsultingti.winerie.business;
using jcconsultingti.winerie.model;
using jcconsultingti.utils;
using jcconsultingti.winerie.business.security;
using System.Configuration;
using jcconsultingti.winerie.model.tiny;

namespace jcconsultingti.winerie.web.Controllers
{
    public class PedidosController : BaseController, IController<Exportacao>
    {
        private PedidosBLL _bll;
        private ExportacaoBLL _bllExportacao;

        public PedidosController()
        {
            _bll = new PedidosBLL();
            _bllExportacao = new ExportacaoBLL();
        }

        public ActionResult Index()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string _versaoSistema = string.Format("v{0}", appSettings["Versao"]);
            ViewBag.Versao = (_versaoSistema);

            var lista = new List<PesquisarPedidos>();
            lista.Add(new PesquisarPedidos()
            {
                filtros = new PesquisarRequest()
                {
                    dataInicial = DateTime.Now.ToShortDateString(),
                    dataFinal = DateTime.Now.ToShortDateString()
                }
            });

            return View(lista);
        }

        public ActionResult Download(string dataInicial, string dataFinal)
        {
            if (dataInicial == null && TempData["datas"] != null)
            {
                var datas = TempData["datas"].ToString().Split('|').ToArray();
                dataInicial = datas[0];
                dataFinal = datas[1];
            }

            return this.DownloadPorId(0, dataInicial, dataFinal); //Todos os pedidos
        }

        public ActionResult BuscarPorId(int id)
        {
            var pedidoCompleto = _bll.Detalhe(id.ToLong());
            return View(pedidoCompleto);
        }

        public ActionResult DownloadPorId(int id, string dataInicial, string dataFinal)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string _diretorioProcessado = appSettings["_diretorioProcessado"];
            var nomeArquivoGerado = _bllExportacao.ExportarPedido(id, dataInicial, dataFinal);

            string filepath = string.Format("{0}{1}{2}", AppDomain.CurrentDomain.BaseDirectory, _diretorioProcessado, nomeArquivoGerado);

            if (System.IO.File.Exists(filepath))
            {
                byte[] filedata = System.IO.File.ReadAllBytes(filepath);
                string contentType = MimeMapping.GetMimeMapping(filepath);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = nomeArquivoGerado,
                    Inline = false,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(filedata, contentType);
            }
            else
                return RedirectToAction("Index");
        }

        public ActionResult Salvar(Exportacao obj)
        {
            throw new NotImplementedException();
        }

        public ActionResult Cadastrar()
        {
            throw new NotImplementedException();
        }

        public ActionResult Editar(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Cadastrar(Exportacao obj)
        {
            throw new NotImplementedException();
        }

        public ActionResult Detalhe(int id)
        {
            return this.BuscarPorId(id);
        }

        public ActionResult ConfirmarExcluir(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Editar(Exportacao obj)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Index(PesquisarPedidos obj)
        {
            if (ModelState.IsValid)
            {
                TempData["datas"] = string.Format("{0}|{1}", obj.filtros.dataInicial, obj.filtros.dataFinal);
                TempData["datas1"] = string.Format("{0}|{1}", obj.filtros.dataInicial, obj.filtros.dataFinal);

                var lista = _bll.ListarTodos(obj.filtros);
                return View(lista);
            }

            return RedirectToAction("Index");
        }
    }
}
