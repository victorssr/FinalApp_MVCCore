using System.Collections.Generic;

namespace VSDev.Business.Notifications
{
    public interface INotificator
    {
        bool TemNotificacao();
        List<Notification> ObterNotificacoes();
        void Handle(Notification notification);
    }
}
