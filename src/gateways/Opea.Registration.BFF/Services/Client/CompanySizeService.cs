using Microsoft.Extensions.Options;
using Opea.Registration.BFF.Extensions;
using Opea.Registration.BFF.Models.Client;
using Opea.Registration.BFF.Services.Client.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Opea.Registration.BFF.Services.Client
{
    public class CompanySizeService : Service, ICompanySizeService
    {
        private readonly HttpClient _httpClient;

        public CompanySizeService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ServicesUrl);
        }

        public async Task<List<CompanySizeDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync($"company-size");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TreatErrorResponse(response);

            return await DeserializarObjectResponse<List<CompanySizeDTO>>(response);
        }
    }
}