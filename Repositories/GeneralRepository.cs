using API.Context;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class GeneralRepository<Key, Entity> : IRepository<Key, Entity>
    where Entity : class
{
    public readonly MyContext context;

    public GeneralRepository(MyContext context)
    {
        this.context = context;
    }

    public async Task<int> Delete(Key key)
    {
        var entity = await GetById(key);
        if (entity == null)
        {
            return 0;
        }
        context.Set<Entity>().Remove(entity);
        return await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Entity>> GetAll()
    {
        return await context.Set<Entity>().ToListAsync();
    }

    public async Task<Entity> GetById(Key? key)
    {
        if (key is null)
        {
            return null;
        }
        return await context.Set<Entity>().FindAsync(key);
    }

    public async Task<int> Insert(Entity entity)
    {
        await context.Set<Entity>().AddAsync(entity);
        return await context.SaveChangesAsync();
    }

    public async Task<int> Update(Entity entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        return await context.SaveChangesAsync();
    }
}
