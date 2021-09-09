using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFromBankCreditCardService
    {
        IDataResult<List<FromBankCreditCard>> GetAll();
        IDataResult<FromBankCreditCard> GetById(int id);
        IDataResult<FromBankCreditCard> Add(AddCreditCardDto addCreditCardDto, string cardNumber, string expirationDate, string cvv);
        IResult Update(FromBankCreditCard creditCard);
        IResult Delete(FromBankCreditCard creditCard);
        IDataResult<FromBankCreditCard> CheckTheCreditCard(PaymentDto paymentDto);
        IDataResult<FromBankCreditCard> CheckTheSavedCreditCard(CreditCardHashedDto paymentHashedDto);
        IDataResult<FromBankCreditCard> GetByUser(int userId);
    }
}
