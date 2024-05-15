namespace Magic.Service.Exceptions;

public class OwnerNotFoundException : Exception
{
    public OwnerNotFoundException(int ownerId) : base($"Tests owner with ID {ownerId} is not found")
    {
    }
}