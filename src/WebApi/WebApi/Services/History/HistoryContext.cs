using Microsoft.EntityFrameworkCore;

namespace WebApi.Services.History
{
    public class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options)
            : base(options)
        { }

        public DbSet<Search> Searches { get; set; }
    }
}