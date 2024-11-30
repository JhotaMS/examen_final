namespace examen_final.Domain.Ports;
public interface IUnitOfWork : IDisposable {
    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class;
    public ValueTask<int> SaveChangesAsync();
}