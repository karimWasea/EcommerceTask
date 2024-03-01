namespace DataAccessLayer
{
    public class Packageviewmodel : BaseModel
    {

        public string Name { get; set; } = string.Empty;

        public double? Price { get; set; }
        public double ?TotalDiscount { get; set; }
        public virtual ICollection<Bundels>  Bundels { get; set; } = new List<Bundels>();
    }
}