using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    public class Subcategory : BaseModel
    {

        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}