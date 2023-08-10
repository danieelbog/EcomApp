using Ecom.Services.Exceptions.Exception;
using Ecom.Services.Interfaces.Account.Error;

namespace Ecom.Services.Interfaces.Account.Exception
{
    public class UserNotFoundServiceException : NotFoundServiceException
    {
        public UserNotFoundServiceException()
            : base(new UserNotFoundError())
        {
        }

        public UserNotFoundServiceException(string property, string value)
            : base(new UserNotFoundError(property, value))
        {
        }
    }
}
