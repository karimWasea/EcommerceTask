namespace DataAccessLayer
{
    public class Image : BaseModel
    {


        public string Url { get; set; } = string.Empty;

        // Foreign key property
        public Guid ProductId { get; set; }

        // Navigation property
        public virtual Product Product { get; set; }
    }
}