using System.Collections.Generic;
using System.Linq;

namespace Opea.WebAPI.Core.Domain.Notifications
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }


        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotification()
        {
            return _notifications;
        }

        public string GetMessageNotification()
        {
            var message = "";
            foreach (var item in _notifications)
                message += string.Format("- {0}", item.Message);

            return message;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}