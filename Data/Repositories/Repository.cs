using Data.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class Repository<TEntity>(ApplicationDbContext context) : IRepository<TEntity>
    where TEntity : class
{
    public virtual void Add(TEntity? entity)
    {
        if (entity != null) context.Add(entity);
        context.SaveChanges();
    }

    public virtual void Update(TEntity? entity)
    {
        if (entity != null) context.Update(entity);
        context.SaveChanges();
    }

    public virtual void Delete(TEntity? entity)
    {
        if (entity != null) context.Remove(entity);
        context.SaveChanges();
    }
}