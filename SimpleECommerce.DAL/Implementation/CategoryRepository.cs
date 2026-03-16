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
    public class CategoryRepository
      : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SimpleECommerceDBContext context)
            : base(context)
        {
        }
    }
}
