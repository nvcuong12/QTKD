using Microsoft.EntityFrameworkCore;
using QtkdApi.Data;
using QtkdApi.Entities;

namespace QtkdApi.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly QtkdDbContext dbContext;

    public CustomerRepository(QtkdDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<List<Customer>> GetAllAsync() =>
        dbContext.Customers.AsNoTracking().ToListAsync();
}