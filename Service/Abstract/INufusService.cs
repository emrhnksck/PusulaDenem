using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface INufusService
    {
        Task<IDataResult<IList<Nufus>>> GetAll();
        Task<IDataResult<Nufus>> Get(int NufusId);
        Task<IResult> Add(Nufus nufus);
        Task<IResult> Update(Nufus nufus);
        Task<IResult> Delete(int NufusId);

    }
}
