using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountRolesController : BaseController<int, AccountRole, AccountRoleRepository>
{
    public AccountRolesController(AccountRoleRepository repository) : base(repository)
    {
    }
}
