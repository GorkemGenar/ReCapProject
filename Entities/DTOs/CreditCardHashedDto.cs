using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CreditCardHashedDto: IDto
    {
        public int UserId { get; set; }
        public byte[] CardNumberHash { get; set; }
        public byte[] ExpirationDateHash { get; set; }
        public byte[] CvvHash { get; set; }
    }
}
