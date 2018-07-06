using System;
using System.Collections.Generic;
using jcconsultingti.winerie.model;
using jcconsultingti.winerie.data;

namespace jcconsultingti.winerie.business
{
    public class TipoArquivoBLL : ICrud<TipoArquivo>
    {
        private TipoArquivoDAL _dal;

        public TipoArquivoBLL()
        {
            _dal = new TipoArquivoDAL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public TipoArquivo Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);
            return retorno;
        }

        public List<TipoArquivo> ListarTodos()
        {
            var lista = _dal.ListarTodos();
            return lista;
        }

        public long Salvar(TipoArquivo obj)
        {
            return _dal.Salvar(obj);
        }
    }
}
