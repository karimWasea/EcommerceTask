





using AutoMapper;

using DataAccessLayer;

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
    public class SubCategoryServess  : PaginationHelper<SubcategoryViewModel> ,  Isubcategory
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly Imgoperation _Imgoperation;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;
        public SubCategoryServess(ApplicationDbContext applicationDbContext, IMapper mapper , IWebHostEnvironment webHostEnvironment , Imgoperation _Imgoperation)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            this._Imgoperation = _Imgoperation; 
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{Utalites.FileSettings.ImagesPathSubcatagory}";
        }

        public int? Add(SubcategoryViewModel entity)
        {
            try
            {
                entity.Image =   _Imgoperation.SaveCover(entity.CatagoryImgURL!, _imagesPath!);
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

        public bool Delete(Guid id)
        {
            try
            {




                var isDeleted = false;

                var deleted = _applicationDbContext.Subcategories.Find(id);

                if (deleted is null)
                    return isDeleted;

                _applicationDbContext.Remove(deleted);
                var effectedRows = _applicationDbContext.SaveChanges();
                ;

                if (effectedRows > 0)
                {
                    isDeleted = true;

                    var cover = Path.Combine(_imagesPath, deleted.Image);
                    File.Delete(cover);
                }

                return isDeleted;






            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while deleting the category.", ex);
            }
        }

        public SubcategoryViewModel GetById(Guid id)
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
                var queryable = _applicationDbContext.Subcategories.Include(i=>i.Category).Where(category =>
                    (schoolSm.Id == Guid.Empty || schoolSm.Id ==null|| category.Id == schoolSm.Id) &&
                    (string.IsNullOrEmpty(schoolSm.Name) || category.Name.Contains(schoolSm.Name))
                )
                .Select(category => new SubCategorySm
                {
                    Id = category.Id,
                     Name = category.Name,
                     Description = category.Description,
                     CatagoryName = category.Category.Name,
                     Image = category.Image,
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

        public int? Update(SubcategoryViewModel entity)
        {
            try
            {
                var models = _applicationDbContext.Subcategories
            .Include(g => g.Category)
            .SingleOrDefault(g => g.Id == entity.Id);

                if (models is null)
                    return null;

                var hasNewCover = entity.CatagoryImgURL is not null;
                var oldCover = models.Image;

                var category = _mapper.Map<Subcategory>(entity);
                _applicationDbContext.Update(category);
                if (hasNewCover)
                {
                    entity.Image = _Imgoperation.  SaveCover(entity.CatagoryImgURL! , _imagesPath!);
                }

                var effectedRows = _applicationDbContext.SaveChanges();

                if (effectedRows > 0)
                {
                    if (hasNewCover)
                    {
                        var cover = Path.Combine(_imagesPath, oldCover);
                        File.Delete(cover);
                    }

                    return effectedRows;
                }
                else
                {
                    var cover = Path.Combine(_imagesPath, models.Image);
                    File.Delete(cover);

                    return null;
                
            }            }
            catch (Exception ex)
            {
                // Handle exception (log, throw, etc.)
                throw new Exception("An error occurred while updating the category.", ex);
            }
        }
    }
}
