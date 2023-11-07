using ErrorOr;

namespace MetafrasiSS.Domain.Common.Errors;

public partial class Errors
{
	public static class User
	{
		public static Error DuplicateEmail => Error.Conflict(
			code: "User.DuplicateEmail",
			description: "Email already in use");

		public static Error DuplicateUserName => Error.Conflict(
			code: "User.DuplicateUserName",
			description: "UserName already in use");

		public static Error NotFound => Error.NotFound(
			code: "User.NotFound",
			description: "User couldn't be found");
	}
}