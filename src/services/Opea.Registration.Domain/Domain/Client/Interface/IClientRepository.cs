using Opea.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Opea.Registration.Business.Domain.Client.Interface
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<List<Business.Domain.Client.Client>> GetAllFromSql();
    }
}