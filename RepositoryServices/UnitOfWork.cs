using DataAccessLayer;

using IRepository;

namespace RepositoryServices
{
    public class UnitOfWork : IUnitOfWork
    {

        public readonly ApplicationDbContext _context;

        public UnitOfWork(


        )

        {




        }

        #region Implement the Dispose method to release resources
        private bool disposed = false;



        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }




        // Implement the finalizer to release unmanaged resources
        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion

















    }
}