using DynatronCustomer.service.Application.DTOs;
using DynatronCustomer.service.Application.Interface;
using DynatronCustomer.Service.Application.Common;
using DynatronCustomer.Service.Domain.Entities;

namespace DynatronCustomer.Service.Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return customers.Select(c =>
                new CustomerDto(c.Id, c.FirstName, c.LastName, c.Email, c.CreatedDate, c.LastUpdatedDate)).ToList();
        }

        public async Task<Result<CustomerDto>> GetByIdAsync(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id);
            return customer == null
                ? Result<CustomerDto>.Fail("Customer not found.")
                : Result<CustomerDto>.Ok(new CustomerDto(customer.Id, customer.FirstName, customer.LastName, customer.Email, customer.CreatedDate, customer.LastUpdatedDate));
        }

        public async Task<Result<CustomerDto>> AddAsync(string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email))
                return Result<CustomerDto>.Fail("All fields are required.");

            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            await _repository.AddAsync(customer);

            var dto = new CustomerDto(customer.Id, customer.FirstName, customer.LastName, customer.Email, customer.CreatedDate, customer.LastUpdatedDate);
            return Result<CustomerDto>.Ok(dto);
        }

        public async Task<Result<bool>> UpdateAsync(Guid id, string firstName, string lastName, string email)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null) return Result<bool>.Fail("Customer not found.");

            customer.Update(firstName, lastName, email);
            await _repository.UpdateAsync(customer);

            return Result<bool>.Ok(true);
        }

        public async Task<Result<bool>> DeleteAsync(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null) return Result<bool>.Fail("Customer not found.");

            await _repository.DeleteAsync(id);
            return Result<bool>.Ok(true);
        }
    }
}
