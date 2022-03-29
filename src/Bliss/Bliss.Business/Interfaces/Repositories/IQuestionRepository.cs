using Bliss.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bliss.Business.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<List<QuestionModel>> Get(int limit, int offset, string filter);
    }
}
