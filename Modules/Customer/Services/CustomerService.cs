using Microsoft.EntityFrameworkCore;
using therapyFlow.Data;
using therapyFlow.Modules.Common.Models;
using therapyFlow.Modules.Customer.Mappers;
using therapyFlow.Modules.Customer.Models;

namespace therapyFlow.Modules.Customer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponseModel<CustomerModelDTO>> CreateCustomer(Request_CustomerModel newCustomer)
        {
            ServiceResponseModel<CustomerModelDTO> serviceResponse = new();

            CustomerModel Customer = newCustomer.ToCustomerModel();

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            serviceResponse.Data = Customer.ToCustomerModelDTO();

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<string>> DeleteCustomer(Guid id)
        {
            ServiceResponseModel<String> serviceResponse = new();

            try
            {
                var CustomerFromDB = await _context.Customers.FindAsync(id);
                if (CustomerFromDB is null) 
                {
                    throw new Exception($"Id {id} not found.");
                }

                _context.Customers.Remove(CustomerFromDB);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            serviceResponse.Data = "Customer deleted successfully";

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<List<CustomerModelDTO>>> GetAll()
        {
            ServiceResponseModel<List<CustomerModelDTO>> serviceResponse = new();

            try
            {
                var Customers = await _context.Customers.Include("Notes").ToListAsync();
                if (Customers is null)
                {
                    throw new Exception("Something went wrong.");
                }

                List<CustomerModelDTO> CustomersDTO = new();
                foreach (CustomerModel Customer in Customers)
                {
                    CustomersDTO.Add(Customer.ToCustomerModelDTO());
                }

                serviceResponse.Data = CustomersDTO;
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponseModel<CustomerModelDTO>> GetOne(Guid id)
        {
            ServiceResponseModel<CustomerModelDTO> serviceResponse = new();

            try
            {
                var CustomerFromDB = await _context.Customers.Include("Notes").FirstOrDefaultAsync(Customer => Customer.Id == id);
                if (CustomerFromDB is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                serviceResponse.Data = CustomerFromDB.ToCustomerModelDTO();
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponseModel<CustomerModelDTO>> UpdateCustomer(Guid id, Request_CustomerModel updatedCustomer)
        {
            ServiceResponseModel<CustomerModelDTO> serviceResponse = new();    
                
            try
            {
                var CustomerFromDB = await _context.Customers.Include("Notes").FirstOrDefaultAsync(Customer => Customer.Id == id);
                if (CustomerFromDB is null)
                {
                    throw new Exception($"Id {id} not found.");
                }

                CustomerFromDB.FirstName = updatedCustomer.FirstName;
                CustomerFromDB.LastName = updatedCustomer.LastName;
                await _context.SaveChangesAsync();

                serviceResponse.Data = CustomerFromDB.ToCustomerModelDTO();
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}