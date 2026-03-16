using SimpleECommerce.BLL.Interface;
using SimpleECommerce.Contract;
using SimpleECommerce.DAL.Interfaces;
using SimpleECommerce.Model;

namespace SimpleCommerce.BLL.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    
    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<ProductDTO>> GetAllAsync()
    {
        var entities = await _unitOfWork.Products.GetAllAsync();
        return entities.Select(p => new ProductDTO
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            ImageUrl = p.ImageUrl,
            CategoryId = p.CategoryId
        }).ToList();
    }

    public async Task<ProductDTO?> GetByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Products.GetByIdAsync(id);
        if (entity == null) return null;

        return new ProductDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            ImageUrl = entity.ImageUrl,
            CategoryId = entity.CategoryId
        };
    }

    public async Task CreateAsync(ProductDTO dto)
    {
        var entity = new Product
        {
            Id = dto.Id == Guid.Empty ? Guid.NewGuid() : dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            ImageUrl = dto.ImageUrl,
            CategoryId = dto.CategoryId
        };

        await _unitOfWork.Products.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductDTO dto)
    {
        var entity = await _unitOfWork.Products.GetByIdAsync(dto.Id);
        if (entity == null) return;

        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.Price = dto.Price;
        entity.ImageUrl = dto.ImageUrl;
        entity.CategoryId = dto.CategoryId;

        _unitOfWork.Products.Update(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _unitOfWork.Products.GetByIdAsync(id);
        if (entity == null) return;

        _unitOfWork.Products.Delete(entity);
        await _unitOfWork.SaveChangesAsync();
    }
}