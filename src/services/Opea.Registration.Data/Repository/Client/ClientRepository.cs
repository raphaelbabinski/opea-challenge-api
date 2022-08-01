using Microsoft.EntityFrameworkCore;
using Opea.Core.Data;
using Opea.Registration.Business.Domain.Client.Interface;
using Opea.Registration.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opea.Registration.Data.Repository.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly ServicesContext _context;

        public ClientRepository(ServicesContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Business.Domain.Client.Client entity)
        {
            _context.Clients.Add(entity);
        }

        public async Task<List<Business.Domain.Client.Client>> GetAll()
        {
            return await _context.Clients.AsNoTracking().Include(i => i.CompanySize).OrderBy(i => i.Name).ToListAsync();
        }

        public async Task<List<Business.Domain.Client.Client>> GetAllFromSql()
        {
            return await _context.Clients.FromSqlRaw("select * from Clients").ToListAsync();
        }

        public async Task<Business.Domain.Client.Client> GetById(Guid id)
        {
            return await _context.Clients.AsNoTracking().FirstOrDefaultAsync(i => i.Identifier == id);
        }

        public void Remove(Business.Domain.Client.Client entity)
        {
            _context.Remove(entity);
        }


        public void Update(Business.Domain.Client.Client entity)
        {
            _context.Clients.Update(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
