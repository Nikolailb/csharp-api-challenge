using dishwasher.api.Models;
using Microsoft.EntityFrameworkCore;

namespace dishwasher.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ProgramModel> Programs { get; set; }
    }
}
