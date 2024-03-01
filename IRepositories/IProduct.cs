
using PagedList;

using Vmodels;


namespace IRepositories
{
    public interface IProduct : IRepository<ProductViewModel>
    {
        IPagedList<ProductSm> Search(ProductSm schoolSm);
        List<ProductViewModel> productDetails(Guid id);
          ProductViewModel GetLastProductInDatabase();



    }
}
