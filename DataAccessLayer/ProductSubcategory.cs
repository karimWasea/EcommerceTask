using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    public class ProductSubcategory : BaseModel
    {


        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Subcategory")]
        public Guid SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
}