using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telefonia.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            //string baseAddress = "http://127.0.0.1:5003/";

            //// Start OWIN host 
            //using (WebApp.Start(url: baseAddress))
            //{
            //    Console.WriteLine("Service Listening at " + baseAddress);

            //    System.Threading.Thread.Sleep(-1);
            //}

            var config = ConfigurationManager.AppSettings;

            var urlBase = $"{config["url_base"]}:{config["porta"]}/";

            // Start OWIN host 
            using (WebApp.Start(urlBase))
            {
                Console.WriteLine($"Serviço inicializado em {urlBase}");
                Console.ReadKey();
            }
        }
    }
}
