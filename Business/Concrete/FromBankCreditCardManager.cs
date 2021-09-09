using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;


namespace Business.Concrete
{
    class FromBankCreditCardManager : IFromBankCreditCardService
    {
        IFromBankCreditCardDal _creditCardDal;

        public FromBankCreditCardManager(IFromBankCreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IDataResult<FromBankCreditCard> Add(AddCreditCardDto addCreditCardDto, string cardNumber, string expirationDate, string cvv)
        {
            byte[] cardNumberHash, cardNumberSalt, expirationDateHash, expirationDateSalt, cvvHash, cvvSalt;

            HashingHelper.CreateCardNumberHash(cardNumber, out cardNumberHash, out cardNumberSalt);
            HashingHelper.CreateExpirationDateHash(expirationDate, out expirationDateHash, out expirationDateSalt);
            HashingHelper.CreateCvvHash(cvv, out cvvHash, out cvvSalt);

            var card = new FromBankCreditCard
            {
                Id = addCreditCardDto.Id,
                UserId = addCreditCardDto.UserId,
                CardNumberHash = cardNumberHash,
                CardNumberSalt = cardNumberSalt,
                CvvHash = cvvHash,
                CvvSalt = cvvSalt,
                ExpirationDateHash = expirationDateHash,
                ExpirationDateSalt = expirationDateSalt
            };
            _creditCardDal.Add(card);
            return new SuccessDataResult<FromBankCreditCard>(card, "Eklendi");
        }

        public IResult Delete(FromBankCreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        public IDataResult<List<FromBankCreditCard>> GetAll()
        {
            return new SuccessDataResult<List<FromBankCreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<FromBankCreditCard> GetById(int id)
        {
            return new SuccessDataResult<FromBankCreditCard>(_creditCardDal.Get(c => c.Id == id));
        }

        public IResult Update(FromBankCreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        public IDataResult<FromBankCreditCard> CheckTheCreditCard(PaymentDto paymentDto)
        {
            var getCardToCheck = _creditCardDal.GetByUser(paymentDto.UserId);

            if (getCardToCheck is null)
            {
                return new ErrorDataResult<FromBankCreditCard>("Sistemde kayıtlı böyle bir kart yok.");
            }

            var cardNumberStatus = HashingHelper.VerifyCardNumberHash(paymentDto.CardNumber, getCardToCheck.CardNumberHash, getCardToCheck.CardNumberSalt);
            var expirationDateStatus = HashingHelper.VerifyExpirationDateHash(paymentDto.ExpirationDate, getCardToCheck.ExpirationDateHash, getCardToCheck.ExpirationDateSalt);
            var cvvStatus = HashingHelper.VerifyCvvHash(paymentDto.Cvv, getCardToCheck.CvvHash, getCardToCheck.CvvSalt);

            if (!cardNumberStatus || !expirationDateStatus || !cvvStatus)
            {
                return new ErrorDataResult<FromBankCreditCard>("Kart bilgileri hatalı.");
            }

            return new SuccessDataResult<FromBankCreditCard>(getCardToCheck, "Ödeme işlemi başarılı.");
        }

        public IDataResult<FromBankCreditCard> CheckTheSavedCreditCard(CreditCardHashedDto paymentHashedDto)
        {
            var getCardToCheck = _creditCardDal.GetByUser(paymentHashedDto.UserId);
            
            if(getCardToCheck is null)
            {
                return new ErrorDataResult<FromBankCreditCard>("Kayıtlı olan kart bilgileri hatalı. Lütfen kart bilgilerinizi güncelleyin.");
            }

            var cardNumberStatus = HashingHelper.VerifySavedCardNumberHash(paymentHashedDto.CardNumberHash, getCardToCheck.CardNumberHash);
            var expirationDateStatus = HashingHelper.VerifySavedCardExpirationDateHash(paymentHashedDto.ExpirationDateHash, getCardToCheck.ExpirationDateHash);
            var cvvStatus = HashingHelper.VerifySavedCardCvvHash(paymentHashedDto.CvvHash, getCardToCheck.CvvHash);

            if (!cardNumberStatus || !expirationDateStatus || !cvvStatus)
            {
                return new ErrorDataResult<FromBankCreditCard>("Kayıtlı olan kart bilgileri hatalı. Lütfen kart bilgilerinizi güncelleyin.");
            }

            return new SuccessDataResult<FromBankCreditCard>(getCardToCheck, "Ödeme işlemi başarılı.");
        }

        public IDataResult<FromBankCreditCard> GetByUser(int userId)
        {
            return new SuccessDataResult<FromBankCreditCard>(_creditCardDal.GetByUser(userId));
        }
    }
}
