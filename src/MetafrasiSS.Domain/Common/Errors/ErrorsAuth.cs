using ErrorOr;

namespace MetafrasiSS.Domain.Common.Errors;

public partial class Errors
{
    public static class Auth
    {
        public static Error LockedOut => Error.Validation(
            code: "User.LockedOut",
            description: "User is LockedOut");

        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "The credentials are invalid");

        public static Error Unauthorized => Error.Unauthorized(
            code: "Auth.Unauthorized",
            description: "Unauthorized action");

        public static Error NotFound => Error.NotFound(
            code: "Auth.NotFound",
            description: "AuthUser couldn't be found");

        public static Error InvalidPassword => Error.Validation(
            code: "Auth.InvalidPassword",
            description: "The Password must have a number (0-9), a Uppercase and an alphanumeric character");
    }
}