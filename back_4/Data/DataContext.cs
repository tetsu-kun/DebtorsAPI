using Microsoft.EntityFrameworkCore;

namespace back_4.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        } 

        public DbSet<Debtor> Debtors { get; set; }
    }
}
