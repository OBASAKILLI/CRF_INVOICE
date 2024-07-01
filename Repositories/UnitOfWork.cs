
using Microsoft.AspNetCore.Components.Authorization;
using ECAN_INVOICE.Context;
using ECAN_INVOICE.Interfaces;

namespace ECAN_INVOICE.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public UnitOfWork(AppDbContext appDbContext, AuthenticationStateProvider authenticationStateProvider)
        {
            _appDbContext = appDbContext;
            _authenticationStateProvider = authenticationStateProvider;
            UserRepository = new UserRepository(_appDbContext, authenticationStateProvider);
            product = new ProductRepo(_appDbContext);
        }
     
        public IUserRepository UserRepository { get; private set; }

        public IProduct product { get; private set; }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
        public int save()
        {
            return _appDbContext.SaveChanges();
        }


    }
}
