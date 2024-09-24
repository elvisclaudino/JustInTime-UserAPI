using JustInTimeUser.Domain.Repositories;

namespace JustInTimeUser.Infrastructure.DataAccess;
public class UnitOfWork : IUnitOfWork
{
    private readonly JustInTimeUserDbContext _dbContext;
    public UnitOfWork(JustInTimeUserDbContext dbContext) => _dbContext = dbContext;

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
