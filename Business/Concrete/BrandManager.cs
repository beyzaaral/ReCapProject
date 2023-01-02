using Business.Abstarct;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Conctere;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);

            return new Result(true, "Ürün Silindi");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.CarsListed);
        }


        public IDataResult<List<Brand>> GetById(int Id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == Id));
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _brandDal.Add(brand);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);

            return new Result(true, "Araç Güncellendi");
        }
    }
}
