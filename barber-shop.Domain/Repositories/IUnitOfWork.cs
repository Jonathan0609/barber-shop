namespace barber_shop.Domain.Repositories;

public interface IUnitOfWork
{
    Task SaveAsync();
}