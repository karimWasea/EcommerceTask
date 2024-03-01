 





using AutoMapper;

using DataAccessLayer;

using IRepositories;

using Microsoft.EntityFrameworkCore;

using PagedList;

using System;

using Utailitze;

using Vmodels;

namespace RepositoryServices
{
    public class Packageervess : PaginationHelper<PackageViewModel> , IPackage

    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
 
        public Packageervess(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
         }

        public int ?Add(PackageViewModel entity)
        {
            try
            {
                var Package = _mapper.Map<Packageviewmodel>(entity);
                _applicationDbContext.Add(Package);
                return _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while adding the category.", ex);
            }
        }

        public  bool Delete(Guid id)
        {
            try
            {
                var isDeleted = false;

                var deleted = _applicationDbContext.Categories.Find(id);
                _applicationDbContext.Remove(deleted);
              var affectedrows =  _applicationDbContext.SaveChanges();

                if (affectedrows>0)
                {
                    isDeleted= true ;
                    return isDeleted;

                }
                return isDeleted;

            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while deleting the category.", ex);
            }
        }

        public PackageViewModel GetById(Guid id)
        {
            try
            {
                var category = _applicationDbContext.Categories.Find(id);
                return _mapper.Map<PackageViewModel>(category);
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while getting the category by ID.", ex);
            }
        }

        public IPagedList<PackageViewModel> Search(PackageViewModel schoolSm)
        {
           var pagnumber =  schoolSm.PagNumber ??1;
            try
            {
                var queryable = _applicationDbContext.Packages.Where(category =>
                    (schoolSm.Id == Guid.Empty || schoolSm.Id ==null|| category.Id == schoolSm.Id) &&
                    (string.IsNullOrEmpty(schoolSm.Name) || category.Name.Contains(schoolSm.Name))
                )
                .Select(category => new PackageViewModel
                {
                    Id = category.Id,
                     Name = category.Name,
                     TotalDiscount = category.TotalDiscount,
                     Price = category.Price,
                })
                .OrderBy(PackageViewModel => PackageViewModel.Id);

                return GetPagedData(queryable, pagnumber);
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while searching for categories.", ex);
            }
        }

        public int? Update(PackageViewModel entity)
        {
            try
            {
                var Package = _mapper.Map<Packageviewmodel>(entity);
                _applicationDbContext.Update(Package);
                return _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while updating the Package.", ex);
            }
        }
    }
}
