using Ecom.Services.Exceptions.Error;

namespace Ecom.Services.Account.Error
{
    public class UserInvalidCredentialsError : ServiceError
    {
        public UserInvalidCredentialsError()
            : base(StatusCodes.BadRequest, Modules.Account, ErrorCodes.UserInvalidCredentialsError, "User invalid credentials.")
        {
        }
    }
}
