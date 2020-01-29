using Owin;
using ProductSoat.App_Start;
using System.Web.Http;

namespace ProductConsole2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            app.UseErrorPage();
#endif
            app.UseWelcomePage("/");

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseWebApi(config);

            //ajouter le gestion du resolver UnityDependancyResolver qui est déjà implémenté dans l'app web api
        }
    }
}
