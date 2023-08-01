using Microsoft.AspNetCore.Mvc;
using therapyFlow.Modules.Common.Models;
using therapyFlow.Modules.Customer.Models;
using therapyFlow.Modules.Customer.Services;

namespace therapyFlow.Modules.Customer.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;
        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerModelDTO>>> GetAll()
        {
            ServiceResponseModel<List<CustomerModelDTO>> res = await _CustomerService.GetAll();
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModelDTO>> GetOne(Guid id)
        {
            ServiceResponseModel<CustomerModelDTO> res = await _CustomerService.GetOne(id);
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerModelDTO>> CreateCustomer(Request_CustomerModel newCustomer)
        {
            ServiceResponseModel<CustomerModelDTO> res = await _CustomerService.CreateCustomer(newCustomer);
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerModelDTO>> UpdateCustomer(Guid id, Request_CustomerModel updatedCustomer)
        {
            ServiceResponseModel<CustomerModelDTO> res = await _CustomerService.UpdateCustomer(id, updatedCustomer);
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> DeleteCustomer(Guid id)
        {
            ServiceResponseModel<String> res = await _CustomerService.DeleteCustomer(id);
            if (res.Success == false)
            {
                return NotFound(res);
            }

            return Ok(res);
        }
    }
}