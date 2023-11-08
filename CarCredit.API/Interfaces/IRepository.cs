namespace CarCredit.API.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task<bool> Create(T entity);

        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll();

        Task<bool> Delete(T entity);
    }
}
