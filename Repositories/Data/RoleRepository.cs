using API.Context;
using API.Models;

namespace API.Repositories.Data;

public class RoleRepository : GeneralRepository<int, Role>
{
    private readonly MyContext context;

    public RoleRepository(MyContext context) : base(context)
    {
        this.context = context;
    }
}
