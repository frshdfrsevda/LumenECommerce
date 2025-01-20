namespace CetinFarshidfar.JewelryECommerce.Web.ResultMessages
{
    public static class Messages
    {
        public static class Product
        {
            public static string Add(string productName)
            {
                return $"{productName} başlıklı ürün başarıyla eklenmiştir.";
            }
            public static string Update(string productName)
            {
                return $"{productName} başlıklı ürün başarıyla güncellenmiştir.";
            }
            public static string Delete(string productName)
            {
                return $"{productName} başlıklı ürün başarıyla silinmiştir.";
            }
            public static string UndoDelete(string productName)
            {
                return $"{productName} başlıklı ürün başarıyla geri alınmıştır.";
            }
        }
        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla eklenmiştir.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla geri alınmıştır.";
            }
        }
        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla eklenmiştir.";
            }
            public static string Update(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla güncellenmiştir.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla silinmiştir.";
            }
        }
        public static class Company
        {
            public static string Application(string comName)
            {
                return $"{comName} isimli firma başvurusu başarıyla kaydedildi.";
            }
        }
    }
}
