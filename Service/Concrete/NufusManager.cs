using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.ComplexTypes;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class NufusManager : INufusService
    {
        private readonly IUnitOfWork unitOfWork;

        public NufusManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(Nufus nufus)
        {
            await unitOfWork.Nufuslar.AddAsync(nufus).ContinueWith(t => unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{nufus.Name} isimli kişi başarıyla eklendi");
        }

        public async Task<IResult> Delete(int NufusId)
        {
            var result = await unitOfWork.Nufuslar.AnyAsync(n => n.Id == NufusId);
            if (result)
            {
                var nufus = await unitOfWork.Nufuslar.GetAsync(n => n.Id == NufusId);
                await unitOfWork.Nufuslar.DeleteAsync(nufus);
                return new Result(ResultStatus.Success, $"{nufus.Name} isimli kişi başarıyla silindi");
            }
            return new Result(ResultStatus.Error, "Böyle bir kişi bulunamadı");
        }

        public async Task<IDataResult<Nufus>> Get(int NufusId)
        {
            var nufus = await unitOfWork.Nufuslar.GetAsync(n => n.Id == NufusId);
            if(nufus != null)
            {
                return new DataResult<Nufus>(ResultStatus.Success, nufus);
            }
            return new DataResult<Nufus>(ResultStatus.Error, "Böyle bir nufus bulunamadı",null);
        }

        public async Task<IDataResult<IList<Nufus>>> GetAll()
        {
            var nufuslar = await unitOfWork.Nufuslar.GetAllAsync();
            if (nufuslar != null)
            {
                return new DataResult<IList<Nufus>>(ResultStatus.Success,nufuslar);
            }
            return new DataResult<IList<Nufus>>(ResultStatus.Error, "Hiç nufus yok",null);
        }

        public async Task<IResult> Update(Nufus nufus)
        {
            await unitOfWork.Nufuslar.UpdateAsync(nufus);
            return new Result(ResultStatus.Success, $"{nufus.Name} isimli nufus başarıyla güncellendi");
        }
    }
}
