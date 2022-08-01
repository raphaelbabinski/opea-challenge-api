using Microsoft.AspNetCore.Mvc;
using Opea.Registration.Application.Services.Client.Interface;
using Opea.WebAPI.Core.Controllers;
using Opea.WebAPI.Core.Domain.Notifications;
using System.Threading.Tasks;

namespace Opea.Registration.Application.Controllers.Client
{
    [Route("company-size")]
    public class CompanySizeController : MainController
    {
        private readonly ICompanySizeService _companySizeControllerService;

        public CompanySizeController(ICompanySizeService companySizeControllerService, INotifier notifier) : base(notifier)
        {
            _companySizeControllerService = companySizeControllerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await _companySizeControllerService.GetAll();

            return model == null ? NotFound() : CustomResponse(model);
        }
    }
}