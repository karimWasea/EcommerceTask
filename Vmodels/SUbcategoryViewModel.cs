using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace Vmodels
{
    public class SubcategoryViewModel
        : BaseViewModel
    {

        public IEnumerable<SelectListItem> catagory { get; set; } = Enumerable.Empty<SelectListItem>();

        public string Image { get; set; } = string.Empty;
        [Required(ErrorMessage = "  is required.")]

        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "  is required.")]

        public string Name { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "  is required.")]

        [AllowedExtensions(FileSettings.AllowedExtensions),
            MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile CatagoryImgURL { get; set; } = default!;

      }
    public static class FileSettings
    {
        public const string ImagesPathSubcatagory = "/assets/images/Subcatagory";
        public const string ImagesPathcatagory = "/assets/images/Subcatagory";
        public const string ImagesPathProduct = "/assets/images/Products";
        public const string AllowedExtensions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file is not null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult($"Maximum allowed size is {_maxFileSize} bytes");
                }
            }

            return ValidationResult.Success;
        }
    }






    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string _allowedExtensions;

        public AllowedExtensionsAttribute(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file is not null)
            {
                var extension = Path.GetExtension(file.FileName);

                var isAllowed = _allowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);

                if (!isAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtensions} are allowed!");
                }
            }

            return ValidationResult.Success;
        }
    }








}