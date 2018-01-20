using System.Threading.Tasks;
using Telefonia.Dominio.Entidades;

namespace Telefonia.Dominio.Servico.Interface
{
    public interface IServicoLogin
    {
        Task<DadosAcesso> Login();
    }
}
