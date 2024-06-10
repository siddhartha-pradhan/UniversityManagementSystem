namespace UniversityWebApplication.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(string includeProperties = null);

        T Get(int ID);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(int ID);

        void RemoveRange(IEnumerable<T> entities);
    }
}
