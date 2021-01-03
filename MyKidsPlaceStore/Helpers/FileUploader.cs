using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyKidsPlaceStore.Helpers
{
    public class FileUploader
    {
        private string[] permittedExtensions = { ".jpg", ".jpeg", ".tiff", ".png" };
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironmen)
        {
            _webHostEnvironment = webHostEnvironmen;
        }
        public async Task<string> PostFile(IFormFile File)
        {
            string randomFileName = Guid.NewGuid().ToString() + Path.GetExtension(File.FileName);
            if (File.Length > 0)
            {
                if (File.Length >= 5242880)
                {
                    throw new ValidationException("File size is invalid, max file size is 5 MB");
                }

                string directory = _webHostEnvironment.WebRootPath + "\\AppImages\\";
                string filePath = Path.Combine(directory, randomFileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string ext = Path.GetExtension(filePath).ToLowerInvariant();

                if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                {
                    throw new ValidationException("File extention is not valid");
                }


                using (var stream = System.IO.File.Create(filePath))
                {
                    await File.CopyToAsync(stream);
                }

            }


            return randomFileName;
        }

        public bool DeleteFile(string fileName)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath + "\\AppImages\\", fileName);
            if (File.Exists(path))
            {
                // If file found, delete it    
                File.Delete(Path.Combine(path));
            }
            return true;
        }
    }
}
