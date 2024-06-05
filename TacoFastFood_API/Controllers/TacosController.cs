using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoFastFood_API.Models;
using Microsoft.EntityFrameworkCore;

namespace TacoFastFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacosController : ControllerBase
    {
        FastFoodTacoDbContext dbContext = new FastFoodTacoDbContext();

        [HttpGet()]
        public IActionResult GetAll(string ApiKey, bool? softShell = null)
        {
            if(UserDAL.ValidateKey(ApiKey))
            {
                if (softShell != null)
                {
                    return Ok(dbContext.Tacos.Where(t => t.SoftShell == softShell));
                }
                else
                {
                    return Ok(dbContext.Tacos.ToList());
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string ApiKey, int id)
        {
            if(UserDAL.ValidateKey(ApiKey))
            {
                Taco result = dbContext.Tacos.Find(id);
                if (result == null)
                {
                    return NotFound("Taco not found");
                }
                else
                {
                    return Ok(result);
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost()]
        public IActionResult AddTaco(string ApiKey, [FromBody] Taco newTaco)
        {
            if(UserDAL.ValidateKey(ApiKey))
            {
                newTaco.Id = 0;

                dbContext.Tacos.Add(newTaco);
                dbContext.SaveChanges();
                return Created($"/api/Tacos/{newTaco.Id}", newTaco);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTaco(string ApiKey, [FromBody] Taco targetTaco, int id)
        {
            if(UserDAL.ValidateKey(ApiKey))
            {
                if (id != targetTaco.Id)
                {
                    return BadRequest();
                }
                else if (!dbContext.Tacos.Any(t => t.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    dbContext.Tacos.Update(targetTaco);
                    dbContext.SaveChanges();
                    return NoContent();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTaco(string ApiKey, int id)
        {
            if(UserDAL.ValidateKey(ApiKey))
            {
                Taco result = dbContext.Tacos.Find(id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    dbContext.Tacos.Remove(result);
                    dbContext.SaveChanges();
                    return NoContent();
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
