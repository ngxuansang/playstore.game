using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.Project.DataAccess.DataModel.Carousel_Models
{
    public class Carousel
    {
        public long ID { get; set; }

        [Required]
        [Display(Name = "Image path")]
        public string ImagePath { get; set; }

        [Required]
        [Display(Name = "Begin date")]
        public DateTime BeginDate { get; set; }

        [Required]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool IsEnabled { get; set; }

        [Required]
        [Display(Name = "Sort order")]
        public int SortOrder { get; set; }
    }
}