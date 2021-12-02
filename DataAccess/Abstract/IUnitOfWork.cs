using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        INufusRepository Nufuslar { get; }
        Task<int> SaveAsync();
    }
}
