using Opea.Registration.BFF.Models.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Opea.Registration.BFF.Services.Client.Interface
{
    public interface ICompanySizeService
    {
        Task<List<CompanySizeDTO>> GetAll();
    }
}
