using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telefonia.Dominio.Entidades
{
    public class Autenticacao
    {
        public string AuthServer { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string IntegrationEndPoint { get; set; }
    }
}
