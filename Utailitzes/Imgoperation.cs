

////namespace Utailitze
////{

////    public class Imgoperation
////    {

////        IWebHostEnvironment webHostEnvironment;

////        public Imgoperation(IWebHostEnvironment webHostEnvironment)
////        {
////            this.webHostEnvironment = webHostEnvironment;
////        }
////        //public string Uploadimg(IFormFile formFiles)
////        //{
////        //    string filename = null;
////        //    if (formFiles != null)
////        //    {

////        //        string filledirectory = Path.Combine(webHostEnvironment.WebRootPath, "Images");
////        //        filename = Guid.NewGuid() + "-" + formFiles.FileName;
////        //        string filepath = Path.Combine(filledirectory, filename);
////        //        using (FileStream fs = new FileStream(filepath, FileMode.Create))
////        //        {
////        //            formFiles.CopyToAsync(fs);
////        //        }
////        //    }
////        //    return filename;

////        //}







////        public string SaveImage(IFormFile image)
////        {
////            if (image != null)
////            {
////                if (IsImageValid(image))
////                {
////                    // Generate a unique file name using a combination of timestamp and GUID
////                    var fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
////                    var newImagePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", fileName);

////                    try
////                    {
////                        using (var stream = new FileStream(newImagePath, FileMode.Create))
////                        {
////                            image.CopyTo(stream);
////                        }

////                        // Return the relative path to the image
////                        return $"/Images/{fileName}";
////                    }
////                    catch (Exception ex)
////                    {
////                        // Handle the exception (e.g., log it or provide user-friendly error message)
////                        // You may want to return an error code or message to the user
////                        return null;
////                    }
////                }
////            }

////            return null;
////        }

////        private bool IsImageValid(IFormFile image)
////        {
////            // Validate the file based on content type or extension
////            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" }; // Define your list of allowed extensions
////            var fileExtension = Path.GetExtension(image.FileName).ToLower();

////            return image.ContentType.StartsWith("image/") && allowedExtensions.Contains(fileExtension);
////        }

////    }
////}