using therapyFlow.Modules.Common.Models;
using therapyFlow.Modules.Customer.Models;

namespace therapyFlow.Modules.Customer.Services
{
    public interface ICustomerService
    {
        Task<ServiceResponseModel<List<CustomerModelDTO>>> GetAll();
        Task<ServiceResponseModel<CustomerModelDTO>> GetOne(Guid id);
        Task<ServiceResponseModel<CustomerModelDTO>> CreateCustomer(Request_CustomerModel newCustomer);
        Task<ServiceResponseModel<CustomerModelDTO>> UpdateCustomer(Guid id, Request_CustomerModel updatedCustomer);
        Task<ServiceResponseModel<string>> DeleteCustomer(Guid id);
    }
}