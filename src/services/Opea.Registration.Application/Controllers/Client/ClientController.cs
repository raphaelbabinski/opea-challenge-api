using Microsoft.AspNetCore.Mvc;
using Opea.Registration.Application.Model.Client;
using Opea.Registration.Application.Services.Client;
using Opea.Registration.Application.Services.Client.Interface;
using Opea.Registration.Data.Context;
using Opea.WebAPI.Core.Controllers;
using Opea.WebAPI.Core.Domain.Notifications;
using System;
using System.Threading.Tasks;


namespace Opea.Registration.Application.Controllers.Client
{
    [Route("client")]
    public class ClientController : MainController
    {
        private readonly ServicesContext _context;
        private readonly IClientService _clientService;

        public ClientController(ServicesContext context, IClientService clientService, INotifier notifier) : base(notifier)
        {
            _context = context;
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ClientDTO model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clientService.Add(model);

            return CustomResponse();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ClientDTO model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clientService.Update(model);

            return CustomResponse();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clientService.Remove(id);

            return CustomResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var costCenter = await _clientService.GetAll();

            return costCenter == null ? NotFound() : CustomResponse(costCenter);
        }

        [HttpGet("sql")]
        public async Task<IActionResult> GetAllFromSql()
        {
            var costCenter = await _clientService.GetAllFromSql();

            return costCenter == null ? NotFound() : CustomResponse(costCenter);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var costCenter = await _clientService.GetById(id);

            return costCenter == null ? NotFound() : CustomResponse(costCenter);
        }

        private async Task PersistirDados()
        {
            try
            {
                var result = await _context.Commit();
                if (!result) AddProcessingError("Não foi possível realizar a operação");
            }
            catch (Exception ex)
            {
                AddProcessingError(ex.Message);
            }
        }
    }
}
