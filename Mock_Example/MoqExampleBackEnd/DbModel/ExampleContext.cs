using Microsoft.EntityFrameworkCore;

namespace MoqExampleBackEnd.DbModel
{
    public class ExampleContext : DbContext
    {
        public ExampleContext() { }
        public ExampleContext(DbContextOptions<ExampleContext> options) : base(options)
        { }

        public virtual DbSet<CatalogItem> CatalogItems { get; set; }
    }
}
