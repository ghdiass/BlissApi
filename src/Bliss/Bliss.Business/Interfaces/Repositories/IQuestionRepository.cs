using Bliss.Business.Interfaces.Repositories.Shared;
using Bliss.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bliss.Business.Interfaces.Repositories
{
    public interface IQuestionRepository : IRepository<QuestionModel>
    {
        Task<List<QuestionModel>> Get(int limit, int offset, string filter);
    }
}
