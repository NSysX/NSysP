using Ardalis.Specification;

namespace Application.Interface
{
    public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
    {
        Task<List<T>> AddRangeAsync(List<T> entities, CancellationToken cancellationToken);
    }

    public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
    {

    }
}
