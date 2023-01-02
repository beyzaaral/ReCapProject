using Core.DataAccess;
using Entities.Conctere;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
      //IEntityRepository'i yi Car için yapılandırdın (interit) demek.
      //ürüne ait özel operasyonlar konulacak.
      List<CarDetailDto> GetCarDetails();

    }
}
