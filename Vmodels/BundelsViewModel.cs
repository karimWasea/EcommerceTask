using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace Vmodels
{
    public class BundelsViewModel :BaseSm
    {
        [Required(ErrorMessage = "  is required.")]
        public Guid PackageId { get; set; }
        [Required(ErrorMessage = "  is required.")]

        public string Description { get; set; }
        [Required(ErrorMessage = "  is required.")]

        public double? productDiscount { get; set; }
        public double? ProductPriceAfterdisonted { get; set; }
        public Guid ProductCategoryId { get; set; }
        public IEnumerable<SelectListItem> catagory { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Pakgesids { get; set; } = Enumerable.Empty<SelectListItem>();

        public string ProductName { get; set; } = string.Empty;
         public string PackgeName { get; set; } = string.Empty;
         public string CatagoryName  { get; set; } = string.Empty;

        public double? ProductPriceBefordisonted { get; set; }

         public Guid  CategoryId { get; set; }
        [Required(ErrorMessage = "  is required.")]

        public List< Guid> SelecttedCategoryId { get; set; }
        public  List< string> MultiCatagoryNameforOneproduct { get; set; } = new List< string>();
        [Required(ErrorMessage = "  is required.")]

        public Guid ProductId { get; set; }
    }
}
