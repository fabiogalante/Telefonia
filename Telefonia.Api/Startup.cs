using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Telefonia.Dominio.Servico;
using Telefonia.Dominio.Servico.Interface;

namespace Telefonia.Api
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
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

            // Filtro de excessão
            // config.Filters.Add(new SuperExceptionFilter());

            // Configurações de injeção de dependência
            ConfiguracaoDi(appBuilder, config);

            // Habilitando o cors
            config.EnableCors();

            // Configurações de formato de saida
            ConfiguracaoJson(config);

            // Configuração de acesso
            var optionsConfigurationToken = new OAuthAuthorizationServerOptions
            {
                // Permitindo acesso ao endereço de fornecimento do token precisar de HTTPS. Em produção o valor deve ser FALSE
                AllowInsecureHttp = true,

                // Endereço do fornecimento do token de acesso
                TokenEndpointPath = new PathString("/token"),

                // Tempo do token de acesso
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1),

                Provider = new ProviderTokenAccess()
            };

            // Ativar o token de acesso WebApi
            appBuilder.UseOAuthAuthorizationServer(optionsConfigurationToken);
            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

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

        private void ConfiguracaoAcessoToken(IAppBuilder appBuilder)
        {
            
        }

        private void ConfiguracaoDi(IAppBuilder appBuilder, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ServicoLog>().As<IServicoLog>().InstancePerRequest();
            builder.RegisterType<ServicoImportacao>().As<IServicoImportacao>().InstancePerRequest();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
        }
    }
}
