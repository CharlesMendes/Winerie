using System;
using System.Collections.Generic;
using System.Linq;
using jcconsultingti.winerie.model;
using jcconsultingti.utils;

namespace jcconsultingti.winerie.data
{
    public class ConfiguracoesDAL
    {
        private readonly _Contexto contexto;

        public ConfiguracoesDAL()
        {
            contexto = new _Contexto();
        }
       
        public void ZerarBase()
        {
            var commandText = ConfiguracoesSQL.ZerarBase;
            contexto.ExecutaComandoProcedure(commandText, null);
        }
    }
}
