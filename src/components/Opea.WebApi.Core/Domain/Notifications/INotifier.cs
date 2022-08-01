using System.Collections.Generic;

namespace Opea.WebAPI.Core.Domain.Notifications
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotification();
        string GetMessageNotification();
        void Handle(Notification notificacao);
    }
}