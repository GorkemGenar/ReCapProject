using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSavedCreditCardDal : EfEntityRepositoryBase<SavedCreditCard, ReCapProjectContext>, ISavedCreditCardDal
    {
        public SavedCreditCard GetByUser(int userId)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from scc in context.SavedCreditCards
                             where scc.UserId == userId
                             select new SavedCreditCard
                             {
                                 Id = scc.Id,
                                 UserId = scc.UserId,
                                 CardNumberHash = scc.CardNumberHash,
                                 ExpirationDateHash = scc.ExpirationDateHash,
                                 CvvHash = scc.CvvHash
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
