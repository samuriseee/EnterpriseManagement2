using Microsoft.AspNetCore.Identity;
using WebApplication8.Models;

namespace WebApplication8.Repositories
{
    public interface IAccountRepositories
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
