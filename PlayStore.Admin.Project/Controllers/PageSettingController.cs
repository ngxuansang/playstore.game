using PlayStore.Project.DataAccess.DatabaseAccess;
using PlayStore.Project.DataAccess.DataModel.Carousel_Models;
using PlayStore.Project.ViewModels.PlayStore.Project.ViewModel.AdminPage.PageSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayStore.Admin.Project.Controllers
{
    public class PageSettingController : Controller
    {
        private DiaGameEntities db = new DiaGameEntities();

        // GET: PageSetting
        public ActionResult Index()
        {
            CarouselSettingViewModel model = new CarouselSettingViewModel();
            return View(model);
        }

        public ActionResult GetCarouselData(long carousel_id)
        {
            return View();
        }
    }
}