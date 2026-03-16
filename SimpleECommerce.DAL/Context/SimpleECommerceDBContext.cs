using Microsoft.EntityFrameworkCore;
using SimpleECommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerce.DAL.Context
{
    public class SimpleECommerceDBContext : DbContext
    {
        public SimpleECommerceDBContext(DbContextOptions<SimpleECommerceDBContext>options): base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
