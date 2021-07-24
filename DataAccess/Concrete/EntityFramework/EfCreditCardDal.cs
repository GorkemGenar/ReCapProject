using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, ReCapProjectContext>, ICreditCardDal
    {
        public CreditCard GetByUser(int userId)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from u in context.Users
                             join c in context.CreditCards
                             on u.Id equals c.UserId
                             where c.Id == userId
                             select new CreditCard
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

