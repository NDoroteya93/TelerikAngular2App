namespace TelerikAngular2.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using TelerikAngular2.Data.Common.Models;

    // TODO: Why BaseModel<int> instead BaseModel<TKey>?
    public class DbRepository<T> : IDbRepository<T>
        where T : BaseModel<Guid>
    {
        public DbRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        private IDbSet<T> DbSet { get; }

        private DbContext Context { get; }

        public IQueryable<T> All()
        {
            return this.DbSet.Where(x => !x.IsDeleted);
        }
        public async Task<List<T>> AllAsync()
        {
            return await this.DbSet.Where(x => !x.IsDeleted).ToListAsync();
        }


        public IQueryable<T> AllWithDeleted()
        {
            return this.DbSet;
        }

        public T GetById(Guid id)
        {
            return this.All().FirstOrDefault(x => x.Id == id);
        }

        public Guid Add(T entity)
        {
            //entity.Id = Guid.NewGuid();
            this.DbSet.Add(entity);
            return entity.Id;
        }

        public void Update(T entity)
        {
            this.Context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Attach(T entity)
        {
            this.DbSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
        }

        public void HardDelete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}
