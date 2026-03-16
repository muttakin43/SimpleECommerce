using SimpleECommerce.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerce.BLL.Interface
{
    public interface IProductService
    {
        Task<IReadOnlyList<ProductDTO>> GetAllAsync();
        Task<ProductDTO?> GetByIdAsync(Guid id);
        Task CreateAsync(ProductDTO dto);
        Task UpdateAsync(ProductDTO dto);
        Task DeleteAsync(Guid id);
    }
}
