﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi!";
        public static string ProductNameInvalid = "Geçersiz Ürün İsmi!";
        public static string MaintenanceTime = "Sistem bakımda!";
        public static string ProductsListed = "Ürünler Listelendi!";
        public static string ByCategoryListed = "Kategoriye Göre Listelendi!";
        public static string ProductCountOfCategoryError = "Kategori Dolu!";
        public static string ProductNameAlreadyExistError = "Bu isimde bir ürün zaten var!";
        public static string CategoryLimitExceded = "Kategori Limiti Aşıldı!";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
    }
}
