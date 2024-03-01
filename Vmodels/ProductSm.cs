using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vmodels
{
    public class ProductSm : BaseSm
    {


        [Required(ErrorMessage = "  is required.")]

        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "  is required.")]

        public String Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "  is required.")]

        public string Description { get; set; } = string.Empty;
        public string CatagoryName { get; set; } = string.Empty;
        [Required(ErrorMessage = "  is required.")]


        public string Author { get; set; } = string.Empty;
        [Required(ErrorMessage = "  is required.")]

        public string ISBN { get; set; } = string.Empty;
        [Required(ErrorMessage = "  is required.")]

        public double Price { get; set; }

        public string SKU { get; set; } = string.Empty;
        [Required(ErrorMessage = "  is required.")]

        public DateTime Productiondate { get; set; }


        public IEnumerable<SelectListItem> catagory { get; set; } = Enumerable.Empty<SelectListItem>();
        [Required(ErrorMessage = "  is required.")]
        [AllowedExtensions(FileSettings.AllowedExtensions),
            MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormCollection? ProductUrl { get; set; }
        public List<Guid> Selectedcatagory { get; set; } = default!;
        public  Guid  ProductImgsId { get; set; } = default!;
        public List<string> ProductImgs { get; set; } = default!;

    }
}