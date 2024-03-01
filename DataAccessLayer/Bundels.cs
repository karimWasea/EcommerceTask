namespace DataAccessLayer
{
    public class  Bundels : BaseModel
    {

      

        public Guid PackageId { get; set; }
        public Package Package { get; set; }
        public string Description { get; set; } = string.Empty;

        public double ? productDiscount { get; set; }
        public double? ProductPriceAfterdisonted { get; set; }
        public Guid ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }



    }
}