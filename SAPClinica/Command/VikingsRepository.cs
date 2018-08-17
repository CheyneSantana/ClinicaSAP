using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SAPClinica.Command
{
    public class VikingsRepository<T> : IDisposable, IVikingRepository<T> where T : class
    {
        protected VikingsContext context;
        public VikingsRepository()
        {
            this.context = new VikingsContext();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    context.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<T> getAll()
        {
            return this.context.Set<T>().ToList();
        }

        public T getID(decimal prID)
        {
            return context.Set<T>().Find(prID);
        }

        public virtual void Insert(T prEntity)
        {
            context.Set<T>().Add(prEntity);
            context.SaveChanges();
        }

        public virtual void Delete(T prEntity)
        {
            context.Set<T>().Remove(prEntity);
            context.SaveChanges();
        }

        public virtual void Update(T prEntity)
        {
            context.Entry(prEntity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}