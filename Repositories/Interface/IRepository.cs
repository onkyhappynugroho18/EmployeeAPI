using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Repositories.Interface;

public interface IRepository<Key, Entity> where Entity : class
{
    //GetAll
    Task<IEnumerable<Entity>> GetAll();
    //GetById
    Task<Entity> GetById(Key key);
    //Create
    Task<int> Insert(Entity entity);
    //Update
    Task<int> Update(Entity entity);
    //Delete
    Task<int> Delete(Key key);
}
