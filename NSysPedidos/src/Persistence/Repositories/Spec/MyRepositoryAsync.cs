using Application.Interface;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Contextos;

namespace Persistence.Repositories.Spec
{
    public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly AplicacionDbContext _dbContext;

        public MyRepositoryAsync(AplicacionDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        // metodo personalizado
        public async Task<List<T>> AddRangeAsync(List<T> entities, CancellationToken cancellationToken)
        {
            await this._dbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
            await this._dbContext.SaveChangesAsync();
            return entities;
        }
    }
}
