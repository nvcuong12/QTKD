using QtkdApi.DTOs;
using QtkdApi.Repositories;

namespace QtkdApi.Services;

public class ContractService : IContractService
{
    private readonly IContractRepository contractRepository;

    public ContractService(IContractRepository contractRepository)
    {
        this.contractRepository = contractRepository;
    }

    public async Task<ContractResponse?> GetByIdAsync(int id)
    {
        var contract = await contractRepository.GetByIdAsync(id);
        return contract?.ToResponse();
    }
}