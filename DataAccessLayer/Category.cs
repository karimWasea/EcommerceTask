namespace DataAccessLayer
{
    public class Category : BaseModel
    {


        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public virtual ICollection<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    }
}