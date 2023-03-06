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
            IColorService colorService = new ColorManager(new EfColorDal());
            IBrandService brandService = new BrandManager(new EfBrandDal());
            //CarTest(carService);
            //ColorTest(colorService);
            //BrandTest(brandService);

            foreach (var carDto in carService.GetCarDetails().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", carDto.CarName, carDto.BrandName, carDto.ColorName, carDto.DailyPrice);
            }

        }

        private static void BrandTest(IBrandService brandService)
        {
            foreach (var brand in brandService.GetAll().Data)
            {
                Console.WriteLine("{0}   {1}", brand.Id, brand.Name);
            }
            //brandService.Add(new Brand() { Name = "Ford" });
            //brandService.Update(new Brand() { Id = 1002, Name = "Mercedes" });
            brandService.Delete(new Brand() { Id = 1002, Name = "Mercedes" });
            foreach (var brand in brandService.GetAll().Data)
            {
                Console.WriteLine("{0}   {1}", brand.Id, brand.Name);
            }
        }

        private static void ColorTest(IColorService colorService)
        {
            foreach (var color in colorService.GetAll().Data)
            {
                Console.WriteLine(color.Id + "  " + color.Name);
            }


            //colorService.Add(new Color() { Name = "Kırmızı" });
            //colorService.Update(new Color() { Id = 1002, Name = "Mavi" });
            colorService.Delete(new Color() { Id = 1002, Name = "Mavi" });
            foreach (var color in colorService.GetAll().Data)
            {
                Console.WriteLine(color.Id + "  " + color.Name);
            }
        }

        private static void CarTest(ICarService carService)
        {
            Console.WriteLine("GetAll");
            foreach (var car in carService.GetCarsByColordId(2).Data)
            {
                Console.WriteLine(car.Id + " - " + car.Description + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            }

            Console.WriteLine();
            Console.WriteLine("Add");
            //carService.Add(new Car()
            //{
            //    BrandId = 2,
            //    ColorId = 2,
            //    Name = "Range Rover",
            //    DailyPrice = 12068195,
            //    ModelYear = new DateTime(2019, 1, 1),
            //    Description = "Land Rover Range Rover Seri - 5"
            //});
            //Console.WriteLine("GetAll");
            //foreach (var car in carService.GetAll())
            //{
            //    Console.WriteLine(car.Id + " - " + car.Name + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            //}

            Console.WriteLine();
            Console.WriteLine("Delete");
            //carService.Delete(new Car()
            //{
            //    Id = 1005,
            //    BrandId = 2,
            //    ColorId = 2,
            //    Name = "Range Rover",
            //    DailyPrice = 12068195,
            //    ModelYear = new DateTime(2019, 1, 1),
            //    Description = "Land Rover Range Rover Seri - 5"
            //}); 
            //Console.WriteLine("GetAll");
            //foreach (var car in carService.GetAll())
            //{
            //    Console.WriteLine(car.Id + " - " + car.Description + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            //}


            Console.WriteLine();
            Console.WriteLine("Update");
            carService.Update(new Car() { Id = 1, BrandId = 1, ColorId = 1, Name = "2021 Audi A4 Sedan", DailyPrice = 2070108, ModelYear = new DateTime(2021, 1, 1), Description = "2023 Audi A4 Sedan. Bu arabayı kaçırma!!!!!!!!!!!" });
            Console.WriteLine("GetAll");
            foreach (var car in carService.GetAll().Data)
            {
                Console.WriteLine(car.Id + " - " + car.Description + " - " + car.ModelYear.Year + " - " + car.DailyPrice);
            }

            Console.WriteLine();
            Console.WriteLine("GetById");
            var result = carService.GetById(1);
            Console.WriteLine(result.Data.Id + " - " + result.Data.Description + " - " + result.Data.ModelYear.Year + " - " + result.Data.DailyPrice);
        }
    }
}