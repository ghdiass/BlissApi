using Bliss.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bliss.Business.Interfaces.Services
{
    public interface IQuestionService
    {
        Task<List<QuestionModel>> Get(int limit, int offset, string filter);
    }
}
