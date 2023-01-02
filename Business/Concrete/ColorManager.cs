using Business.Abstarct;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Conctere.EntityFramework;
using Entities.Conctere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {

        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);

            return new Result(true, "Ürün Silindi");
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.CarsListed);
        }


        public IDataResult<List<Color>> GetById(int Id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(cl => cl.ColorId == Id));
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _colorDal.Add(color);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);

            return new Result(true, "Araç Güncellendi");
        }
    }
}
