namespace DataAccessLayer
{
    public class ProductPackage : BaseModel
    {

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid PackageId { get; set; }
        public  double ProductDiscount { get; set; }
        public Package Package { get; set; }


    }
}