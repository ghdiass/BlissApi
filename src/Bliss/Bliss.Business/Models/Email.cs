using Bliss.Business.Models.Shared;
using System;

namespace Bliss.Business.Models
{
    public class Email : Entity
    {
        public Email()
        {   }

        public Email(string subject, string to, string body)
        {
            Subject = subject;
            To = to;
            Body = body;
        }

        public string Subject { get; private set; }
        public string To { get; private set; }
        public string Body { get; private set; }
        public bool Send { get; private set; }
        public string Error { get; private set; }
        public DateTime? Send_At { get; private set; }

        public void ErrorInSending(string erro)
        {
            Error = erro;
            Send = false;
        }

        public void SendSuccess()
        {
            Send_At = DateTime.Now;
            Send = true;
        }
    }
}
