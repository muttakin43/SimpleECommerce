using Microsoft.EntityFrameworkCore;
using SimpleECommerce.DAL.Context;
using SimpleECommerce.DAL.Interfaces;
using System.Linq.Expressions;

namespace SimpleCommerce.DAL.Repositories;

public class GenericRepository<T>(SimpleECommerceDBContext dbContext) : IGenericRepository<T> where T : class
{
    protected readonly SimpleECommerceDBContext DbContext = dbContext;
    protected readonly DbSet<T> DbSet = dbContext.Set<T>();

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<IReadOnlyList<T>> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

   
}