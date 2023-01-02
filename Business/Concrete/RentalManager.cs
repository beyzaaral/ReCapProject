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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.Id == rental.CardId && r.ReturnDate == null).Any();
            if (result == true)
            {
                return new ErrorResult(Messages.NotDeliveredRental);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.DeliveredRental);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeletedRental);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.AllRentalListed);
        }

        public IDataResult<List<Rental>> GetById(int Id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CardId == Id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new Result(true, "Kiralama Güncellendi");
        }
    }
}
