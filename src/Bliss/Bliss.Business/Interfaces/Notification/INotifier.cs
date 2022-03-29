using System.Collections.Generic;

namespace Bliss.Business.Interfaces.Notification
{
    public interface INotifier
    {
        void Handle(Business.Notification.Notification notificacao);
        List<Business.Notification.Notification> Get();
        bool HasNotification();
    }
}
