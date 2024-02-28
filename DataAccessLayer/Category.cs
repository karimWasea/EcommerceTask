namespace DataAccessLayer
{
    public class Category : BaseModel
    {

 
        public string Name { get; set; } = string.Empty;
         public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        public virtual ICollection< Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    }
}