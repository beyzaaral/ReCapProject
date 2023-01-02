using Business.Abstarct;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Conctere.EntityFramework;
using Entities.Conctere;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CustomerName.Length < 2)
            {
                return new ErrorResult(Messages.CustomerNameInvalid);
            }
            _customerDal.Add(customer);

            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);

            return new Result(true, "Ürün Silindi");
        }

        public IDataResult<List<Customer>> GetAll()
        {

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CompanyNameListed);
        }

        public IDataResult<List<Customer>> GetById(int Id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(cl => cl.CustomerId == Id));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);

            return new Result(true, "Müşteri Güncellendi");
        }
    }
}
