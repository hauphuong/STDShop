namespace STDShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private STDShopDbContext dbContext;

        public STDShopDbContext Init()
        {
            return dbContext ?? (dbContext = new STDShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}