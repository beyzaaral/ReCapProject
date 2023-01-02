using Core.Utilities.Results;
using Entities.Conctere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetById(int Id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
