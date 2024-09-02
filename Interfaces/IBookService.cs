namespace LibraryManagementSystemBackend.Interfaces

{
    public interface IBookService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByTitleAsync(string title);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(Guid id, T entity);
        Task DeleteAsync(Guid id);
    }
}