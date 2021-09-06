using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FromBankCreditCard:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] CardNumberSalt { get; set; }
        public byte[] CardNumberHash { get; set; }
        public byte[] ExpirationDateSalt { get; set; }
        public byte[] ExpirationDateHash { get; set; }
        public byte[] CvvSalt { get; set; }
        public byte[] CvvHash { get; set; }
    }
}
