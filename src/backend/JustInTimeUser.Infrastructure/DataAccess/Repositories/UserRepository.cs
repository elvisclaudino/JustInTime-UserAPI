using JustInTimeUser.Domain.Entitities;
using JustInTimeUser.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace JustInTimeUser.Infrastructure.DataAccess.Repositories;
internal class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly JustInTimeUserDbContext _dbContext;

    public UserRepository(JustInTimeUserDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(User user) => await _dbContext.AddAsync(user);

    public async Task<bool> ExistActiveUserWithEmail(string email) => await _dbContext
        .Users.AnyAsync(user => user.Email.Equals(email) && user.Active);
}
