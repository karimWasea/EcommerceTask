using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace Vmodels
{
 
    public static class FileSettings
    {
        public const string ImagesPathSubcatagory = "/assets/images/Subcatagory";
        public const string ImagesPathcatagory = "/assets/images/Subcatagory";
        public const string ImagesPathProduct = "/assets/images/Products";
        public const string AllowedExtensions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
   








}