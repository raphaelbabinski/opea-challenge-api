using Opea.Registration.Application.Services.Client.Interface;
using Opea.Registration.Business.Domain.Client;
using Opea.Registration.Business.Domain.Client.Interface;
using Opea.Registration.Data.Context;
using Opea.WebAPI.Core.Domain.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Opea.Registration.Application.Services.Client
{
    public class CompanySizeService : BaseService, ICompanySizeService
    {
        private readonly ICompanySizeRepository _companySizeRepository;

        public CompanySizeService(ServicesContext context, ICompanySizeRepository companySizeRepository, INotifier notifier) : base(notifier)
        {
            _companySizeRepository = companySizeRepository;
        }

        public async Task<List<CompanySize>> GetAll()
        {
            return await _companySizeRepository.GetAll();
        }
    }
}
