namespace DynatronCustomer.service.Application.DTOs
{
    public record CustomerDto(Guid Id, string FirstName, string LastName, string Email, DateTime CreatedDate, DateTime LastUpdatedDate);
}
