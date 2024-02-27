using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<ProductPackage> ProductPackages { get; set; }
    }
}