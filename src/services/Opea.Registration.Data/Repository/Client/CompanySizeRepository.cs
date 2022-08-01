using Microsoft.EntityFrameworkCore;
using Opea.Core.Data;
using Opea.Registration.Business.Domain.Client;
using Opea.Registration.Business.Domain.Client.Interface;
using Opea.Registration.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opea.Registration.Data.Repository
{
    public class CompanySizeRepository : ICompanySizeRepository
    {
        private readonly ServicesContext _context;

        public CompanySizeRepository(ServicesContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(CompanySize entity)
        {
            _context.CompanySizes.Add(entity);
        }

        public async Task<List<CompanySize>> GetAll()
        {
            return await _context.CompanySizes.AsNoTracking().OrderBy(i => i.Name).ToListAsync();
        }

        public async Task<CompanySize> GetById(Guid id)
        {
            return await _context.CompanySizes.AsNoTracking().FirstOrDefaultAsync(i => i.Identifier == id);
        }

        public void Remove(CompanySize entity)
        {
            _context.Remove(entity);
        }


        public void Update(CompanySize entity)
        {
            _context.CompanySizes.Update(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
