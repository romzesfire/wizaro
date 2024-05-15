namespace Magic.DTO.Interfaces;

public interface ILocker
{
    public void ConcurrentExecute(Action func);
    public Task ConcurrentExecuteAsync(Action func);
}