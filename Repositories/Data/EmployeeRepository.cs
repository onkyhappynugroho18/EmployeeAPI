using API.Context;
using API.Models;

namespace API.Repositories.Data;

public class EmployeeRepository : GeneralRepository<string, Employee>
{
    private readonly MyContext context;

    public EmployeeRepository(MyContext context) : base(context)
    {
        this.context = context;
    }
}
