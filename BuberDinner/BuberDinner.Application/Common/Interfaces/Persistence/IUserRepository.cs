using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    User? GetUserById(string id);
    void Add(User user);
}
