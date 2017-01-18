using PlayStore.Project.DataAccess.DatabaseAccess;
using Project.ICore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.Project.DataAccess.DataModel.Carousel_Models
{
    public class Carousel : IDatabaseAct<Carousel>
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

        public long Insert()
        {
            DiaGameEntities db = new DiaGameEntities();
            long carouselID = db.Database.SqlQuery<long>("admin_insert_carousel_basic @image_path, @begin_date, @end_date, @is_enabled, @sort_order",
                            new SqlParameter("@image_path", this.ImagePath),
                            new SqlParameter("@begin_date", this.BeginDate),
                            new SqlParameter("@end_date", this.EndDate),
                            new SqlParameter("@is_enabled", this.IsEnabled),
                            new SqlParameter("@sort_order", this.SortOrder)).First();
            return carouselID;
        }

        public void Update(Carousel newObj)
        {
            DiaGameEntities db = new DiaGameEntities();
            var result = db.Database.ExecuteSqlCommand("update_carousel_object @CarouselID, @ImagePath, @BeginDate, @EndDate, @IsEnabled, @SortOrder",
                new SqlParameter("@CarouselID", newObj.ID),
                new SqlParameter("@ImagePath", newObj.ImagePath),
                new SqlParameter("@BeginDate", newObj.BeginDate),
                new SqlParameter("@EndDate", newObj.EndDate),
                new SqlParameter("@IsEnabled", newObj.IsEnabled),
                new SqlParameter("@SortOrder", newObj.SortOrder));
        }

        public void Delete(Carousel obj)
        {
            throw new NotImplementedException();
        }
    }
}