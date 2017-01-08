using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.Project.DataAccess.DataModel.Carousel_Models
{
    public class Carousel
    {
        public long ID { get; set; }
        public int HasCaption { get; set; }
        public string ImagePath { get; set; }
        public string CaptionAnimation { get; set; }
        public string ButtonLabel { get; set; }
        public string ButtonStyle { get; set; }
        public string ButtonAnimate { get; set; }
        public string ButtonDelayTime { get; set; }
        public string ButtonLink { get; set; }
        public string ImageAlt { get; set; }

        public List<CarouselContent> Contents { get; set; }
        public Carousel()
        {
            this.Contents = new List<CarouselContent>();
        }
    }
}