namespace Magic.DTO.Interfaces;

public interface IRepository<out TEnt> where TEnt : class
{
    public IQueryable<TEnt> Entities { get; }
    public Task RunTransaction(Action func);
}