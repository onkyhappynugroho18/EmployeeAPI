using API.Context;
using API.Models;

namespace API.Repositories.Data;

public class UniversityRepository : GeneralRepository<int, University>
{
    private readonly MyContext context;

    public UniversityRepository(MyContext context) : base(context)
    {
        this.context = context;
    }

}
