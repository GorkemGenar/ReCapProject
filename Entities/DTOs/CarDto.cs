using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDto : Car, IDto
    {
        public int CarImageId { get; set; }
        public List<CarImage> CarImage { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
    }
}
