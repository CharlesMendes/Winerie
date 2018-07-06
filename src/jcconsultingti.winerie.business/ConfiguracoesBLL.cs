using System;
using System.Collections.Generic;
using jcconsultingti.winerie.model;
using jcconsultingti.winerie.data;

namespace jcconsultingti.winerie.business
{
    public class ConfiguracoesBLL
    {
        private ConfiguracoesDAL _dal;

        public ConfiguracoesBLL()
        {
            _dal = new ConfiguracoesDAL();
        }

        public void ZerarBase()
        {
            _dal.ZerarBase();
        }
    }
}
