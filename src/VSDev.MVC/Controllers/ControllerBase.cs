using Microsoft.AspNetCore.Mvc;
using VSDev.Business.Notifications;

namespace VSDev.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly INotificator _notificator;

        protected ControllerBase(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool OperacaoValida()
        {
            return !_notificator.TemNotificacao();
        }
    }
}
