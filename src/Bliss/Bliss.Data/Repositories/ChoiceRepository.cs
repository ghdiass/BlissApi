using Bliss.Business.Interfaces.Repositories;
using Bliss.Business.Models;
using Bliss.Data.Context;
using Bliss.Data.Repositories.Shared;

namespace Bliss.Data.Repositories
{
    public class ChoiceRepository : Repository<ChoiceModel>, IChoiceRepository
    {
        public ChoiceRepository(BlissContext context) : base(context)
        {   }
    }
}
