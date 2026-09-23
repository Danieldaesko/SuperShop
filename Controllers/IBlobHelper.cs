using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace SuperShop.Web.Controllers
{
    public interface IBlobHelper
    {
        Task<Guid> UploadBlobAsync(IFormFile imageFile, string v);
    }
}