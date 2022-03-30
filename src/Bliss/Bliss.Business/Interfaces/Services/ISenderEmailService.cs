using Bliss.Business.Dtos;
using System.Threading.Tasks;

namespace Bliss.Business.Interfaces.Services
{
    public interface IShareScreenService
    {
        Task Share(ShareScreenDto shareScreen);
    }
}
