using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bliss.Business.Models.Shared;

namespace Bliss.Business.Interfaces.Repositories.Shared
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Insert(TEntity entity, bool saveChanges = true);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity, bool saveChanges = true);
        Task Delete(int id, bool saveChanges = true);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}