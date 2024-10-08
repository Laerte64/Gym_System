using Data;

namespace Repository
{
    internal interface IRepository<T>
    {
        public void Create(T t);
        public List<T> Read();
        public void Update(T t);
        public void Delete(T t);
    }
}