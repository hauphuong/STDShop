namespace STDShop.Data.Infrastucture
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}