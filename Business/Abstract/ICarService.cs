using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAllByColorId(int id);
        List<Car> GetAllByBrandId(int id);

        //void AnyTest(int year);
        //void FindTest(int year);
        //void FindAllTest(string aciklama);
        //void ClassicLinqTest();
        //void JoinTest();
    }
}
