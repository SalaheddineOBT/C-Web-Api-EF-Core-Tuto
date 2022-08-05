namespace BuberDinner.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
    DateTime UtcNow { get; }
}
