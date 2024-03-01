using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    public class ProductCategory : BaseModel
    {


        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public virtual Category  Category { get; set; }
        public string Description { get; set; } = string.Empty;
        public double TotalDiscount { get; set; }


    }
}