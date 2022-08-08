namespace BuberDinner.Application.Common.Services;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
    DateTime UtcNow { get; }
}
