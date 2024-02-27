
using PagedList;

namespace IRepositories
{
    public interface IPaginationHelper<T>
    {
        IPagedList<T> GetPagedData<T>(IQueryable<T> data, int pagenumber);
    }
}