using Report_System_Backend.model;

namespace Report_System_Backend.Repository;

public interface IRepository<T> where T : class 
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T report);
    Task DeleteAsync(int id);
    Task SaveAsync();
    
}