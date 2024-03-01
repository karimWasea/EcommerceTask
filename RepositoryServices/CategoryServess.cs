 







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
    public class CategoryServess  : PaginationHelper<CategoryViewModel> , Icategory
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
 
        public CategoryServess(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
         }

        public int Add(CategoryViewModel entity)
        {
            try
            {
                var category = _mapper.Map<Category>(entity);
                _applicationDbContext.Add(category);
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

        public CategoryViewModel GetById(Guid id)
        {
            try
            {
                var category = _applicationDbContext.Categories.Find(id);
                return _mapper.Map<CategoryViewModel>(category);
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while getting the category by ID.", ex);
            }
        }

        public IPagedList<CategorySm> Search(CategorySm schoolSm)
        {
           var pagnumber =  schoolSm.PagNumber ??1;
            try
            {
                var queryable = _applicationDbContext.Categories.Where(category =>
                    (schoolSm.Id == Guid.Empty || schoolSm.Id ==null|| category.Id == schoolSm.Id) &&
                    (string.IsNullOrEmpty(schoolSm.Name) || category.Name.Contains(schoolSm.Name))
                )
                .Select(category => new CategorySm
                {
                    Id = category.Id,
                     Name = category.Name,
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

        public int? Update(CategoryViewModel entity)
        {
            try
            {
                var category = _mapper.Map<Category>(entity);
                _applicationDbContext.Update(category);
                return _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while updating the category.", ex);
            }
        }
    }
}
