namespace DataAccessLayer
{
    public class Category : BaseModel
    {


        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public virtual Category ? ParentCategory { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        public virtual ICollection<Category> Subcategories { get; set; } = new List<Category>();
    }
}