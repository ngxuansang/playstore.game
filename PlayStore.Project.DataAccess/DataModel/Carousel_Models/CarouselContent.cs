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
        public string ContentStyle { get; set; }
        public string ContentDataAnimate { get; set; }

        //HTML string
        public string ContentInnerText { get; set; }
        public long CarouselID { get; set; }
        public string ContentDataDelayTime { get; set ; }
    }
}