using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoFastFood_API.Models;
using Microsoft.EntityFrameworkCore;

namespace TacoFastFood_API.Models
{
    public class UserDAL
    {
        static FastFoodTacoDbContext dbContext = new FastFoodTacoDbContext();

        public static bool ValidateKey(string ApiKey)
        {
            return dbContext.Users.Any(u => u.ApiKey == ApiKey);
        }
    }
}