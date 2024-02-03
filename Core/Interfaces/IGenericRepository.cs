namespace Core.Interfaces;

public interface IGenericRepository<T> where T : SkinetBaseModel
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
}