using ECommerce.Domain.Entities.User;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<List<User>> GetAllAsync();
    Task<List<User>> GetAllActiveAsync();

    Task<User> AddAsync(User user);
    Task<User> UpdateAsync(User user);

    Task<User> DeactivateAsync(Guid userId); 
    Task<User> ActivateAsync(Guid userId);
    Task<User> GetByEmailAsync(string email);
}
