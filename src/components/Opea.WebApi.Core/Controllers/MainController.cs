using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Opea.Core.Communication;
using Opea.WebAPI.Core.Domain.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace Opea.WebAPI.Core.Controllers
{
    public abstract class MainController : Controller
    {
        private readonly INotifier _notifier;

        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        public bool ValidOperationService()
        {
            return !_notifier.HasNotification();
        }

        protected void Notifier(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation() && ValidOperationService())
            {
                return Ok(result);
            }

            if (!ValidOperationService())
            {
                foreach (var erro in _notifier.GetNotification())
                    AddProcessingError(erro.Message);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AddProcessingError(erro.ErrorMessage);
            }

            if (!ValidOperationService())
            {
                foreach (var erro in _notifier.GetNotification())
                    AddProcessingError(erro.Message);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddProcessingError(erro.ErrorMessage);
            }

            if (!ValidOperationService())
            {
                foreach (var erro in _notifier.GetNotification())
                    AddProcessingError(erro.Message);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult answer)
        {
            var isError = ResponseHasErrors(answer);

            if (isError)
                return CustomResponse();
            else
            {
                answer.Status = 200;
                return CustomResponse((object)answer);
            }
        }

        protected bool ResponseHasErrors(ResponseResult answer)
        {
            if (answer == null || !answer.Errors.Messages.Any()) return false;

            foreach (var mensagem in answer.Errors.Messages)
            {
                AddProcessingError(mensagem);
            }

            return true;
        }

        protected string ResponseErrors(ResponseResult response)
        {
            if (response != null && response.Errors.Messages.Any())
                foreach (var message in response.Errors.Messages) return message;

            return "";
        }

        protected bool ValidOperation()
        {
            return !Errors.Any();
        }

        protected void AddProcessingError(string error)
        {
            Errors.Add(error);
        }

        protected void ClearErrorProcessing()
        {
            Errors.Clear();
        }
    }
}