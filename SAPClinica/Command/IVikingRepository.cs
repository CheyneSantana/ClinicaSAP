using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPClinica.Command
{
    public interface IVikingRepository<T> where T : class
    {
        List<T> getAll();
        T getID(decimal ID);
        void Insert(T prEntity);
        void Delete(T prEntity);
        void Update(T prEntity);
    }
}
