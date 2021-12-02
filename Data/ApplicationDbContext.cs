using BancaBasica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BancaBasica.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Cliente> cliente { get; set; }

        public DbSet<Cuenta> cuenta { get; set; }

        public DbSet<Movimiento> movimiento { get; set; }
    }
}
