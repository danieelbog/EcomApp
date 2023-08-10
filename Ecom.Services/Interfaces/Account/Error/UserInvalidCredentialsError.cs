using Ecom.Services.Exceptions.Error;

namespace Ecom.Services.Interfaces.Account.Error
{
    public class UserInvalidCredentialsError : ServiceError
    {
        public UserInvalidCredentialsError()
            : base(StatusCodes.BadRequest, Modules.Account, ErrorCodes.UserInvalidCredentialsError, "User invalid credentials.")
        {
        }
    }
}
