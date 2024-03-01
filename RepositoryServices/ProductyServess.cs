




using AutoMapper;

using DataAccessLayer;
using DataAccessLayer.Migrations;

using IRepositories;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using PagedList;

using System;

using Utailitze;

using Utalites;

using Vmodels;

namespace RepositoryServices
{
    public class ProductyServess : PaginationHelper<ProductViewModel>, IProduct
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly Imgoperation _Imgoperation;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;
        public ProductyServess(ApplicationDbContext applicationDbContext, IMapper mapper, IWebHostEnvironment webHostEnvironment, Imgoperation _Imgoperation)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            this._Imgoperation = _Imgoperation;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{Utalites.FileSettings.ImagesPathProduct}";
        }

        public int  ?Add(ProductViewModel entity)
        {
            try
            {
                entity.ImgesUrls = _Imgoperation.Addrengofimges(entity.ProductImgs!, _imagesPath!);
                entity.SKU = GenerateSKU(entity.Title);

                var Product = _mapper.Map< DataAccessLayer.Product >(entity);
               var products=  _applicationDbContext.Products.Add(Product);

                 _applicationDbContext.SaveChanges();
                // Assuming entity.ImgesUrls is a List<string> or IEnumerable<string>
                foreach (var Url in entity.ImgesUrls)
                {

                    var image = new Image() { Url = Url, ProductId = products.Entity.Id };

                    // Remove the image entity from the DbContext
                    _applicationDbContext.Images.Update(image);
                }




                foreach (var catagory in entity.Selectedcatagory)
                {

                    var ProductCategory = new ProductCategory() { CategoryId = catagory, ProductId = products.Entity.Id };

                    // Remove the image entity from the DbContext
                    _applicationDbContext.ProductCategory.Add(ProductCategory);
                }



                var effectedRowsImages = _applicationDbContext.SaveChanges();





                return effectedRowsImages;


            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while adding the category.", ex);
            }
        }

        public bool Delete(Guid id)
        {
            try
            {




                var isDeleted = false;

                var deleted = _applicationDbContext.Products.Find(id);

                if (deleted is null)
                    return isDeleted;

                _applicationDbContext.Remove(deleted);
                var effectedRows = _applicationDbContext.SaveChanges();
                ;

                if(effectedRows > 0)

                    isDeleted = true;

                // Get the URLs of the images to be deleted
                var urls = deleted.Images.Select(i => Path.Combine(_imagesPath, i.Url)).ToList();

                // Delete the image files if they exist
                urls
                    .Where(imagePath => File.Exists(imagePath)) // Filter out paths where the file does not exist
                    .ToList() // Convert to list to enable ForEach method
                    .ForEach(imagePath =>
                    {
                        try
                        {
                            File.Delete(imagePath);
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception (e.g., log it, display an error message, etc.)
                            Console.WriteLine($"Error deleting file '{imagePath}': {ex.Message}");
                        }
                    });



                return isDeleted;






            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while deleting the category.", ex);
            }
        }

        public ProductViewModel GetById(Guid id)
        {
            try
            {
                var entity = _applicationDbContext.Products.Find(id);
                return _mapper.Map<ProductViewModel>(entity);
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while getting the category by ID.", ex);
            }
        }

        public IPagedList<ProductSm> Search(ProductSm ProductSm)
        {
            var pagnumber = ProductSm.PagNumber ?? 1;
            try
            {
                var queryable = _applicationDbContext.Products.Include(i => i.Images)
     .Include(i => i.ProductCategory)
         .ThenInclude(p => p.Category)
     .Where(category =>
         (ProductSm.Id == Guid.Empty || category.Id == ProductSm.Id) &&
         (string.IsNullOrEmpty(ProductSm.Filterby) || category.Title.Contains(ProductSm.Filterby) || category.Description.Contains(ProductSm.Filterby)) &&
         (ProductSm.CategoryId==  Guid.Empty || category.ProductCategory.Any(i => i.CategoryId == ProductSm.CategoryId))
     )
     .Select(category => new ProductSm
     {
         Id = category.Id,
         Title = category.Title,
         Description = category.Description,
         Author = category.Author,
         SKU = category.SKU,
         ProductImgsId = category.Images.FirstOrDefault().Id ,
         CatagoryName = category.ProductCategory.FirstOrDefault().Category.Name ??"",
     })
     .OrderBy(categoryViewModel => categoryViewModel.Id);


                return GetPagedData(queryable, pagnumber);
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while searching for categories.", ex);
            }
        }

        public int? Update(ProductViewModel entity)
        {
            try
            {
                var model = _applicationDbContext.Products
                    .Include(g => g.ProductCategory)
                    .SingleOrDefault(g => g.Id == entity.Id);

                if (model is null)
                    return null;
                entity.SKU = GenerateSKU(entity.Title);

                bool hasNewCover = entity.ProductImgs is not null;

                _mapper.Map(entity, model);

               var product =  _applicationDbContext.Update(model);

                if (hasNewCover)
                {
                    entity.ImgesUrls =  _Imgoperation.Addrengofimges(entity.ProductImgs!, _imagesPath!);
                }

                var effectedRows = _applicationDbContext.SaveChanges();



                if (effectedRows > 0 && hasNewCover)
                {
                    var oldCoverPaths = model.Images.Select(i => Path.Combine(_imagesPath, i.Url));
                    oldCoverPaths.ToList().ForEach(File.Delete);
                }


                // Assuming entity.ImgesUrls is a List<string> or IEnumerable<string>
                foreach (var Url in entity.ImgesUrls)
                {
  
                    var image = new Image() { Url = Url ,ProductId= product.Entity.Id };  

                         // Remove the image entity from the DbContext
                        _applicationDbContext.Images.Update(image);
                 }

                foreach (var catagory in entity.Selectedcatagory)
                {

                    var ProductCategory = new ProductCategory() { CategoryId = catagory, ProductId = product.Entity.Id };

                    // Remove the image entity from the DbContext
                    _applicationDbContext.ProductCategory.Add(ProductCategory);
                }



                var effectedRowsImages = _applicationDbContext.SaveChanges();




                return effectedRows > 0 ? effectedRows : null;
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while updating the category.", ex);
            }
        }








        private string GenerateSKU(string title)
        {
            // Generate a new GUID and convert it to a string
            string guidString = Guid.NewGuid().ToString();

            // Remove any hyphens from the GUID
            guidString = guidString.Replace("-", "");

            // Take a substring of the GUID to ensure a fixed length
            guidString = guidString.Substring(0, Math.Min(guidString.Length, 8));

            // Convert the title to upper case and concatenate it with the substring of the GUID
            return title.ToUpper() + "_" + guidString;
        }





    }
}
