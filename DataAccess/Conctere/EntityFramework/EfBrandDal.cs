using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Conctere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conctere.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapProjectContext>, IBrandDal
    {
    }
}
