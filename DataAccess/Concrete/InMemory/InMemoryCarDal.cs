using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{CarId=1, BrandId=1, ColorId=1234, DailyPrice=15000, Description="Description-1", ModelYear= 1965},
                new Car{CarId=2, BrandId=1, ColorId=1234, DailyPrice=15000, Description="Description-2", ModelYear= 1965},
                new Car{CarId=3, BrandId=2, ColorId=1234, DailyPrice=11200, Description="Description-3", ModelYear= 2000},
                new Car{CarId=4, BrandId=2, ColorId=1234, DailyPrice=11200, Description="Description-4", ModelYear= 2010},
                new Car{CarId=5, BrandId=3, ColorId=1234, DailyPrice=44000, Description="Description-5", ModelYear= 2020},
                new Car{CarId=6, BrandId=3, ColorId=1234, DailyPrice=44000, Description="Description-6", ModelYear= 2019},
                new Car{CarId=7, BrandId=4, ColorId=1234, DailyPrice=42000, Description="Description-7", ModelYear= 1989},
                new Car{CarId=8, BrandId=4, ColorId=1234, DailyPrice=42000, Description="Description-8", ModelYear= 1999},
                new Car{CarId=9, BrandId=5, ColorId=1234, DailyPrice=22000, Description="Description-9", ModelYear= 2005},
                new Car{CarId=10, BrandId=5, ColorId=1234, DailyPrice=22000, Description="Description-10", ModelYear= 2007},
            };

            _brands = new List<Brand>()
            {
                new Brand{BrandId=1, BrandName="Mustang"},
                new Brand{BrandId=2, BrandName="Mercedes"},
                new Brand{BrandId=3, BrandName="BMW"},
                new Brand{BrandId=4, BrandName="Renault"},
                new Brand{BrandId=5, BrandName="Lada"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.Where(i => i.CarId == car.CarId).SingleOrDefault();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void GetById(int carid)
        {
            _cars.Where(i => i.CarId == carid).FirstOrDefault();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.Where(i => i.CarId == car.CarId).FirstOrDefault();

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        //Any veri tabanında belirttilen isimde nesne varmı ona bakar. Bool sonuç döndürür
        public void AnyTest(int year)
        {
            var result = _cars.Any(i => i.ModelYear == year);
            if(result == true)
            {
                Console.WriteLine("Ürün var.");
            }
            else
            {
                Console.WriteLine("Ürün yok.");
            }
            
        }

        //Find: veri tabanındaki, belirtilen şarta uygun olan İLK ürünü döndürür. Nesne sonucu döndürür.
        public void FindTest(int year)
        {
            var result = _cars.Find(i => i.ModelYear == year);
            if (result != null)
            {
                Console.WriteLine(result.Description);
            }
            else
            {
                Console.WriteLine("Ürün yok.");
            }
        }

        //FindAll veri tabanındaki, belirtilen şarta uygun olan tüm ürünleri döndürür. Liste sonucu döndürür
        //OrderBy: Veri tabanından çekilen verilerde sıralama yapar.
        //OrderBy veya OrderByAscending: küçükten büyüğe, OrderByDescending: Büyükten küçüğe sıralama yapar.
        //ThenByDescending: Verilen ilk şartta aynı değere sahip ürünlerde, yeni şarta göre sıralama yapar.
        public void FindAllTest(string aciklama)
        {
            var result = _cars.FindAll(i => i.Description.Contains(aciklama)).OrderByDescending(j => j.Description).ThenByDescending(k => k.ModelYear);
            if (result != null)
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Description + " " + item.ModelYear + " ürünleri bulundu");
                }
            }
            else
            {
                Console.WriteLine("Ürün yok.");
            }
        }

        public void ClassicLinqTest()
        {
            var result = from c in _cars
                         where c.DailyPrice < 20000
                         orderby c.DailyPrice descending
                         select new CarDto { Description = c.Description, ModelYear = c.ModelYear };
        }

        public void JoinTest()
        {
            var result = from c in _cars join b in _brands
                         on c.BrandId equals b.BrandId
                         select new CarDto { BrandName = b.BrandName, Description = c.Description, ModelYear = c.ModelYear };

            foreach (var item in result)
            {
                Console.WriteLine("{0} {1} {2}",item.BrandName, item.Description, item.ModelYear);
            }
        }
    }
}