using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoFastFood_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace TacoFastFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    {
        FastFoodTacoDbContext dbContext = new FastFoodTacoDbContext();

        [HttpGet()]
        public IActionResult GetAll(string ApiKey)
        {
            if(UserDAL.ValidateKey(ApiKey))
            {
                return Ok(dbContext.Combos.Include(c => c.Drink).Include(c => c.Taco).ToList());
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}