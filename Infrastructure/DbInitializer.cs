using DynatronCustomer.Service.Domain.Entities;
using DynatronCustomer.Service.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DynatronCustomer.Service.Infrastructure;

public static class DbInitializer
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Customers.AnyAsync()) return;

        var now = DateTime.UtcNow;
        var customers = Enumerable.Range(1, 20).Select(i => new Customer
        {
            FirstName = $"First{i}",
            LastName = $"Last{i}",
            Email = $"user{i}@example.com",
            CreatedDate = now,
            LastUpdatedDate = now
        });

        await context.Customers.AddRangeAsync(customers);
        await context.SaveChangesAsync();
    }
}
