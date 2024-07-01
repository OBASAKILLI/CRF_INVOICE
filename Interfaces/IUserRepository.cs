
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using ECAN_INVOICE.Context;
using ECAN_INVOICE.Models;

namespace ECAN_INVOICE.Interfaces
{
    public interface IUserRepository:IGenericRepository<Users>
    {
        Task<Users> GetByEmail(string email); 
        Task<Users> GetCurrentUser();
        Task<Users> Login(string Username, string Password);
        Task<Users> FindUserwithMail(string Email);
    }


    public class UserRepository : GenericRepo<Users>, IUserRepository
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public UserRepository(AppDbContext appDbContext, AuthenticationStateProvider authenticationStateProvider) : base(appDbContext)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<Users> FindUserwithMail(string Email)
        {
            return await _appDbContext.users.FirstOrDefaultAsync(x => x.username == Email);
        }

        public async Task<Users> GetByEmail(string email)
        {
            return await _appDbContext.users.FirstOrDefaultAsync(k => k.FullName == email);
        }

        public async Task<Users> GetCurrentUser()
        {
            var authstate = await _authenticationStateProvider.GetAuthenticationStateAsync();
            int userId = int.Parse(authstate.User.Identity.Name);
            return await _appDbContext.users.FindAsync(userId);
        }

        public async Task<Users> Login(string Username, string Password)
        {
            return await _appDbContext.users.FirstOrDefaultAsync(x => x.username == Username && x.pasword == Password);

        }
    }
}
