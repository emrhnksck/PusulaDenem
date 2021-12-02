using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfNufusRepository : EfEntityRepositoryBase<Nufus>, INufusRepository
    {
        public EfNufusRepository(DbContext context) : base(context)
        {
        }
    }
}
