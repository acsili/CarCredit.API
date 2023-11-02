namespace CarCredit.API.Interfaces
{
    public interface IRepository<T>
    {
        bool Create(T entity); 

        T Get(int id);

        Task<IEnumerable<T>> GetAll();

        bool Delete(T entity);
    }
}
