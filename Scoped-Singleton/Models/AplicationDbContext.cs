using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scoped_Singleton.Models
{
    public class AplicationDbContext : DbContext
    {
        public static int contador = 0;

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
            contador++;
        }

        public DbSet<Registro> Registros { get; set; }
    }
}
