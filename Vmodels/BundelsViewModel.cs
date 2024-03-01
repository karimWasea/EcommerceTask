namespace Vmodels
{
    public class BundelsViewModel :BaseSm
    {

        public Guid PackageId { get; set; }
         public string Description { get; set; } = string.Empty;
         public string ProductName { get; set; } = string.Empty;
         public string PackensmeName { get; set; } = string.Empty;
         public string CatagoryName  { get; set; } = string.Empty;

        public double? productDiscount { get; set; }
        public double? ProductPriceAfterdisonted { get; set; }
        public double? ProductPriceBefordisonted { get; set; }
        public Guid ProductCategoryId { get; set; }
        public Guid  CategoryId { get; set; }
        public  List< Guid> SelecttedCategoryId { get; set; }
        public Guid ProductId { get; set; }
    }
}
