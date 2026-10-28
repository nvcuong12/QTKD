using QtkdApi.Entities;

namespace QtkdApi.Repositories;

public interface IContractRepository
{
    Task<Contract?> GetByIdAsync(int id);
}