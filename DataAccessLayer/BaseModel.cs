using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}