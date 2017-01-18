using PlayStore.Project.DataAccess.DataModel;
using PlayStore.Project.DataAccess.DataModel.Carousel_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.Project.ViewModels.PlayStore.Project.ViewModel.UserPage
{
    public class HomeViewModel
    {
        //public List<Category> Categories { get; set; }
        public List<CarouselHomeViewModel> Carousels { get; set; }
    }

    public class CarouselHomeViewModel
    {
        public long ID { get; set; }
        public string ImagePath { get; set; }
        public int SortOrder { get; set; }
        public bool IsCaptionContainer { get; set; }
        public bool HasButton { get; set; }

        //ContentLayout as json string
        //render by JsonConvert class with model CaptionLayout if IsCaptionContainer is true or NormalLayout if IsCaptionContainer is false
        public string ContentLayout { get; set; }
    }
}