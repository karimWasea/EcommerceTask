
using PagedList;

using Vmodels;


namespace IRepositories
{
    public interface IPackage : IRepository<PackageViewModel>
    {
        IPagedList<PackageViewModel> Search(PackageViewModel PackageViewModel);

    }
}
