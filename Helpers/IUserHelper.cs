
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SuperShop.Web.Data;
using SuperShop.Web.Data.Entities;
using SuperShop.Web.Data.Entities;

namespace SuperShop.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
    }
}
