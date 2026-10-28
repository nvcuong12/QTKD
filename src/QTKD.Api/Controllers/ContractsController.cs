using Microsoft.AspNetCore.Mvc;
using QtkdApi.DTOs;
using QtkdApi.Services;

namespace QtkdApi.Controllers;

[ApiController]
[Route("api/contracts")]
public class ContractsController : ControllerBase
{
    private readonly IContractService contractService;

    public ContractsController(IContractService contractService)
    {
        this.contractService = contractService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ContractResponse>> GetById(int id)
    {
        ContractResponse? contract = await contractService.GetByIdAsync(id);
        if (contract == null)
        {
            return NotFound();
        }

        return Ok(contract);
    }
}