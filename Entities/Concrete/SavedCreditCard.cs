﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class SavedCreditCard:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] CardNumberHash { get; set; }
        public byte[] ExpirationDateHash { get; set; }
        public byte[] CvvHash { get; set; }
    }
}
