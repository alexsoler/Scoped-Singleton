using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scoped_Singleton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scoped_Singleton.Services
{
    public class RepositorioGenerico<T> : IGenericRepository<T> where T : class
    {
        private readonly IServiceProvider serviceProvider;
        public RepositorioGenerico(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
        }

        public async Task AddRegistroAsync(T entidad)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var db = provider.GetRequiredService<AplicationDbContext>();
                await db.Set<T>().AddAsync(entidad);
                await db.SaveChangesAsync();
            }
        }

        public async Task<T> FindRegistro(int id)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var db = provider.GetRequiredService<AplicationDbContext>();

                T entidad = await db.Set<T>().FindAsync(id);
                return entidad;
            }
        }

        public async Task<IEnumerable<T>> ListaCompleta()
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var db = provider.GetRequiredService<AplicationDbContext>();

                return await db.Set<T>().ToListAsync(); 
            }
        }
    }
}
