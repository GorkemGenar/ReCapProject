using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ISavedCreditCardDal:IEntityRepository<SavedCreditCard>
    {
        SavedCreditCard GetByUser(int userId);
    }
}
