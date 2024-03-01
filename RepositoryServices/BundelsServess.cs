 




using AutoMapper;

using DataAccessLayer;

using IRepositories;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using PagedList;

using System;
using System.Text;

using Utailitze;

using Utalites;

using Vmodels;

namespace RepositoryServices
{
    public class BundelsServess : PaginationHelper<BundelsViewModel> , IBundels
    {
        private readonly ApplicationDbContext _applicationDbContext;
        IPackage _Package;
         private readonly IMapper _mapper;
         public BundelsServess(ApplicationDbContext applicationDbContext, IMapper mapper  ,Packageervess packageervess  )
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _Package = packageervess;   

           }

        public int? Add(BundelsViewModel entity)
        {

            try
            {
                var selectedCategoryIds = entity.SelecttedCategoryId;

          var ProductCategory = _applicationDbContext.ProductCategory .Include(p=>p.Product)
                .Where(pc => pc.ProductId == entity.ProductId && selectedCategoryIds.Contains(pc.CategoryId))
.FirstOrDefault();
                if (ProductCategory != null)
                {
                    entity.ProductCategoryId = ProductCategory.Id;
                     var  discount= entity.productDiscount / 100;  

                     entity.ProductPriceAfterdisonted = ProductCategory.Product.Price - discount;





                    var Bundels = _mapper.Map<Bundels>(entity);
                    _applicationDbContext.Add(Bundels);

                    _applicationDbContext.SaveChanges();
                    var pakage = new PackageViewModel();
                     pakage.Id = entity.PackageId;
                    pakage.Price= _applicationDbContext.Bundels.Where(i=>i.PackageId== entity.PackageId).Select(i=>i.productDiscount).Sum();
                    _Package.Update(pakage);
                    return _applicationDbContext.SaveChanges();

 
                }
                return null;

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

                var deleted = _applicationDbContext.Bundels.Find(id);

                if (deleted is null)
                    return isDeleted;

                _applicationDbContext.Remove(deleted);
                var effectedRows = _applicationDbContext.SaveChanges();
                 isDeleted = true;
                 


                return isDeleted;






            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while deleting the category.", ex);
            }
        }

















        public BundelsViewModel GetById(Guid id)
        {
            try
            {
                var entity = _applicationDbContext.Bundels.Find(id);
                return _mapper.Map<BundelsViewModel>(entity);
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while getting the category by ID.", ex);
            }
        }

        public IPagedList<BundelsViewModel> Search(BundelsViewModel schoolSm)
        {
           var pagnumber =  schoolSm.PagNumber ??1;
            try
            {
                var queryable = _applicationDbContext.Bundels.Include(i=>i.ProductCategory).
                    ThenInclude(p=>p.Product).ThenInclude(i=>i.Price).Include(i=>i.ProductCategory)
                    .ThenInclude(i=>i.Category).Where(category =>
                    (schoolSm.Id == Guid.Empty || schoolSm.Id ==null|| category.Id == schoolSm.Id) 
                 )
                .Select(category => new BundelsViewModel
                {
                    Id = category.Id,
                     PackageId = category.PackageId,
                      Description = category.Description,
  ProductCategoryId = category.ProductCategoryId
      ,
   productDiscount = category.productDiscount
         ,
    CatagoryName = category.ProductCategory.Category.Name,
     ProductId = category.ProductCategory.ProductId,
      ProductName = category.ProductCategory.Product.Title,
       CategoryId = category.ProductCategory.CategoryId
        , 
       PackensmeName = category.Package.Name,





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









        public int? Update(BundelsViewModel entity)
        {
            try
            {
                var selectedCategoryIds = entity.SelecttedCategoryId;

                var ProductCategory = _applicationDbContext.ProductCategory.Include(p => p.Product)
                      .Where(pc => pc.ProductId == entity.ProductId && selectedCategoryIds.Contains(pc.CategoryId))
      .FirstOrDefault();
                if (ProductCategory != null)
                {
                    entity.ProductCategoryId = ProductCategory.Id;
                    var discount = entity.productDiscount / 100;

                    entity.ProductPriceAfterdisonted = ProductCategory.Product.Price - discount;





                    var Bundels = _mapper.Map<Bundels>(entity);
                    _applicationDbContext.Update(Bundels);

                    _applicationDbContext.SaveChanges();
                    var pakage = new PackageViewModel();
                    pakage.Id = entity.PackageId;
                    pakage.Price = _applicationDbContext.Bundels.Where(i => i.PackageId == entity.PackageId).Select(i => i.productDiscount).Sum();
                    _Package.Update(pakage);

                    return _applicationDbContext.SaveChanges();
                    ;

                }
           
                return null;

            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while adding the category.", ex);
            }
        }
        }
}
