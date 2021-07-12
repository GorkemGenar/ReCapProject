using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<CreditCard> GetById(int id);
        IDataResult<CreditCard> Add(AddCreditCardDto addCreditCardDto, string cardNumber, string expirationDate, string cvv);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
    }
}
