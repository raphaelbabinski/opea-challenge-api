using Microsoft.AspNetCore.Mvc;
using Opea.Registration.BFF.Models.Client;
using Opea.Registration.BFF.Services.Client.Interface;
using Opea.WebAPI.Core.Controllers;
using Opea.WebAPI.Core.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace Opea.Registration.BFF.Controllers.Client
{
    [Route("client")]
    public class ClientController : MainController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService, INotifier notifier) : base(notifier)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ClientDTO model)
        {
            return CustomResponse(await _clientService.Add(model));
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ClientDTO model)
        {
            return CustomResponse(await _clientService.Update(model));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            return CustomResponse(await _clientService.Remove(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await _clientService.GetAll();
            if (model is null)
            {
                AddProcessingError("Cliente não encontrado!");
                return CustomResponse();
            }

            return CustomResponse(model);
        }

        [HttpGet("sql")]
        public async Task<IActionResult> GetAllFromSql()
        {
            var model = await _clientService.GetAllFromSql();
            if (model is null)
            {
                AddProcessingError("Cliente não encontrado!");
                return CustomResponse();
            }

            return CustomResponse(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var model = await _clientService.GetById(Id);
            if (model is null)
            {
                AddProcessingError("Cliente não encontrado!");
                return CustomResponse();
            }

            return CustomResponse(model);
        }
    }
}