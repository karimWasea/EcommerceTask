namespace Vmodels
{
    public class PackageViewModel : BaseSm { 

        public string Name { get; set; } = string.Empty;

        public decimal? Price { get; set; }
        public double? TotalDiscount { get; set; }
    }
}