 




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
    public class SubCategoryServess  : PaginationHelper<SubcategoryViewModel> ,  Isubcategory
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
 
        public SubCategoryServess(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
         }

        public int Add(SubcategoryViewModel entity)
        {
            try
            {
                var subcategory = _mapper.Map<Subcategory>(entity);
                _applicationDbContext.Add(subcategory);
                return _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while adding the category.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var deleted = _applicationDbContext.Subcategories.Find(id);
                _applicationDbContext.Remove(deleted);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while deleting the category.", ex);
            }
        }

        public SubcategoryViewModel GetById(int id)
        {
            try
            {
                var entity = _applicationDbContext.Subcategories.Find(id);
                return _mapper.Map<SubcategoryViewModel>(entity);
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while getting the category by ID.", ex);
            }
        }

        public IPagedList<SubCategorySm> Search(SubCategorySm schoolSm)
        {
           var pagnumber =  schoolSm.PagNumber ??1;
            try
            {
                var queryable = _applicationDbContext.Subcategories.Where(category =>
                    (schoolSm.Id == Guid.Empty || schoolSm.Id ==null|| category.Id == schoolSm.Id) &&
                    (string.IsNullOrEmpty(schoolSm.Name) || category.Name.Contains(schoolSm.Name))
                )
                .Select(category => new SubCategorySm
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

        public int Update(SubcategoryViewModel entity)
        {
            try
            {
                var category = _mapper.Map<Subcategory>(entity);
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
