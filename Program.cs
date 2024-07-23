using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using minimal_api_distributed_redis_cache.Data;
using minimal_api_distributed_redis_cache.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("minimal-api-distributed-redis-cache"));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "minimal-api-distributed-redis-cache";
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    dbContext.Customers.AddRange(
        new Customer { Name = "Peter Parker", Email = "peter.parker@marvel.com" },
        new Customer { Name = "Mary Jane", Email = "mary.jane@marvel.com" },
        new Customer { Name = "Ben Parker", Email = "ben.parker@marvel.com" }
    );

    dbContext.SaveChanges();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/customers", async (IDistributedCache cache, AppDbContext dbContext) =>
{
    var cacheKey = "customersCache";
    var cachedCustomers = await cache.GetStringAsync(cacheKey);
    List<Customer>? customers;

    if (string.IsNullOrEmpty(cachedCustomers))
    {
        customers = await dbContext.Customers.AsNoTracking().ToListAsync();
    
        var serializedCustomers = JsonSerializer.Serialize(customers);
        var cacheEntryOptions = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
        
        await cache.SetStringAsync(cacheKey, serializedCustomers, cacheEntryOptions);
    }
    else
    {
        customers = JsonSerializer.Deserialize<List<Customer>>(cachedCustomers);
    }

    return Results.Ok(customers);
});

app.MapPost("customers/", async (Customer model, AppDbContext dbContext) =>
{
    await dbContext.Customers.AddAsync(model);
    await dbContext.SaveChangesAsync();

    return Results.Created($"/customers/{model.Id}", model);    
});

app.Run();
