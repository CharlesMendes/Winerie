using jcconsultingti.winerie.jobs;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace jcconsultingti.winerie.web
{
	public class Global : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Job's
            //EmailJobScheduler.Start();
            //ImportarPlanilhaJobScheduler.Start();
            //ConciliarPlanilhaJobScheduler.Start();
        }
	}
}
