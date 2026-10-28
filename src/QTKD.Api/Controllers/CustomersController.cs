using Microsoft.AspNetCore.Mvc;
using QtkdApi.DTOs;
using QtkdApi.Services;

namespace QtkdApi.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService customerService;

    public CustomersController(ICustomerService customerService)
    {
        this.customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerResponse>>> GetAll()
    {
        List<CustomerResponse> customers = await customerService.GetAllAsync();
        return Ok(customers);
    }
}