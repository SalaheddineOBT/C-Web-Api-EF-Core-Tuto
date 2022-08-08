using ErrorOr;

namespace BuberDinner.Domain.Common;

public static class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email already exists !"
        );
    }
}