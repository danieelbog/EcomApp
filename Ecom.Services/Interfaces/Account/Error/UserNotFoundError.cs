using Ecom.Services.Exceptions.Error;

namespace Ecom.Services.Interfaces.Account.Error
{
    public class UserNotFoundError : NotFoundServiceError
    {
        public UserNotFoundError()
            : base(Modules.Account, ErrorCodes.UserNotFound, "user")
        {
        }

        public UserNotFoundError(string property, string value)
            : base(Modules.Account, ErrorCodes.UserNotFound, "user", property, value)
        {
        }
    }
}
