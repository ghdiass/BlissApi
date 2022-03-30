using Bliss.Business.Interfaces.Repositories;
using Bliss.Business.Models;
using Bliss.Data.Context;
using Bliss.Data.Repositories.Shared;

namespace Bliss.Data.Repositories
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        public EmailRepository(BlissContext context) : base(context)
        {   }
    }
}
