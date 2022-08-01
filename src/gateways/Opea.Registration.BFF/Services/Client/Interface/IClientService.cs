using Opea.Core.Communication;
using Opea.Registration.BFF.Models.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Opea.Registration.BFF.Services.Client.Interface
{
    public interface IClientService
    {
        Task<ResponseResult> Add(ClientDTO model);
        Task<ResponseResult> Update(ClientDTO model);
        Task<ResponseResult> Remove(Guid Id);
        Task<List<ClientDTO>> GetAll();
        Task<List<ClientDTO>> GetAllFromSql();
        Task<ClientDTO> GetById(Guid Id);
    }
}