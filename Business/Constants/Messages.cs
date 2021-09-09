using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AuthUserRegistered = "Kayıt Başarılı";
        public static string AuthUserNotFound = "Kullanıcı bulunamadı.";
        public static string AuthPasswordError = "Şifre hatalı.";
        public static string AuthSuccessfulLogin = "Başarılı giriş.";
        public static string AuthUserAlreadyExists = "Kullanıcı zaten mevcut.";
        public static string AuthAccessTokenCreated = "Token oluşturuldu.";
        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string CarAdded = "Araç başarılı şekilde eklendi.";
        public static string CarDeleted = "Araç başarılı şekilde silindi.";
        public static string CarUpdated = "Araç başarılı şekilde güncellendi.";
        public static string CarNameInvalid = "Araç ismi en az 3 karakter olmalı.";
        public static string CarDailyPriceInvalid = "Araç günlük fiyatı 0'dan yüksek olmalı.";
        public static string CarListed = "Arabalar listelendi.";

        public static string BrandAdded = "Marka başarılı şekilde eklendi.";
        public static string BrandDeleted = "Marka başarılı şekilde silindi.";
        public static string BrandUpdated = "Marka başarılı şekilde güncellendi.";
        public static string BrandListed = "Markalar listelendi.";

        public static string UserAdded = "Kullanıcı başarılı şekilde eklendi.";
        public static string UserDeleted = "Kullanıcı başarılı şekilde silindi.";
        public static string UserUpdated = "Kullanıcı başarılı şekilde güncellendi.";
        public static string UsersListed = "Kullanıcılar listelendi.";

        public static string CustomerAdded = "Müşteri başarılı şekilde eklendi.";
        public static string CustomerDeleted = "Müşteri başarılı şekilde silindi.";
        public static string CustomerUpdated = "Müşteri başarılı şekilde güncellendi.";
        public static string CustomersListed = "Müşteri listelendi.";

        public static string RentalAdded = "Kiralama işlemi başarılı şekilde oluşturuldu.";
        public static string RentalDeleted = "Kiralama işlemi başarılı şekilde silindi.";
        public static string RentalUpdated = "Kiralama işlemi başarılı şekilde güncellendi.";
        public static string RentalsListed = "Kiralama işlemleri listelendi.";
        public static string RentalCarIsNotAvailable = "Araç kiralamaya uygun değil.";

        public static string ImageCarLimitExceeded = "5'den fazla resim eklenemez.";
        public static string ImageAdded = "Resim(ler) eklendi.";
        public static string ImageDeleted = "Resim(ler) silindi.";
        public static string ImagesListed = "Resimler Listelendi.";
        public static string ImageUpdated = "Resim güncellendi.";

        public static string MaintenanceTime = "Sistem Bakımda.";

        public static string FindexRateAdded = "Findex puanı eklendi.";
        public static string FindexRateUpdated = "Findex puanı güncellendi.";

        public static string CardSaved = "Kredi kartı kaydedildi.";
        public static string CardSavedError = "Kaydedilme sırasında hata oluştu.";
        public static string CardAlreadySaved = "Kart sistemde kayıtlı.";
        public static string CardsListed = "Kartlar listelendi";
        public static string CardsUpdated = "Kart bilgileri güncellendi.";
        public static string CardsDeleted = "Kart bilgileri sistemden silindi.";
        public static string NoCardForUser = "Sistemde bu kullanıcıya ait tanımlı kart yok.";
        public static string NoCardInSystem = "Kart sistemde kayıtlı değil";


        public static string PaymentSuccessful = "Ödeme başarılı şeklide gerçekleşti.";
        public static string PaymentFail = "Ödeme işlemi başarısız.";
    }
}
