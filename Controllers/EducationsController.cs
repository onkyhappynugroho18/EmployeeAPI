using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationsController : BaseController<int, Education, EducationRepository>
{
    public EducationsController(EducationRepository repository) : base(repository)
    {
    }
}
