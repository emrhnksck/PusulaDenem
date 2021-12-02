using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PusulaContext context;
        private EfNufusRepository nufusRepository;

        public UnitOfWork(PusulaContext context)
        {
            this.context = context;
        }

        public INufusRepository Nufuslar => nufusRepository ?? new EfNufusRepository(context);

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
