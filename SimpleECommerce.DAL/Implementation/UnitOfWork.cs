using Microsoft.EntityFrameworkCore;
using SimpleECommerce.DAL.Context;
using SimpleECommerce.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerce.DAL.Implementation
{
    public class UnitOfWork(SimpleECommerceDBContext dbContext) : IUnitOfWork
    {
        private readonly SimpleECommerceDBContext _dbcontext=dbContext;

        public IProductRepository? _productRepository;
        public ICategoryRepository? _categoryRepository;

        public IProductRepository Products => _productRepository ??= new ProductRepository(_dbcontext);
        

        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_dbcontext);

        public ValueTask DisposeAsync()
        {
            return _dbcontext.DisposeAsync();

        }

        public Task<int> SaveChangesAsync()
        {
            return _dbcontext.SaveChangesAsync();
        }
    }
}
