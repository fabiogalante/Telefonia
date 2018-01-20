using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Telefonia.Repositorio
{
    public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }
}
