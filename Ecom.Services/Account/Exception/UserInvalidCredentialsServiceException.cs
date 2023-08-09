using Ecom.Services.Account.Error;
using Ecom.Services.Exceptions.Exception;

namespace Ecom.Services.Account.Exception
{
    public class UserInvalidCredentialsServiceException : ServiceException
    {
        public UserInvalidCredentialsServiceException()
            : base(new UserInvalidCredentialsError())
        {
        }
    }
}
