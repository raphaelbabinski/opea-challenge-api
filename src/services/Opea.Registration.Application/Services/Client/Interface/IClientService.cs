using Opea.Registration.Application.Model.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Opea.Registration.Application.Services.Client.Interface
{
    public interface IClientService
    {
        Task Add(ClientDTO model);
        Task Update(ClientDTO model);
        Task Remove(Guid id);
        Task<Business.Domain.Client.Client> GetById(Guid id);
        Task<List<Business.Domain.Client.Client>> GetAllFromSql();
        Task<List<Business.Domain.Client.Client>> GetAll();
    }
}