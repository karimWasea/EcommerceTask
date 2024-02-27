namespace DataAccessLayer
{
    public class Package : BaseModel
    {

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public virtual ICollection<ProductPackage> ProductPackages { get; set; } = new List<ProductPackage>();
    }
}