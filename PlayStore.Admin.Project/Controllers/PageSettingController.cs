using Newtonsoft.Json;
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

        [AllowAnonymous]
        //GET: /PageSetting/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        //POST: /PageSetting/Create
        public ActionResult Create(string basicCarousel, string option, string layout)
        {
            try
            {
                Carousel carousel = JsonConvert.DeserializeObject<Carousel>(basicCarousel);
                switch (option)
                {
                    case "caption_control":
                        CaptionLayout captionLayout = JsonConvert.DeserializeObject<CaptionLayout>(layout);
                        break;
                    case "normal_control":
                        break;
                }
                return Json(new { IsError = 0, Messages = "Create carousel unsuccessful !" });
                //add database
            }
            catch (Exception ex)
            {
                return Json(new { IsError = 1, Messages = ex.Message });
            }
        }

        //GET: /PageSetting/InnerCaptionControl
        public ActionResult InnerCaptionControl()
        {
            return PartialView();
        }

        //GET: /PageSetting/NormalControl
        public ActionResult NormalControl()
        {
            return PartialView();
        }

        //GET: /PageSetting/RenderControl
        public ActionResult RenderControl(string className, int range, int button)
        {
            CarouselType typeObj = new CarouselType
            {
                ClassName = className,
                Range = range,
                HasButton = button == 1 ? true : false
            };

            return PartialView(typeObj);
        }

        //GET: /PageSetting/RenderControl
        public ActionResult ListAnimte()
        {
            return PartialView();
        }
    }
}