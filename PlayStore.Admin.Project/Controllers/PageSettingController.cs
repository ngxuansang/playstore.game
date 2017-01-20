using Newtonsoft.Json;
using PlayStore.Project.DataAccess.DatabaseAccess;
using PlayStore.Project.DataAccess.DataModel.Carousel_Models;
using PlayStore.Project.ViewModels.PlayStore.Project.ViewModel.AdminPage.PageSetting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace PlayStore.Admin.Project.Controllers
{
    public class PageSettingController : Controller
    {
        private DiaGameEntities db = new DiaGameEntities();

        // GET: PageSetting
        public ActionResult Carousel()
        {
            CarouselSettingViewModel model = new CarouselSettingViewModel();
            model.Carousels = db.Database.SqlQuery<Carousel>("get_carousel_basic").ToList();
            return View(model);
        }

        [HttpPost]
        //POST: /PageSetting/UpdateCarousel
        public ActionResult UpdateCarousel(string json)
        {
            try
            {
                var carousel = JsonConvert.DeserializeObject<Carousel>(json);
                //update database
                carousel.Update(carousel);
                return Json(new { IsError = 0, Messages = "Update successful !" });
            }
            catch (Exception ex)
            {
                return Json(new { IsError = 1, Messages = ex.Message });
            }
        }

        [HttpPost]
        //POST: /PageSetting/UpdateCarouselContent
        public ActionResult UpdateCarouselContent(long carouselID, string jsonLayout)
        {
            try
            {
                var execute = db.Database.ExecuteSqlCommand("admin_update_carousel_content @carouselOwnerID, @jsonLayout",
                    new SqlParameter("@carouselOwnerID", carouselID),
                    new SqlParameter("@jsonLayout", jsonLayout));
                return Json(new { IsError = 0, Messages = "Update successful !" });
            }
            catch (Exception ex)
            {
                return Json(new { IsError = 1, Messages = ex.Message });
            }
        }

        [AllowAnonymous]
        //GET: /PageSetting/Create
        public ActionResult Create()
        {
            return PartialView(new CaptionLayout());
        }

        [HttpPost]
        //POST: /PageSetting/Create
        public ActionResult Create(string basicCarousel, string option, string layout)
        {
            try
            {
                Carousel carousel = JsonConvert.DeserializeObject<Carousel>(basicCarousel);


                //insert basic
                long carouselID = carousel.Insert();
               
                switch (option)
                {
                    case "caption_control":
                        CaptionLayout captionLayout = JsonConvert.DeserializeObject<CaptionLayout>(layout);
                        captionLayout.CarouselOwnerID = carouselID;
                        captionLayout.JsonLayout = layout;
                        //add database
                        var contentCaptionID = captionLayout.Insert();
                        break;

                    case "normal_control":
                        NormalLayout normalLayout = JsonConvert.DeserializeObject<NormalLayout>(layout);
                        normalLayout.CarouselOwnerID = carouselID;
                        normalLayout.JsonLayout = layout;
                        //add database
                        var contentNormalID = normalLayout.Insert();
                        break;
                }
                return Json(new { IsError = 0, Messages = "Create carousel successful !" });
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

        //POST: /PageSetting/GetCarouselContentByID
        public ActionResult GetCarouselContentByID(long carouselID)
        {
            var content = db.Database.SqlQuery<CarouselContent>("admin_get_carousel_content @carouselID",
                new SqlParameter("@carouselID", carouselID)).First();
            return PartialView(content);
        }
    }
}