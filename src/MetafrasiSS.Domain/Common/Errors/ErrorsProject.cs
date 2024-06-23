using ErrorOr;

namespace MetafrasiSS.Domain.Common.Errors;

public partial class Errors
{
    public static class Project
    {
        public static Error NotFound => Error.NotFound(
            code: "Project.NotFound",
            description: "Project couldn't be found");

        public static Error TooManyFiles => Error.Validation(
            code: "Project.TooManyFiles",
            description: "Project can't have more than 3 files");
    }
}