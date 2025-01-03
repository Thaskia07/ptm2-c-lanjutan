using Microsoft.EntityFrameworkCore;
using pertemuan_2.Models.DB;

namespace pertemuan_2.Models
{
    public class ApplicationContext : DbContext
    {
        //gerbang untuk ke database
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Items> Items { get; set; }
    }
}
