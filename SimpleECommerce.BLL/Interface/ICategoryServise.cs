using SimpleECommerce.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleECommerce.BLL.Interface
{
    public interface ICategoryServise
    {
        Task<IReadOnlyList<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO?> GetByIdAsync(Guid id);
        Task CreateAsync(CategoryDTO dto);
        Task UpdateAsync(CategoryDTO dto);
        Task DeleteAsync(Guid id);
    }
}
