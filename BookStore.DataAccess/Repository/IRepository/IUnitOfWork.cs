namespace BookStore.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }

    Task SaveAsync(CancellationToken cancellationToken);
}