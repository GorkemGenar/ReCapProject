using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFromBankCreditCardDal : EfEntityRepositoryBase<FromBankCreditCard, ReCapProjectContext>, IFromBankCreditCardDal
    {
        public FromBankCreditCard GetByUser(int userId)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from c in context.FromBankCreditCards
                             where c.UserId == userId
                             select new FromBankCreditCard
                             {
                                 UserId = c.UserId,
                                 CardNumberHash = c.CardNumberHash,
                                 CardNumberSalt = c.CardNumberSalt,
                                 ExpirationDateHash = c.ExpirationDateHash,
                                 ExpirationDateSalt = c.ExpirationDateSalt,
                                 CvvHash = c.CvvHash,
                                 CvvSalt = c.CvvSalt
                             };
                return result.FirstOrDefault();
            }
        }
    }
}

