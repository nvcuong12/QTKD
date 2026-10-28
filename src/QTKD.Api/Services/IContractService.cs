using QtkdApi.DTOs;

namespace QtkdApi.Services;

public interface IContractService
{
    Task<ContractResponse?> GetByIdAsync(int id);
}