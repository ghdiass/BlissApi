using Bliss.Business.Interfaces.Comunication;
using Bliss.Business.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Business.Comunication
{
    public class SenderEmailService : ISenderEmailService
    {
        private string _encoding;
        private string _from;
        private string _name;
        private string _host;
        private int _port;
        private string _password;

        public SenderEmailService(IConfiguration configuration)
        {
            _encoding = configuration.GetSection("Email:Encoding").Value;
            _from = configuration.GetSection("Email:From").Value;
            _name = configuration.GetSection("Email:Name").Value;
            _host = configuration.GetSection("Email:Host").Value;
            _port = int.Parse(configuration.GetSection("Email:Port").Value);
            _password = configuration.GetSection("Email:Password").Value;
        }

        public async Task<Email> Send(Email email)
        {
            try
            {
                var sender = new MailAddress(_from, _name);
                var recipient = new MailAddress(email.To);

                var message = new MailMessage(sender, recipient)
                {
                    Priority = MailPriority.Normal,
                    Subject = email.Subject,
                    SubjectEncoding = Encoding.GetEncoding(_encoding),
                    Body = email.Body,
                    BodyEncoding = Encoding.GetEncoding(_encoding),
                    IsBodyHtml = true
                };

                using (var smtpClient = new SmtpClient(_host, _port))
                {
                    smtpClient.Credentials = new NetworkCredential(_from, _password);
                    smtpClient.EnableSsl = true;

                    await smtpClient.SendMailAsync(message);
                }

                email.SendSuccess();
            }
            catch (Exception ex)
            {
                email.ErrorInSending(ex.Message);
            }

            return email;
        }
    }
}