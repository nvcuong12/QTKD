using Microsoft.EntityFrameworkCore;
using QtkdApi.Data;
using QtkdApi.Entities;

namespace QtkdApi.Repositories;

public class ContractRepository : IContractRepository
{
    private readonly QtkdDbContext dbContext;

    public ContractRepository(QtkdDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<Contract?> GetByIdAsync(int id) =>
        dbContext.Contracts
            .AsNoTracking()
            .Include(c => c.Customer)
            .FirstOrDefaultAsync(c => c.Id == id);
}