using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ECAN_INVOICE.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ECAN_INVOICE.Models.Users> users { get; set; }
        public DbSet<ECAN_INVOICE.Models.Product> Product { get; set; }
 
    }
   
}
