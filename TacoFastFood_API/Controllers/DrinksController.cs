using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoFastFood_API.Models;
using Microsoft.EntityFrameworkCore;

namespace TacoFastFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        FastFoodTacoDbContext dbContext = new FastFoodTacoDbContext();

        [HttpGet()]
        public IActionResult GetAll(string ApiKey, string? SortByCost = null)
        {
            if(UserDAL.ValidateKey(ApiKey))
            {
                if (SortByCost == "ascending")
                {
                    return Ok(dbContext.Drinks.OrderBy(d => d.Cost).ToList());
                }
                else if (SortByCost == "descending")
                {
                    return Ok(dbContext.Drinks.OrderByDescending(d => d.Cost).ToList());
                }
                else
                {
                    return Ok(dbContext.Drinks.ToList());
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
                Drink result = dbContext.Drinks.Find(id);
                if (result == null)
                {
                    return NotFound("Drink not found");
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
        public IActionResult AddDrink(string ApiKey, [FromBody] Drink newDrink)
        {
            if(UserDAL.ValidateKey(ApiKey))
            {
                newDrink.Id = 0;

                dbContext.Drinks.Add(newDrink);
                dbContext.SaveChanges();
                return Created($"/api/Drinks/{newDrink.Id}", newDrink);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDrink(string ApiKey, [FromBody] Drink targetDrink, int id)
        {
            if (UserDAL.ValidateKey(ApiKey))
            {
                if (id != targetDrink.Id)
                {
                    return BadRequest();
                }
                else if (!dbContext.Drinks.Any(d => d.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    dbContext.Drinks.Update(targetDrink);
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
        public IActionResult DeleteDrink(string ApiKey, int id)
        {
            if(UserDAL.ValidateKey(ApiKey))
            {
                Drink result = dbContext.Drinks.Find(id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    dbContext.Drinks.Remove(result);
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