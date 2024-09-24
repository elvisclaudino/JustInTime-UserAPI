namespace JustInTimeUser.Domain.Repositories.User;
public interface IUserWriteOnlyRepository
{
    public Task Add(Entitities.User user);
}
