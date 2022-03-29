using Bliss.Business.Models;
using System.Threading.Tasks;

namespace Bliss.Business.Interfaces.Services
{
    public interface IQuestionService
    {
        Task<QuestionModel> Insert(QuestionModel question);
    }
}
