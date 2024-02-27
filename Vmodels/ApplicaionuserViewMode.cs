namespace Vmodels
{
    namespace HR.ViewModel
    {
  

        using System;
        using System.ComponentModel.DataAnnotations;

 
        public class ApplicaionuserViewMode
        {

            //public IEnumerable<SelectListItem> listGender { get; set; } = Enumerable.Empty<SelectListItem>();
            //public IEnumerable<SelectListItem> alldept { get; set; } = Enumerable.Empty<SelectListItem>();

            public string Id { get; set; }
            [Required(ErrorMessage = "is requred")]

            public int deptmentid { get; set; }
            [Required(ErrorMessage = "is requred")]

            public double? Salary { get; set; }

            public double? Bouns { get; set; }
            [Required(ErrorMessage = "is requred")]

            public string? JobTitle { get; set; }

            [Required(ErrorMessage = "is requred")]

            public string? Adress { get; set; }
            //[ValidateImage(ErrorMessage = "Please upload a valid image (JPEG or PNG) and ensure it is less than 5MB.")]

            //public IFormFile ContructUrl { get; set; }
            //[ValidateImage(ErrorMessage = "Please upload a valid image (JPEG or PNG) and ensure it is less than 5MB.")]

            //public IFormFile ImgUrl { get; set; }


            public string ContructPath { get; set; } =
            string.Empty;

            public string? ManagerId { get; set; } = string.Empty;
            //[Required]
            [Required(ErrorMessage = "is requred")]

            public DateTime? BirthDate { get; set; }
            //[Required]
            [Required(ErrorMessage = "is requred")]

            public DateTime? HirangDate { get; set; }

            // User fields
            //[Required]
            [Required(ErrorMessage = "is requred")]

            public string? UserName { get; set; }
            public string? NormalizedUserName { get; set; }
            //[Required]
            [Required(ErrorMessage = "is requred")]

            public string? Email { get; set; }

            public string? NormalizedEmail { get; set; }
            public bool EmailConfirmed { get; set; }
            [Required(ErrorMessage = "is requred")]

            public string? PasswordHash { get; set; }
            public string? SecurityStamp { get; set; }
            public string? ConcurrencyStamp { get; set; }
            //[Required]
            [Required(ErrorMessage = "is requred")]

            public string? PhoneNumber { get; set; }
            //public IFormFile ImgUrls { get; set; }
            //[Required]

            public string imgPath { get; set; } = string.Empty;




            public bool PhoneNumberConfirmed { get; set; }
            public bool TwoFactorEnabled { get; set; }
            public DateTimeOffset? LockoutEnd { get; set; }
            public bool LockoutEnabled { get; set; }
            public int AccessFailedCount { get; set; }

        }
    }
}