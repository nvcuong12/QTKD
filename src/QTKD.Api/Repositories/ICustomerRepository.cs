using QtkdApi.Entities;

namespace QtkdApi.Repositories;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();
}