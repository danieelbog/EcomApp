using Ecom.Services.Exceptions.Exception;
using Ecom.Services.Interfaces.Account.Error;

namespace Ecom.Services.Interfaces.Account.Exception
{
    public class UserInvalidCredentialsServiceException : ServiceException
    {
        public UserInvalidCredentialsServiceException()
            : base(new UserInvalidCredentialsError())
        {
        }
    }
}
