using System.Threading.Tasks;

namespace Opea.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}