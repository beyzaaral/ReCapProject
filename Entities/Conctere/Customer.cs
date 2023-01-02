using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Conctere
{  
    public class Customer : IEntity
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }


        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}   
