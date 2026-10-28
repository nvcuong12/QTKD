using QtkdApi.DTOs;
using QtkdApi.Repositories;

namespace QtkdApi.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public async Task<List<CustomerResponse>> GetAllAsync()
    {
        var customers = await customerRepository.GetAllAsync();
        return customers.Select(c => c.ToResponse()).ToList();
    }
}