
 
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Utalites
{

    public class Imgoperation
    {











        IHostingEnvironment _hostEnvironment;

        public Imgoperation(

           IHostingEnvironment host)
        {
            _hostEnvironment = host;
        }


        public List<string> Addrengofimges(List<IFormFile> images, string oldImageUrl)
        {
            // Delete the old image if exists
            if (!string.IsNullOrEmpty(oldImageUrl))
            {
                string oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, oldImageUrl.TrimStart('/'));
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }

            // Create a list to store the new image paths
            var imagePaths = new List<string>();

            // Check if any new images are uploaded
            if (images != null && images.Count > 0)
            {
                foreach (var file in images)
                {
                    // Generate a unique file name using GUID to avoid name conflicts
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var newImagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);

                    using (var stream = new FileStream(newImagePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    // Add the file path to the list
                    imagePaths.Add($"/images/{fileName}"); // Store the relative path to the image
                }
            }

            return imagePaths;
        }





        public string SaveImage(IFormFile image)
        {
            if (image != null)
            {
                if (IsImageValid(image))
                {
                    // Generate a unique file name using a combination of timestamp and GUID
                    var fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                    var newImagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", fileName);

                    try
                    {
                        using (var stream = new FileStream(newImagePath, FileMode.Create))
                        {
                            image.CopyTo(stream);
                        }

                        // Return the relative path to the image
                        return $"/Images/{fileName}";
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception (e.g., log it or provide user-friendly error message)
                        // You may want to return an error code or message to the user
                        return null;
                    }
                }
            }

            return null;
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