using Bliss.Business.Dtos;
using Bliss.Business.Interfaces.Comunication;
using Bliss.Business.Interfaces.Notification;
using Bliss.Business.Interfaces.Repositories;
using Bliss.Business.Interfaces.Services;
using Bliss.Business.Models;
using Bliss.Business.Services.Shared;
using Bliss.Business.Validations;
using System.IO;
using System.Threading.Tasks;

namespace Bliss.Business.Services
{
    public class ShareScreenService : BaseService, IShareScreenService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly ISenderEmailService _senderEmailService;

        public ShareScreenService(IEmailRepository emailRepository,
                                  ISenderEmailService senderEmailService,
                                  INotifier notifier) : base(notifier)
        {
            _senderEmailService = senderEmailService;
            _emailRepository = emailRepository;
        }

        public async Task Share(ShareScreenDto shareScreen)
        {
            if (!ExecuteValidation(new ShareScreenValidation(), shareScreen)) 
                return;
            
            var emailBody = "";
            using (var sr = new StreamReader("EmailTemplate/ShareScreenTemplate.html"))
                emailBody = sr.ReadToEnd();

            emailBody = emailBody.Replace("{URL}", shareScreen.Url);

            var email = new Email("Shared Screen", shareScreen.Email, emailBody);

            email = await _senderEmailService.Send(email);

            await _emailRepository.Insert(email);
        }
    }
}