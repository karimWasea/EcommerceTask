using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public String Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Range(0, 1000)]
        [Display(Name = "List Price")]
        [Required]
        public double ListPrice { get; set; }
        [Range(0, 1000)]
        [Display(Name = "Price For 1-50")]
        [Required]
        public double Price { get; set; }
        [Range(0, 100)]
        [Display(Name = "Price For 50+")]
        public double Price50 { get; set; }
        [Range(0, 1000)]
        [Display(Name = "Price For 100+")]
        [Required]
        public double Price100 { get; set; }


        public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; } = new List<ProductSubcategory>();
        public virtual ICollection<ProductPackage> ProductPackages { get; set; } = new List<ProductPackage>();
        public virtual ICollection<Image> Images { get; set; }

    }










}