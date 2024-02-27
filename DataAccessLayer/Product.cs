namespace DataAccessLayer
{
    public class Product : BaseModel
    {


        public String Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        public string Author { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public double Price { get; set; }




        public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; } = new List<ProductSubcategory>();
        public virtual ICollection<ProductPackage> ProductPackages { get; set; } = new List<ProductPackage>();
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    }










}