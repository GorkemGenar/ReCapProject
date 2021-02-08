using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarAddTest();

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} | {1} | {2} | {3}",car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }

            Console.ReadKey();
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            string CarName, Description;
            bool Cont;
            int CarId, BrandId, ColorId, ModelYear;
            decimal DailyPrice;

            for (; ; )
            {
                Console.Write("Arabanın Id'sini girin: ");
                CarId = int.Parse(Console.ReadLine());

                Console.Write("Arabanın BrandId'sini girin: ");
                BrandId = int.Parse(Console.ReadLine());

                Console.Write("Arabanın ColorId'sini girin: ");
                ColorId = int.Parse(Console.ReadLine());

                Console.Write("Arabanın Adını girin: ");
                CarName = Console.ReadLine();

                Console.Write("Arabanın model yılını girin: ");
                ModelYear = int.Parse(Console.ReadLine());

                Console.Write("Arabanın günlük fiyatı girin: ");
                DailyPrice = decimal.Parse(Console.ReadLine());

                Console.Write("Bir açıklama girin: ");
                Description = Console.ReadLine();

                Console.WriteLine("Eklemeye devam etmek istiyor musunuz ?");
                Cont = bool.Parse(Console.ReadLine());

                carManager.Add(new Car { CarId = CarId, BrandId = BrandId, CarName = CarName, ColorId = ColorId, DailyPrice = DailyPrice, Description = Description, ModelYear = ModelYear });

                if (Cont == false)
                {
                    break;
                }
            }
        }
    }
}
