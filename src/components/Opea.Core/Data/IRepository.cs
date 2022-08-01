using Opea.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Opea.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        void Add(T entity);
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        void Update(T entity);
        void Remove(T entity);
    }
}
