using Bliss.Business.Interfaces.Repositories;
using Bliss.Business.Models;
using Bliss.Data.Context;
using Bliss.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bliss.Data.Repositories
{
    public class QuestionRepository : Repository<QuestionModel>, IQuestionRepository
    {
        public QuestionRepository(BlissContext context) : base(context)
        {   }

        public async Task<List<QuestionModel>> Get(int limit, int offset, string filter) =>
             await Db.Questions
                .AsNoTracking()
                .Include(f => f.Choices)
                .Where(x => string.IsNullOrEmpty(filter)
                            || x.Question.ToLower().Contains(filter)
                            || x.Choices.Any(y => y.Choice.ToLower().Contains(filter)))
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

        public override async Task<QuestionModel> GetById(int id) =>
            await Db.Questions
                .Include(f => f.Choices)
                .FirstOrDefaultAsync(x => x.Id == id);
    }
}
