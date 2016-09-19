namespace STDShop.Data.Migrations
{
    using STDShop.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<STDShop.Data.STDShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(STDShop.Data.STDShopDbContext context)
        {
            CreateProductCategorySample(context);
            CreateSlide(context);
        }

        private void CreateUser(STDShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new STDShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new STDShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "haulv",
            //    Email = "luonghau91@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Luong Hau"
            //};

            //manager.Create(user, "123456$");
            ////if role not exists
            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("luonghau91@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(STDShop.Data.STDShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
                 new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
                  new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true },
                   new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }
        private void CreateFooter(STDShopDbContext context)
        {
            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "";
            }
        }
        private void CreateSlide(STDShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,
                        Url ="#",
                        Image ="~/Assets/client/images/bag.jpg",
                        Content =@"	<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur 
                            adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                        <span class=""on-get"">GET NOW</span>" },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder =2,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bag1.jpg",
                    Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>

                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >

                                <span class=""on-get"">GET NOW</span>"},
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }
    }
}