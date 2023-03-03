using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new EfCarDal());
            Console.WriteLine("GetAll");
            foreach (var car in carService.GetCarsByColordId(2))
            {
                Console.WriteLine(car.Id + " - " + car.Description + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            }

            //Console.WriteLine();
            //Console.WriteLine("Add");
            carService.Add(new Car()
            {
                BrandId = 2,
                ColorId = 2,
                Name = "Range Rover",
                DailyPrice = 12068195,
                ModelYear = new DateTime(2019, 1, 1),
                Description = "Land Rover Range Rover"
            });
            Console.WriteLine("GetAll");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Id + " - " + car.Name + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            }

            //Console.WriteLine();
            //Console.WriteLine("Delete");
            //carService.Delete(new Car() { Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 2883700, ModelYear = new DateTime(2020, 1, 1), Description = "BMW 3 serisi Station wagon" });
            //Console.WriteLine("GetAll");
            //foreach (var car in carService.GetAll())
            //{
            //    Console.WriteLine(car.Id + " - " + car.Description + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            //}


            //Console.WriteLine();
            //Console.WriteLine("Update");
            //carService.Update(new Car() { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 2070108, ModelYear = new DateTime(2021, 1, 1), Description = "2021 Audi A4 Sedan. Bu arabayı kaçırma!!!!!!!!!!!" });
            //Console.WriteLine("GetAll");
            //foreach (var car in carService.GetAll())
            //{
            //    Console.WriteLine(car.Id + " - " + car.Description + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            //}
        }

    }
}