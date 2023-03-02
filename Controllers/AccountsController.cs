using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly AccountRepository accountRepository;
    private readonly IConfiguration configuration;

    public AccountsController(AccountRepository accountRepository, IConfiguration configuration)
    {
        this.accountRepository = accountRepository;
        this.configuration = configuration;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult> Register(RegisterVM registerVM)
    {
        try
        {
            var results = await accountRepository.Register(registerVM);
            if (results == 0)
            {
                return BadRequest(new
                {
                    StatusCode = 409,
                    Massage = "Register Filed!"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 201,
                    Massage = "Register Success!"
                });
            }
        }
        catch (Exception ex)
        {

            return BadRequest(new
            {
                StatusCode = 400,
                Massage = "Oops!! Something Wrong!"
            });
        }
    }

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult> Login(LoginVM loginVM)
    {
        try
        {
            var results = await accountRepository.Login(loginVM);
            if (results is false)
            {
                return BadRequest(new
                {
                    StatusCode = 409,
                    Massage = "Login Filed!"
                });
            }

            var userdata = accountRepository.GetUserdata(loginVM.Email);
            var roles = accountRepository.GetRolesByNIK(loginVM.Email);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, userdata.Email),
                new Claim(ClaimTypes.Name, userdata.FullName)
            };

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }
            if (userdata is null)
            {
                return BadRequest(new
                {
                    StatusCode = 409,
                    Massage = "Login Filed!"
                });
            }
            else
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signIn
                    );

                var generateToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    StatusCode = 200,
                    Massage = "Login Success!",
                    Data = generateToken
                });
            }
        }
        catch
        {
            return BadRequest(new
            {
                StatusCode = 400,
                Massage = "Oops!! Something Wrong!"
            });
        }
    }
}
