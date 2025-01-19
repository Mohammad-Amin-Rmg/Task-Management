namespace Data.Repositories.Contract
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Delete(TEntity? entity);
        void Update(TEntity? entity);
    }
}