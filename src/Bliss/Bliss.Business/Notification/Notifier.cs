using Bliss.Business.Interfaces.Notification;
using System.Collections.Generic;
using System.Linq;

namespace Bliss.Business.Notification
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notificacao) =>
            _notifications.Add(notificacao);

        public List<Notification> Get() => 
            _notifications;

        public bool HasNotification() =>
            _notifications.Any();
    }
}