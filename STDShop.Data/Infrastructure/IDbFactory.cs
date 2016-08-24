using System;
namespace STDShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        STDShopDbContext Init();
    }
}