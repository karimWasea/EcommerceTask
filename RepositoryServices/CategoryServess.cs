//using AutoMapper;

//using DataAccessLayer;

//using IRepositories;

//using Microsoft.EntityFrameworkCore;

//using PagedList;

//using Utailitze;

//using Vmodels;

//namespace RepositoryServices
//{
//    public class CategoryServess  :Icategory
//    {

//        private ApplicationDbContext _ApplicationDBcontext;
//        private IMapper _mapper;
//        private IPaginationHelper<CategoryViewModel>  _paginationHelper;
//        public CategoryServess(ApplicationDbContext applicationDBcontext

//            , IMapper mapper , PaginationHelper<CategoryViewModel> paginationHelper)
//        {
//            _ApplicationDBcontext = applicationDBcontext;
//            _mapper = mapper;
//            _paginationHelper = paginationHelper;

//        }

//        public int Add(CategoryViewModel entity)
//        {
//            var Category = _mapper.Map<Category>(entity);
//            _ApplicationDBcontext.Add(Category);
//            return _ApplicationDBcontext.SaveChanges();
//        }

//        public void Delete(int id)
//        {

//           var deleted=  _ApplicationDBcontext.Categories.Find(id);
//            _ApplicationDBcontext.Remove(deleted);
//              _ApplicationDBcontext.SaveChanges();
//        }

//        public CategoryViewModel GetById(int id)
//        {
//            var Category = _ApplicationDBcontext.Categories.Find(id);
//            var findedcatigory = _mapper.Map<CategoryViewModel>(Category);
//            return findedcatigory;
//              }



//        public IPagedList<CategoryViewModel> Search(CategorySm schoolSm)
//        {
//            var queryable = _ApplicationDBcontext.Categories.Where(category =>
//                (schoolSm.Id == Guid.Empty || category.Id == schoolSm.Id   ) &&
//                (string.IsNullOrEmpty(schoolSm.Name) || category.Name.Contains(schoolSm.Name))
//            )
//            .Select(category => new CategoryViewModel
//            {
//                Id = category.Id,
//                Image = category.Image   , 
//                 Name = category.Name ,

//             })
//            .OrderBy(categoryViewModel => categoryViewModel.Id);

//            return _paginationHelper.GetPagedData(queryable, schoolSm.PagNumber);
//        }

//        public int Update(CategoryViewModel entity)
//        {
//            var Category = _mapper.Map<Category>(entity);
//            _ApplicationDBcontext.Update(Category);
//            return _ApplicationDBcontext.SaveChanges();
//        }
//    }


//    }










using AutoMapper;

using DataAccessLayer;

using IRepositories;

using Microsoft.EntityFrameworkCore;

using PagedList;

using System;

using Vmodels;

namespace RepositoryServices
{
    public class CategoryServess : Icategory
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly IPaginationHelper<CategoryViewModel> _paginationHelper;

        public CategoryServess(ApplicationDbContext applicationDbContext, IMapper mapper, IPaginationHelper<CategoryViewModel> paginationHelper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _paginationHelper = paginationHelper;
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

        public void Delete(int id)
        {
            try
            {
                var deleted = _applicationDbContext.Categories.Find(id);
                _applicationDbContext.Remove(deleted);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while deleting the category.", ex);
            }
        }

        public CategoryViewModel GetById(int id)
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

        public IPagedList<CategoryViewModel> Search(CategorySm schoolSm)
        {
            try
            {
                var queryable = _applicationDbContext.Categories.Where(category =>
                    (schoolSm.Id == Guid.Empty || category.Id == schoolSm.Id) &&
                    (string.IsNullOrEmpty(schoolSm.Name) || category.Name.Contains(schoolSm.Name))
                )
                .Select(category => new CategoryViewModel
                {
                    Id = category.Id,
                    Image = category.Image,
                    Name = category.Name,
                })
                .OrderBy(categoryViewModel => categoryViewModel.Id);

                return _paginationHelper.GetPagedData(queryable, schoolSm.PagNumber);
            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while searching for categories.", ex);
            }
        }

        public int Update(CategoryViewModel entity)
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
