using Infrastructure.Data.Context;
using Domain.Model.Interfaces.UoW;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BibliotecaContext _bibliotecaContext;
        private bool _disposed;
        private bool disposedValue;

        public UnitOfWork(BibliotecaContext bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _bibliotecaContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _bibliotecaContext.Dispose();
                }

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
