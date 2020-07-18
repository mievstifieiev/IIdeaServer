using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IIdeaServer.Model
{
    public class ConectionContext : DbContext
    {
        public ConectionContext(DbContextOptions<ConectionContext> options): base(options)
        {
        }

        public DbSet<Conection> Conections { get; set; }
    }
}
