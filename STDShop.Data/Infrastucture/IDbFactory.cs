using System;
namespace STDShop.Data.Infrastucture
{
    public interface IDbFactory : IDisposable
    {
        STDShopDbContext Init();
    }
}