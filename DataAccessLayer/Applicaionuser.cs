using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer
{

    public class Applicaionuser : IdentityUser
    {
        public string? ImgUrl { get; set; }

        public DateTime? BirthDate { get; set; }
        public string? Adress { get; set; }
= string.Empty;
        //public Gender Gender { get; set; }
        //public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;
        //public Department Department { get; set; }


    }
}