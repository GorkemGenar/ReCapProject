using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("-----------------------------------------------------------");

            int year;
            Console.Write("Model Yılını Giriniz: ");
            year = int.Parse(Console.ReadLine());
            carManager.AnyTest(year);
            Console.WriteLine("-----------------------------------------------------------");
            carManager.FindTest(year);

            Console.WriteLine("-----------------------------------------------------------");

            string aciklama;
            Console.Write("Açıklama Giriniz: ");
            aciklama = Console.ReadLine();
            carManager.FindAllTest(aciklama);

            Console.WriteLine("-----------------------------------------------------------");

            carManager.JoinTest();

            Console.Read();
        }
    }
}
