using API.Context;
using API.Models;

namespace API.Repositories.Data;

public class ProfilingRepository : GeneralRepository<int, Profiling>
{
    private readonly MyContext context;

    public ProfilingRepository(MyContext context) : base(context)
    {
        this.context = context;
    }
}
