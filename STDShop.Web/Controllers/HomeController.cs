using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STDShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly] //ko được gọi trực tiếp home/footer mà chỉ để nhúng thôi
        public ActionResult Header()
        {
            //nếu tên view khác tên method thì phải chỉ rõ ví dụ PartialView("Footer1")
            return PartialView();
        }
        [ChildActionOnly] //ko được gọi trực tiếp home/footer mà chỉ để nhúng thôi
        public ActionResult Category()
        {
            //nếu tên view khác tên method thì phải chỉ rõ ví dụ PartialView("Footer1")
            return PartialView();
        }

        [ChildActionOnly] //ko được gọi trực tiếp home/footer mà chỉ để nhúng thôi
        public ActionResult Footer()
        {
            //nếu tên view khác tên method thì phải chỉ rõ ví dụ PartialView("Footer1")
            return PartialView();
        }
    }
}