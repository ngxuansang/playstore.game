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
        public List<Category> Categories { get; set; }
        public List<Carousel> Carousels { get; set; }
    }
}