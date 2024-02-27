using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class ProductPackage
    {
        [Key]
        public int ProductPackageId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }
    }
}