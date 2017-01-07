using PlayStore.Project.DataAccess;
using PlayStore.Project.DataAccess.DataModel;
using PlayStore.Project.Models;
using PlayStore.Project.ViewModels.PlayStore.Project.ViewModel.UserPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayStore.Project.Controllers
{
    public class HomeController : Controller
    {
        private DiaGameEntities Db = new DiaGameEntities();

        [RequireHttps]
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            //model.Categories = Db.Database.SqlQuery<Category>("dbo.get_categories_child @parentID = 0").ToList();
            return View(model);
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
    }
}