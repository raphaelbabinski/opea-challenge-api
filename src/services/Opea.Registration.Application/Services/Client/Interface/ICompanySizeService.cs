using Opea.Registration.Business.Domain.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Opea.Registration.Application.Services.Client.Interface
{
    public interface ICompanySizeService
    {
        Task<List<CompanySize>> GetAll();
    }
}