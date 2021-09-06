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
        IDataResult<SavedCreditCard> Add(AddCreditCardDto addCreditCardDto, string cardNumber, string expirationDate, string cvv);
        IResult Update(SavedCreditCard payment);
        IResult Delete(SavedCreditCard payment);
        IDataResult<SavedCreditCard> CheckTheCreditCard(PaymentDto paymentDto);
        IDataResult<SavedCreditCard> GetByUser(int userId);
    }
}
