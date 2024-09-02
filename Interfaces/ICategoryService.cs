namespace LibraryManagementSystemBackend.Interfaces

{
    public interface ICategoryService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByNameAsync(string title);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(Guid id, T entity);
        Task DeleteAsync(Guid id);
    }
}