using Microsoft.Extensions.Options;
using Opea.Core.Communication;
using Opea.Registration.BFF.Extensions;
using Opea.Registration.BFF.Models.Client;
using Opea.Registration.BFF.Services.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Opea.Registration.BFF.Services.Client
{
    public class ClientService : Service, IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ServicesUrl);
        }

        public async Task<ResponseResult> Add(ClientDTO model)
        {
            var response = await _httpClient.PostAsync("client", GetContent(model));

            if (!TreatErrorResponse(response)) return await DeserializarObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> Update(ClientDTO model)
        {
            var response = await _httpClient.PutAsync("client", GetContent(model));

            if (!TreatErrorResponse(response)) return await DeserializarObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> Remove(Guid Id)
        {
            var response = await _httpClient.DeleteAsync($"client/{Id}");

            if (!TreatErrorResponse(response)) return await DeserializarObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<List<ClientDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync($"client");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TreatErrorResponse(response);

            return await DeserializarObjectResponse<List<ClientDTO>>(response);
        }

        public async Task<List<ClientDTO>> GetAllFromSql()
        {
            var response = await _httpClient.GetAsync($"client/sql");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TreatErrorResponse(response);

            return await DeserializarObjectResponse<List<ClientDTO>>(response);
        }

        public async Task<ClientDTO> GetById(Guid Id)
        {
            var response = await _httpClient.GetAsync($"client/{Id}");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TreatErrorResponse(response);

            return await DeserializarObjectResponse<ClientDTO>(response);
        }
    }
}
