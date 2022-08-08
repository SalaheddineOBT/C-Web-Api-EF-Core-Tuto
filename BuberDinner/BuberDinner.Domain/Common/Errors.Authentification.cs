using ErrorOr;

namespace BuberDinner.Domain.Common;

public static partial class Errorss
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code:"User.DuplicateEmail",
            description: "Email is not exists !"
        );
    }
}