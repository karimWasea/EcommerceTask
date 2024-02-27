using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string Url { get; set; }

        // Foreign key property
        public int ProductId { get; set; }

        // Navigation property
        public virtual Product Product { get; set; }
    }
}