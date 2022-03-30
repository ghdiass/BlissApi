using Bliss.Business.Models;
using System.Threading.Tasks;

namespace Bliss.Business.Interfaces.Comunication
{
    public interface ISenderEmailService
    {
        Task<Email> Send(Email email);
    }
}
