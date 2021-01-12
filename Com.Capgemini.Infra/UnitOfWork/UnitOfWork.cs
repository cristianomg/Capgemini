using Com.Capgemini.Domain.Interfaces.UnitOfWork;
using Com.Capgemini.Infra.Context;
using System;
using System.Threading.Tasks;

namespace Com.Capgemini.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CapgeminiContext _context;
        public UnitOfWork(CapgeminiContext context)
        {
            _context = context;
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
