namespace DataAccessLayer
{
    public class Package : BaseModel
    {

        public string Name { get; set; } = string.Empty;

        public decimal ?Price { get; set; }
        public double ?TotalDiscount { get; set; }
        public virtual ICollection<Bundels>  Bundels { get; set; } = new List<Bundels>();
    }
}