using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vmodels
{
    public class BundelsViewModel :BaseSm
    {

        public Guid PackageId { get; set; }
         public string Description { get; set; } = string.Empty;

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
        public  List< Guid> SelecttedCategoryId { get; set; }
        public  List< string> MultiCatagoryNameforOneproduct { get; set; }
        public Guid ProductId { get; set; }
    }
}
