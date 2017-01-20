using PlayStore.Project.DataAccess.DatabaseAccess;
using Project.ICore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.Project.DataAccess.DataModel.Carousel_Models
{
    public class CarouselContent
    {
        public long ID { get; set; }
        public long CarouselOwnerID { get; set; }
        public bool IsCaptionContainer { get; set; }
        public bool HasButton { get; set; }
        public string JsonLayout { get; set; }
    }

    public class CarouselType
    {
        public string ClassName { get; set; }
        public int Range { get; set; }
        public bool HasButton { get; set; }
    }

    public class CaptionLayout : CarouselContent, IDatabaseAct<CaptionLayout>
    {
        public Component CaptionFrame { get; set; }
        public ButtonComponent Button { get; set; }
        public List<TitleComponent> Titles { get; set; }

        public long Insert()
        {
            DiaGameEntities db = new DiaGameEntities();
            long contentID = db.Database.SqlQuery<long>("admin_insert_carousel_Content @SlideOwnerID, @IsCaptionContainer, @HasButton, @ContentLayout",
                new SqlParameter("@SlideOwnerID", this.CarouselOwnerID),
                new SqlParameter("@IsCaptionContainer", true),
                new SqlParameter("@HasButton", true),
                new SqlParameter("@ContentLayout", this.JsonLayout)).First();
            return contentID;
        }

        public void Update(CaptionLayout newObj)
        {
        }

        public void Delete(CaptionLayout obj)
        {
            throw new NotImplementedException();
        }
    }

    public class NormalLayout : CarouselContent, IDatabaseAct<CaptionLayout>
    {
        public ButtonComponent Button { get; set; }
        public List<TitleComponent> Titles { get; set; }

        public void Delete(CaptionLayout obj)
        {
            throw new NotImplementedException();
        }

        public long Insert()
        {
            DiaGameEntities db = new DiaGameEntities();

            var hasButton = this.Button == null ? false : true;

            long contentID = db.Database.SqlQuery<long>("admin_insert_carousel_Content @SlideOwnerID, @IsCaptionContainer, @HasButton, @ContentLayout",
                new SqlParameter("@SlideOwnerID", this.CarouselOwnerID),
                new SqlParameter("@IsCaptionContainer", false),
                new SqlParameter("@HasButton", hasButton),
                new SqlParameter("@ContentLayout", this.JsonLayout)).First();
            return contentID;
        }

        public void Update(CaptionLayout newObj)
        {
        }
    }

    public class TitleComponent : Component
    {
        public string Title { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public string Style { get; set; }
    }

    public class ButtonComponent : Component
    {
        public string Title { get; set; }
        public string Link { get; set; }
    }

    public class Component
    {
        public string Animate { get; set; }
        public string Delay { get; set; }
    }
}