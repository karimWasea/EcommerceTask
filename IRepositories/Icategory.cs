
using PagedList;

using Vmodels;


namespace IRepositories
{
    public interface Icategory : IRepository<CategoryViewModel>
    {
        IPagedList<CategorySm> Search(CategorySm schoolSm);

    }
}
