using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Domain.User;

namespace UnitOfWork.Infrastructure.EfCore
{
    public class ShopDbContext : DbContext
    {
        protected ShopDbContext()
        {
        }

        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
   
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<UnitOfWork.Domain.User.User> Users { get; set; }
    }
}
