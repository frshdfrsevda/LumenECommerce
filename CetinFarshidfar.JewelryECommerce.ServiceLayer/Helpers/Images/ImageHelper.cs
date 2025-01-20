using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        private readonly string wwwroot;
        private readonly IWebHostEnvironment env;

        public ImageHelper(IWebHostEnvironment env)
        {
            this.env = env;
            wwwroot = env.WebRootPath;
        }

        public void Delete(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be null or empty", nameof(path));
            }

            // wwwroot klasörünün tam yolu
            string fullPath = Path.Combine(env.WebRootPath, path.TrimStart('/'));

            // Dosyanın var olup olmadığını kontrol et ve varsa sil
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            else
            {
                throw new FileNotFoundException("File not found at the specified path", fullPath);
            }
        }

        public async Task<string> Upload(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is not valid.", nameof(file));
            }
            folderName = "img\\products\\" + folderName;
            // wwwroot altındaki hedef klasörün tam yolu
            string uploadsFolder = Path.Combine(env.WebRootPath, folderName);

            // Klasör yoksa oluştur
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Dosya uzantısını alma
            string fileExtension = Path.GetExtension(file.FileName);

            // Fotoğraf için benzersiz bir isim oluştur
            string uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";

            // Tam dosya yolu
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Dosyayı belirtilen konuma kaydet
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Döndürülecek path (wwwroot'dan sonraki kısmı döndür)
            string relativePath = "/" + Path.Combine(folderName, uniqueFileName).Replace("\\", "/");

            return relativePath;
        }
    }
}
