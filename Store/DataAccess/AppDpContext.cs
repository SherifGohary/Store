using Microsoft.EntityFrameworkCore;
using Store.Entities;
using System;

namespace Store.DataAccess
{
    public class AppDpContext : DbContext
    {
        public AppDpContext(DbContextOptions<AppDpContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
