
using PagedList;

using Vmodels;


namespace IRepositories
{
    public interface Isubcategory : IRepository<SubcategoryViewModel>
    {
        IPagedList<SubCategorySm> Search(SubCategorySm schoolSm);

    }
}
