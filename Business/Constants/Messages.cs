﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
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

        public static string CarIsNotAvailable = "Araç kiralamaya uygun değil.";

        public static string CarImageLimitExceeded = "5'den fazla resim eklenemez.";
        public static string ImageAdded = "Resim(ler) eklendi.";
        public static string ImageDeleted = "Resim(ler) silindi.";
        public static string ImagesListed = "Resimler Listelendi.";
        public static string ImageUpdated = "Resim güncellendi.";
        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string UserRegistered = "Kayıt Başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut.";
        public static string AccessTokenCreated = "Token oluşturuldu.";

        public static string MaintenanceTime = "Sistem Bakımda.";
    }
}
