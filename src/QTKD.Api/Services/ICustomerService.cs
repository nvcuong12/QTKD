using QtkdApi.DTOs;

namespace QtkdApi.Services;

public interface ICustomerService
{
    Task<List<CustomerResponse>> GetAllAsync();
}