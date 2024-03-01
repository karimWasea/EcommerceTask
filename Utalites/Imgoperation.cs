
 
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Utalites
{

    public class Imgoperation
    {








        public const string ImagesPathSubcatagory = "/assets/images/Subcatagory";
        public const string ImagesPathcatagory = "/assets/images/Subcatagory";


        IHostingEnvironment _hostEnvironment;
        public Imgoperation(

           IHostingEnvironment host)
        {
 
             
            _hostEnvironment = host;
        }


        public List<string> Addrengofimges(IFormCollection? images, string oldImageUrl)
        {
            // Delete the old image if it exists
            string oldImagePath = oldImageUrl;

            if (!string.IsNullOrEmpty(oldImageUrl))
            {
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }

            // Create a list to store the new image paths
            var imagePaths = new List<string>();

            // Check if any new images are uploaded
            if (images != null && images.Files.Count > 0)
            {
                foreach (var file in images.Files)
                {
                    // Generate a unique file name using GUID to avoid name conflicts
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var newImagePath = Path.Combine(oldImagePath, fileName);

                    using (var stream = new FileStream(newImagePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    // Add the file path to the list
                    imagePaths.Add($"{oldImageUrl}/{fileName}"); // Store the relative path to the image
                }
            }

            return imagePaths;
        }





        // public string SaveCover(IFormFile cover  , string paths)
        //{
        //    var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

        //    var path = Path.Combine(coverName,paths);

        //    using var stream = File.Create(path);
        //      cover.CopyToAsync(stream);

        //    return coverName;
        //}





        public string SaveCover(IFormFile formFiles, string paths)
        {
            string filename = null;
            if (formFiles != null && formFiles.Length > 0)
            {
                string filledirectory = paths; // Use the provided full directory path directly
                if (!Directory.Exists(filledirectory))
                {
                    Directory.CreateDirectory(filledirectory); // Create directory if it doesn't exist
                }

                filename = Guid.NewGuid() + "-" + Path.GetFileName(formFiles.FileName); // Generate unique filename
                string filepath = Path.Combine(filledirectory, filename); // Combine directory path and filename

                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    formFiles.CopyTo(fs); // Synchronously copy the file
                }
            }
            return $" {paths}/{filename}";
        }





        private bool IsImageValid(IFormFile image)
        {
            // Validate the file based on content type or extension
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" }; // Define your list of allowed extensions
            var fileExtension = Path.GetExtension(image.FileName).ToLower();

            return image.ContentType.StartsWith("image/") && allowedExtensions.Contains(fileExtension);
        }









    }
}