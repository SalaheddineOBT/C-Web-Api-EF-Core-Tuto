using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}
