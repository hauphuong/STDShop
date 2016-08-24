namespace STDShop.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}