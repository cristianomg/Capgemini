using System;
using System.Threading.Tasks;

namespace Com.Capgemini.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}
