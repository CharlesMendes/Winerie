using Quartz;
using jcconsultingti.winerie.business;
using jcconsultingti.winerie.model;
using jcconsultingti.utils;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace jcconsultingti.winerie.jobs
{
    public class ConciliarPlanilhaJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //Verifica no web.config se esta ativo para enviar o job
            var appSettings = ConfigurationManager.AppSettings;
            var ativarJob = appSettings["AtivarJobs"].ToBoolean();

            if (ativarJob)
            {
                //ResultadoProcessamentoBLL _bllResultadoProcessamento = new ResultadoProcessamentoBLL();
                //_bllResultadoProcessamento.Conciliar();
            }
        }
    }
}