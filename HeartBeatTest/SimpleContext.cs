using Microsoft.EntityFrameworkCore;

namespace HeartBeatTest
{
    public class SimpleContext : DbContext
    {
        public SimpleContext(DbContextOptions<SimpleContext> options) : base(options)
        {

        }

        public virtual DbSet<SimpleItem> SimpleItems { get; set; }
    }
}
