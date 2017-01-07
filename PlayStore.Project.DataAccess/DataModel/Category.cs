using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.Project.DataAccess.DataModel
{
    public class Category
    {
        public long ID { get; set; }
        public long? ParentID { get; set; }
        public string Title { get; set; }
        public int Depth { get; set; }
        public string Location { get; set; }

    }
}