using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}