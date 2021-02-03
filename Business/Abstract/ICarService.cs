﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        void GetById(int carid);
        void AnyTest(int year);
        void FindTest(int year);
        void FindAllTest(string aciklama);
        void ClassicLinqTest();
        void JoinTest();
    }
}