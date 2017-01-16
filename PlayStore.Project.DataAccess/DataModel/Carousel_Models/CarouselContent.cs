using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.Project.DataAccess.DataModel.Carousel_Models
{
    public class CarouselContent
    {
        public long ID { get; set; }

        public long CarouselOwnerID { get; set; }
    }

    public class CarouselType
    {
        public string ClassName { get; set; }
        public int Range { get; set; }
        public bool HasButton { get; set; }
    }

    public class CaptionLayout : CarouselContent
    {
        public Component CaptionFrame { get; set; }
        public ButtonComponent Button { get; set; }
        public List<TitleComponent> Titles { get; set; }
    }

    public class NormalLayout : CarouselContent
    {
    }

    public class TitleComponent : Component
    {
        public string Title { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
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