using Ecom.Services.Account.Error;
using Ecom.Services.Exceptions.Exception;

namespace Ecom.Services.Account.Exception
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
