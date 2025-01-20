using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Helpers.Images
{
    public interface IImageHelper
    {
        Task<string> Upload(IFormFile imageFile, string folderName);
        void Delete(string path);
    }
}
