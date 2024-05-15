using System.Net;
using Magic.DTO.Interfaces.Providers;
using Magic.DTO.Model;
using Magic.Service.Exceptions;

namespace Magic.Service.Validation;

public class ValidationOptionsProvider : IValidationOptionsProvider
{
    private readonly Dictionary<Type, ValidationOptions> _options;

    public ValidationOptionsProvider()
    {
        _options = new Dictionary<Type, ValidationOptions>(new TypeComparer())
        {
            {
                typeof(ConcurrentWriteException),
                new ValidationOptions
                {
                    StatusCode = (int)HttpStatusCode.Conflict
                }
            },
            {
                typeof(InvalidSecurityKeyException),
                new ValidationOptions
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                }
            },
            {
                typeof(OwnerNotFoundException),
                new ValidationOptions
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                }
            }
        };
    }

    public Dictionary<Type, ValidationOptions> GetOptions()
    {
        return _options;
    }
}