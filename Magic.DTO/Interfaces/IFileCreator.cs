namespace Magic.DTO.Interfaces;

public interface IFileCreator
{
    Task<byte[]> GetFileBytes<T>(List<T> table, string dataType);
}