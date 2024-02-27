
using PagedList;

using Vmodels;


namespace IRepositories
{
    public interface Icategory : IRepository<CategoryViewModel>
    {
        IPagedList<CategoryViewModel> Seach(CategorySm schoolSm);

    }
}
