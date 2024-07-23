using Microsoft.EntityFrameworkCore;
using minimal_api_distributed_redis_cache.Models;

namespace minimal_api_distributed_redis_cache.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
}
