using ECAN_INVOICE.Context;
using Microsoft.EntityFrameworkCore;

namespace ECAN_INVOICE.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddNew(T entity);  
        Task<List<T>> GetAll();   
        Task<T> GetById(int Id);  
        Task Remove(T entity); 
        Task Update(T entity);    
    }


    public class GenericRepo<T> : IGenericRepository<T> where T : class
    {
        public readonly AppDbContext _appDbContext;


        public GenericRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddNew(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);

        }

        public async Task<List<T>> GetAll()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await _appDbContext.Set<T>().FindAsync(Id);
        }

        public async Task Remove(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public async Task Update(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
        }
    }
}
