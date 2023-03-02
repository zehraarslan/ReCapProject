using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new InMemoryCarDal());
            Console.WriteLine("GetAll");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Id + " - " + car.Description + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            }

            Console.WriteLine();
            Console.WriteLine("Add");
            carService.Add(new Entities.Concrete.Car() {
                Id = 7,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 5612300,
                ModelYear = new DateTime(2018, 1, 1),
                Description = "BMW 4 Serisi Gran Coupe"
            });
            Console.WriteLine("GetAll");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Id + " - " + car.Description + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            }

            Console.WriteLine();
            Console.WriteLine("Delete");
            carService.Delete(new Car() { Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 2883700, ModelYear = new DateTime(2020, 1, 1), Description = "BMW 3 serisi Station wagon" });
            Console.WriteLine("GetAll");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Id + " - " + car.Description + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            }


            Console.WriteLine();
            Console.WriteLine("Update");
            carService.Update(new Car() { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 2070108, ModelYear = new DateTime(2021, 1, 1), Description = "2021 Audi A4 Sedan. Bu arabayı kaçırma!!!!!!!!!!!" });
            Console.WriteLine("GetAll");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Id + " - " + car.Description + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            }


            Console.WriteLine();
            Console.WriteLine("GetById");
            Car carId = carService.GetById(5);
            Console.WriteLine(carId.Id + " - " + carId.Description + " - " + carId.ModelYear.Year + " - " + carId.DailyPrice);
        }

    }
}