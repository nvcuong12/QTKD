using QtkdApi.Entities;

namespace QtkdApi.DTOs;

public static class QtkdMapping
{
    public static CustomerResponse ToResponse(this Customer customer) =>
        new()
        {
            Id = customer.Id,
            Name = customer.Name,
            Status = customer.Status.ToString()
        };

    public static ContractResponse ToResponse(this Contract contract) =>
        new()
        {
            Id = contract.Id,
            ContractNo = contract.ContractNo,
            CustomerId = contract.CustomerId,
            CustomerName = contract.Customer.Name,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            Status = contract.Status.ToString()
        };
}