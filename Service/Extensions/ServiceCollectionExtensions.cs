using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<PusulaContext>();
            serviceCollection.AddScoped<INufusService, NufusManager>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            return serviceCollection;
        }
    }
}
