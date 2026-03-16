using Microsoft.EntityFrameworkCore;
using SimpleCommerce.DAL.Repositories;
using SimpleECommerce.DAL.Context;
using SimpleECommerce.DAL.Interfaces;
using SimpleECommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerce.DAL.Implementation
{
    public class ProductRepository
     : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SimpleECommerceDBContext context)
            : base(context)
        {

        }

        public async Task<int> CountProductsAsync()
        {
            return await DbSet.CountAsync();
        }
    }
}
