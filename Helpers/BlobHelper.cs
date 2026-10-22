using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace SuperShop.Helpers
{
    public class BlobHelper : IBlobHelper
    {
        private readonly IWebHostEnvironment _env;

        public BlobHelper(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UploadBlobAsync(IFormFile file, string containerName)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var imageName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var folder = EnsureFolder(containerName);
            var filePath = Path.Combine(folder, imageName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/{containerName}/{imageName}";
        }

        public async Task<string> UploadBlobAsync(byte[] file, string containerName)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var imageName = $"{Guid.NewGuid()}.jpg";
            var folder = EnsureFolder(containerName);
            var filePath = Path.Combine(folder, imageName);

            await File.WriteAllBytesAsync(filePath, file);

            return $"/{containerName}/{imageName}";
        }

        public async Task<string> UploadBlobAsync(string image, string containerName)
        {
            return await Task.FromResult(image);
        }

        private string EnsureFolder(string containerName)
        {
            var folder = Path.Combine(_env.WebRootPath, containerName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            return folder;
        }
    }
}