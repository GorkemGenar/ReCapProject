using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISavedCreditCardService
    {
        IDataResult<List<SavedCreditCard>> GetAll();
        IDataResult<SavedCreditCard> GetById(int id);
        IDataResult<SavedCreditCard> Add(SavedCreditCard addCreditCardDto);
        IResult Update(SavedCreditCard payment);
        IResult Delete(SavedCreditCard payment);
        IDataResult<SavedCreditCard> CheckTheCreditCard(SavedCreditCard paymentDto);
        IDataResult<SavedCreditCard> GetByUser(int userId);
    }
}
