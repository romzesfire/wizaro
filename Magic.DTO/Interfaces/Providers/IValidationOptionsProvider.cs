using Magic.DTO.Model;

namespace Magic.DTO.Interfaces.Providers;

public interface IValidationOptionsProvider
{
    Dictionary<Type, ValidationOptions> GetOptions();
}