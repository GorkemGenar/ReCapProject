using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDto> GetCarDetails(Expression<Func<CarDto, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join clr in context.Colors on c.ColorId equals clr.ColorId

                             select new CarDto
                             {
                                 CarId = c.CarId,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 CarImage = (from i in context.CarImages
                                             where (c.CarId == i.CarId)
                                             select new CarImage { Id = i.Id, CarId = c.CarId, Date = i.Date, ImagePath = i.ImagePath }).ToList()
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
