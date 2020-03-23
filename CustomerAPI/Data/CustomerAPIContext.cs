using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using DBContext = Microsoft.EntityFrameworkCore.DbContext;

namespace CustomerAPI.Data
{
    public class CustomerAPIContext : DBContext
    {
        public CustomerAPIContext(DbContextOptions<CustomerAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
