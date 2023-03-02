using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController<Key, Entity, Repository> : ControllerBase 
    where Entity : class
    where Repository: IRepository<Key, Entity>
{
    private readonly Repository repository;

    public BaseController(Repository repository)
    {
        this.repository = repository;
    }

    // Index
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var results = await repository.GetAll();
        if (results is null)
        {
            //return results.Count() is 0
            //? NotFound(new {StatusCode = 200, Massage = "Data Empty!", Data = results})
            //:Ok(new
            // {StatusCode = 200, Massage = "All Data Found!", Data = results});
            return Ok(new
            {
                StatusCode = 200,
                Massage = "Data Empty!",
                Data = results
            });
        }
        else
        {
            return Ok(new
            {
                StatusCode = 200,
                Massage = "All Data Found!",
                Data = results
            }); ;
        }
    }

    // Create
    [HttpPost]
    public async Task<ActionResult> Insert(Entity entity)
    {
        try
        {
            var results = await repository.Insert(entity);
            if (results == 0)
            {
                return BadRequest(new
                {
                    StatusCode = 409,
                    Massage = "Add Data Filed!"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 201,
                    Massage = "Add Data Success!"
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

    //GetById
    [HttpGet]
    [Route("{key}")]
    public async Task<ActionResult> GetById(Key key)
    {
        var results = await repository.GetById(key);
        if (results is null)
        {
            return Ok(new
            {
                StatusCode = 200,
                Massage = "Data Not Found!"
            });
        }
        else
        {
            return Ok(new
            {
                StatusCode = 200,
                Massage = "Data Found!",
                Data = results
            });
        }
    }

    //Update
    [HttpPut]
    public async Task<ActionResult> Update(Entity entity)
    {
        var results = await repository.Update(entity);
        if (results is 0)
        {
            return Ok(new
            {
                StatusCode = 200,
                Massage = "Update Data Filed!"
            });
        }
        else
        {
            return Ok(new
            {
                StatusCode = 200,
                Massage = "Update Data Success!",
                Data = results
            });
        }
    }

    //Delete
    [HttpDelete]
    public async Task<ActionResult> Delete(Key key)
    {
        try
        {
            var results = await repository.Delete(key);
            if (results == 0)
            {
                return BadRequest(new
                {
                    StatusCode = 404,
                    Massage = "Data Not Found!"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 201,
                    Massage = "Delete Data Success!"
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
}
