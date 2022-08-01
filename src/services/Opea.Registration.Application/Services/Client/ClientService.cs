using BX.Core.Utils;
using Opea.Registration.Application.Model.Client;
using Opea.Registration.Application.Services.Client.Interface;
using Opea.Registration.Business.Domain.Client.Interface;
using Opea.Registration.Data.Context;
using Opea.WebAPI.Core.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Opea.Registration.Application.Services.Client
{
    public class ClientService : BaseService, IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(ServicesContext context, IClientRepository clientRepository, INotifier notifier) : base(notifier)
        {
            _clientRepository = clientRepository;
        }

        public async Task Add(ClientDTO model)
        {
            try
            {
                var entity = new Business.Domain.Client.Client(null, Guid.NewGuid(), model.Name.TrimIfNotNull(), model.CompanySizeId);
                _clientRepository.Add(entity);

                await _clientRepository.UnitOfWork.Commit();
            }
            catch(Exception ex)
            {
                Notifier(ex.Message);
            }
        }

        public async Task Update(ClientDTO model)
        {
            try
            {
                var client = await _clientRepository.GetById(model.Identifier);
                if (client != null)
                {
                    var entity = new Business.Domain.Client.Client(client.Id, model.Identifier, model.Name.TrimIfNotNull(), model.CompanySizeId);
                    _clientRepository.Update(entity);

                    await _clientRepository.UnitOfWork.Commit();
                }
                else
                    Notifier("Cliente não encontrado");
            }
            catch(Exception ex)
            {
                Notifier(ex.Message);
            }
        }

        public async Task Remove(Guid id)
        {
            var client = await _clientRepository.GetById(id);
            if (client != null)
            {
                _clientRepository.Remove(client);
                await _clientRepository.UnitOfWork.Commit();
            }
            else
                Notifier("Cliente não encontrado");
        }

        public async Task<Business.Domain.Client.Client> GetById(Guid id)
        {
            return await _clientRepository.GetById(id);
        }

        public async Task<List<Business.Domain.Client.Client>> GetAll()
        {
            return await _clientRepository.GetAll();
        }

        public async Task<List<Business.Domain.Client.Client>> GetAllFromSql()
        {
            return await _clientRepository.GetAllFromSql();
        }
    }
}