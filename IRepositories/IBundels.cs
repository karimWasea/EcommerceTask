
using PagedList;

using Vmodels;


namespace IRepositories
{
    public interface IBundels : IRepository<BundelsViewModel>
    {
        IPagedList<BundelsViewModel> Search(BundelsViewModel schoolSm);

    }
}
