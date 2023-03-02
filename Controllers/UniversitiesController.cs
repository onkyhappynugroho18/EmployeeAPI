using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversitiesController : BaseController<int, University, UniversityRepository>
{
    public UniversitiesController(UniversityRepository repository) : base(repository)
    {
    }
}
