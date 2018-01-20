using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using Telefonia.Dominio.Repositorio;
using Telefonia.Dominio.Servico;
using Telefonia.Dominio.Servico.Interface;
using Telefonia.Repositorio;
using Telefonia.Repositorio.Consulta;

namespace Telefonia.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configuração da Web API self-host. 
            var config = new HttpConfiguration();

            // Configurando rotas
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Habilitando o cors
            config.EnableCors();

            // Configurações de injeção de dependência
            ConfiguracaoDi(appBuilder, config);

            // Configurações de formato de saida
            ConfiguracaoJson(config);

            // Ativando as configurações
            appBuilder.UseWebApi(config);
        }

        private void ConfiguracaoJson(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            config.Formatters.JsonFormatter.SerializerSettings = jsonSerializerSettings;
        }

        private void ConfiguracaoDi(IAppBuilder appBuilder, HttpConfiguration config)
        {
            var connectionStrings = ConfigurationManager.ConnectionStrings;

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var connectionString = connectionStrings["connection"].ConnectionString;

            builder.RegisterType<ServicoLog>().As<IServicoLog>().InstancePerRequest();
            builder.RegisterType<ServicoLogin>().As<IServicoLogin>().InstancePerRequest();
            builder.RegisterType<EFRepositorioLog>().As<IRepositorioLog>().WithParameter("connectionString", connectionString).InstancePerRequest();
            builder.RegisterType<Contexto>().WithParameter("connectionString", connectionString).InstancePerRequest();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
        }
    }
}
