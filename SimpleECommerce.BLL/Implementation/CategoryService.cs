using SimpleECommerce.BLL.Interface;
using SimpleECommerce.Contract;
using SimpleECommerce.DAL.Interfaces;
using SimpleECommerce.Model;

namespace SimpleECommerce.BLL.Services
{
    public class CategoryService : ICategoryServise
    {
        private readonly IUnitOfWork _unitOfWork;

     
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    
        public async Task<IReadOnlyList<CategoryDTO>> GetAllAsync()
        {
            var entities = await _unitOfWork.Categories.GetAllAsync();

            return entities.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).ToList();
        }

        
        public async Task<CategoryDTO?> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Categories.GetByIdAsync(id);
            if (entity == null) return null;

            return new CategoryDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }

       
        public async Task CreateAsync(CategoryDTO dto)
        {
            var entity = new Category
            {
                Id = dto.Id == Guid.Empty ? Guid.NewGuid() : dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };

            await _unitOfWork.Categories.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

      
        public async Task UpdateAsync(CategoryDTO dto)
        {
            var entity = await _unitOfWork.Categories.GetByIdAsync(dto.Id);
            if (entity == null) return;

            entity.Name = dto.Name;
            entity.Description = dto.Description;

            _unitOfWork.Categories.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _unitOfWork.Categories.GetByIdAsync(id);
            if (entity == null) return;

            _unitOfWork.Categories.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}