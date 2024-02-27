using PagedList;

namespace IRepository
{
    public interface IPaginationHelper<T>
    {
        IPagedList<T> GetPagedData<T>(IQueryable<T> data, int pagenumber);
    }
}