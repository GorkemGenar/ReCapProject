using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class SavedCreditCardManager : ISavedCreditCardService
    {
        ISavedCreditCardDal _savedCreditCardDal;

        public SavedCreditCardManager(ISavedCreditCardDal savedCreditCreditCardDal)
        {
            _savedCreditCardDal = savedCreditCreditCardDal;
        }

        public IDataResult<SavedCreditCard> Add(SavedCreditCard addCreditCardDto)
        {
            _savedCreditCardDal.Add(addCreditCardDto);
            return new SuccessDataResult<SavedCreditCard>(addCreditCardDto, "Eklendi");
        }

        public IDataResult<SavedCreditCard> CheckTheCreditCard(SavedCreditCard savedCreditCard)
        {
            var getCardToCheck = _savedCreditCardDal.GetByUser(savedCreditCard.UserId);

            if (getCardToCheck == null)
            {
                return new ErrorDataResult<SavedCreditCard>(getCardToCheck, Messages.NoCardForUser);
            }
            
            //    var cardNumberStatus = HashingHelper.VerifyCardNumberHash(paymentDto.CardNumber, getCardToCheck.CardNumberHash, getCardToCheck.CardNumberSalt);
            //    var expirationDateStatus = HashingHelper.VerifyExpirationDateHash(paymentDto.ExpirationDate, getCardToCheck.ExpirationDateHash, getCardToCheck.ExpirationDateSalt);
            //    var cvvStatus = HashingHelper.VerifyCvvHash(paymentDto.Cvv, getCardToCheck.CvvHash, getCardToCheck.CvvSalt);

            //    if (!cardNumberStatus || !expirationDateStatus || !cvvStatus)
            //    {
            //        return new ErrorDataResult<SavedCreditCard>(getCardToCheck, Messages.NoCardInSystem);
            //    }

            else
            {
                //Sequence.Equal => dizi elemanlarının içeriklerinin aynı olup olmadığını kontrol ediyor.
                var cardNumberStatus = getCardToCheck.CardNumberHash.SequenceEqual(savedCreditCard.CardNumberHash);
                var expirationDateStatus = getCardToCheck.ExpirationDateHash.SequenceEqual(savedCreditCard.ExpirationDateHash);
                var cvvStatus = getCardToCheck.CvvHash.SequenceEqual(savedCreditCard.CvvHash);

                if (!cardNumberStatus || !expirationDateStatus || !cvvStatus)
                {
                    return new ErrorDataResult<SavedCreditCard>(getCardToCheck, Messages.NoCardInSystem);
                }
            }

            return new SuccessDataResult<SavedCreditCard>(getCardToCheck, Messages.CardAlreadySaved);
        }

        public IResult Delete(SavedCreditCard savedCreditCard)
        {
            _savedCreditCardDal.Delete(savedCreditCard);
            return new SuccessResult(Messages.CardsDeleted);
        }

        public IDataResult<List<SavedCreditCard>> GetAll()
        {
            return new SuccessDataResult<List<SavedCreditCard>>(_savedCreditCardDal.GetAll(), Messages.CardsListed);
        }

        public IDataResult<SavedCreditCard> GetById(int id)
        {
            return new SuccessDataResult<SavedCreditCard>(_savedCreditCardDal.Get(c => c.Id == id), Messages.CardsListed);
        }

        public IDataResult<SavedCreditCard> GetByUser(int userId)
        {
            return new SuccessDataResult<SavedCreditCard>(_savedCreditCardDal.GetByUser(userId), Messages.CardsListed);
        }

        public IResult Update(SavedCreditCard savedCreditCard)
        {
            _savedCreditCardDal.Update(savedCreditCard);
            return new SuccessResult(Messages.CardsUpdated);
        }
    }
}
