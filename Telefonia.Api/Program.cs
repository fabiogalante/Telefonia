using Microsoft.Owin.Hosting;
using System;
using System.Configuration;
using Telefonia.Repositorio;

namespace Telefonia.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigurationManager.AppSettings;

            var urlBase = $"{config["url_base"]}:{config["porta"]}/";

            // Start OWIN host 
            using (WebApp.Start(urlBase))
            {
                Console.WriteLine($"Micro serviço inicializado em {urlBase}");
                Console.ReadKey();
            }
        }
    }
}
