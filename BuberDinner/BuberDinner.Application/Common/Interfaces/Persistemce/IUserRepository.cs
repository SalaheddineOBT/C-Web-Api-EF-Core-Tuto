using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User GetUserByEmail(string email);
    User GetUserById(string Id);
    void Add(User user);
}
