using DynatronCustomer.Service.Application.Services;
using DynatronCustomer.service.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DynatronCustomer.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomersController(CustomerService service)
        {
            _service = service;
        }

        /// <summary>Get all customers</summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CustomerDto>>> GetAll()
        {
            var customers = await _service.GetAllAsync();
            return Ok(customers);
        }

        /// <summary>Get a customer by ID</summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return result.Success ? Ok(result.Value) : NotFound(result.Error);
        }

        /// <summary>Create a new customer</summary>
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CustomerCreateRequest request)
        {
            var result = await _service.AddAsync(request.FirstName, request.LastName, request.Email);
            return result.Success
                ? CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value)
                : BadRequest(result.Error);
        }

        /// <summary>Update an existing customer</summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] CustomerUpdateRequest request)
        {
            var result = await _service.UpdateAsync(id, request.FirstName, request.LastName, request.Email);
            return result.Success ? NoContent() : NotFound(result.Error);
        }

        /// <summary>Delete a customer</summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return result.Success ? NoContent() : NotFound(result.Error);
        }
    }
}
