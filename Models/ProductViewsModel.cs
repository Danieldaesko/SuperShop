using Microsoft.AspNetCore.Http;
using SuperShop.Web.Data.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuperShop.Web.Models
{
    public class ProductViewModel : Product
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
        public Guid ImageId { get; internal set; }
    }
}