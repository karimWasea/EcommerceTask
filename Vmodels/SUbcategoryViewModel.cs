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
     







}