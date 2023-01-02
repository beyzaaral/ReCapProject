using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Conctere.EntityFramework;
using DataAccess.Conctere.InMemory;
using Entities.Conctere;
using System;
using System.Drawing;
using System.Runtime.ConstrainedExecution;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //ColorTest();
            //CarTest();
            CustomerTest();
        }


        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetAll();

            if (result.Success == true)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.CompanyName + "/" + customer.UserId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();

            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName + "/" + color.ColorId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }


        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }


    }
}

