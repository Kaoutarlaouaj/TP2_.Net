using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Authentification.JWT.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Constructeur sans paramètres pour le mode design
        public ApplicationDbContext() { }

        public DbSet<Entities.User> Users { get; set; }
    }

}
