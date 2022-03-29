using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bliss.Business.Interfaces.Repositories.Shared;
using Bliss.Business.Models.Shared;
using Bliss.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bliss.Data.Repositories.Shared
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly BlissContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(BlissContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate) =>
            await DbSet.AsNoTracking().Where(predicate).ToListAsync();

        public virtual async Task<TEntity> GetById(int id)=>
            await DbSet.FindAsync(id);

        public virtual async Task<List<TEntity>> GetAll() =>
            await DbSet.ToListAsync();

        public virtual async Task Insert(TEntity entity, bool saveChanges = true)
        {
            DbSet.Add(entity);
            if(saveChanges)
                await SaveChanges();
        }

        public virtual async Task Update(TEntity entity, bool saveChanges = true)
        {
            DbSet.Update(entity);
            if (saveChanges)
                await SaveChanges();
        }

        public virtual async Task Delete(int id, bool saveChanges = true)
        {
            DbSet.Remove(new TEntity { Id = id });
            if (saveChanges)
                await SaveChanges();
        }

        public async Task<int> SaveChanges() =>
            await Db.SaveChangesAsync();

        public void Dispose() =>
            Db?.Dispose();
    }
}