namespace DataAccessLayer
{
    public class Product : BaseModel
    {


        public String Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        public string Author { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public double Price { get; set; }

        public string SKU { get;   set; } = string.Empty;



        public virtual ICollection<ProductCategory> ProductCategory { get; set; } = new List<ProductCategory>();
        //public virtual ICollection<Subcategory>  Subcategories { get; set; } = new List<Subcategory>();
        public virtual ICollection<ProductPackage> ProductPackages { get; set; } = new List<ProductPackage>();
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    }










}