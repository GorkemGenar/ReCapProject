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
                var result = from u in context.Users
                             join c in context.FromBankCreditCards
                             on u.Id equals c.UserId
                             where c.Id == userId
                             select new FromBankCreditCard
                             {
                                 UserId = u.Id,
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

