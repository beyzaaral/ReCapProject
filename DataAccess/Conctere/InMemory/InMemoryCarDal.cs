using DataAccess.Abstract;
using Entities.Conctere;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conctere.InMemory
{
        public class InMemoryCarDal : ICarDal
        {
        List<Car> _cars; 

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id=1, BrandId=1, ColorId=1, DailyPrice=300, Description="Günlük Kiralama", ModelYear= 2022 },
                new Car { Id=2, BrandId=1, ColorId=2, DailyPrice=6000, Description="Haftalık Kiralama", ModelYear= 2015 },
                new Car { Id=3, BrandId=3, ColorId=3, DailyPrice=8500, Description="Günlük Kiralama", ModelYear= 2020 },
                new Car { Id=4, BrandId=2, ColorId=4, DailyPrice=100, Description="Günlük Kiralama", ModelYear= 1970 },
                new Car { Id=5, BrandId=4, ColorId=5, DailyPrice=10000, Description="Haftalık Kiralama", ModelYear= 2000 }
            };
        }
      
        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;
            CarToUpdate.ModelYear = car.ModelYear;
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.FirstOrDefault(c => c.Id == car.Id);
            _cars.Remove(CarToDelete);
        }

        public List<Car> GetById(int CarId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
