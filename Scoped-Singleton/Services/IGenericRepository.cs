using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scoped_Singleton.Services
{
    public interface IGenericRepository<T> where T: class
    {
        Task AddRegistroAsync(T entidad);
        Task<T> FindRegistro(int id);
    }
}
