namespace TelerikAngular2.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TelerikAngular2.Data.Common.Models;

    public interface IDbRepository<T> : IDbRepository<T, Guid>
        where T : BaseModel<Guid>
    {
    }

    public interface IDbRepository<T, in TKey>
        where T : BaseModel<TKey>
    {
        IQueryable<T> All();

        Task<List<T>> AllAsync();

        IQueryable<T> AllWithDeleted();

        T GetById(Guid id);

        Guid Add(T entity);

        void Update(T entity);

        void Attach(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}
