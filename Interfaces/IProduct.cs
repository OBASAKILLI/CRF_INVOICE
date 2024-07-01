using ECAN_INVOICE.Context;
using ECAN_INVOICE.Models;

namespace ECAN_INVOICE.Interfaces
{
    public interface IProduct:IGenericRepository<Product>
    {
    }
    public class ProductRepo : GenericRepo<Product>, IProduct
    {
        public ProductRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
