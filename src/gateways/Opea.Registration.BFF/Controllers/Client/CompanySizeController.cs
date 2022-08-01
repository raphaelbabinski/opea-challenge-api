using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Opea.Registration.BFF.Models.Client;
using Opea.Registration.BFF.Services.Client.Interface;
using Opea.WebAPI.Core.Controllers;
using Opea.WebAPI.Core.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Opea.Registration.BFF.Controllers.Client
{
    [Route("company-size")]
    public class CompanySizeController : MainController
    {
        private readonly ICompanySizeService _companySizeService;
        private readonly IMemoryCache _memoryCache;

        public CompanySizeController(ICompanySizeService companySizeService, IMemoryCache memoryCache, INotifier notifier) : base(notifier)
        {
            _companySizeService = companySizeService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cacheModel = _memoryCache.Get<List<CompanySizeDTO>>("list_company_size");
            if (cacheModel != null)
                return CustomResponse(cacheModel);
            else
            {
                var model = await _companySizeService.GetAll();
                if (model is null)
                {
                    AddProcessingError("Porte da empresa não encontrado!");
                    return CustomResponse();
                }
                else
                    _memoryCache.Set("list_company_size", model, TimeSpan.FromHours(2));

                return CustomResponse(model);
            }
        }
    }
}
