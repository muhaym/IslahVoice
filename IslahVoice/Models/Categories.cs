using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslahVoice.Models
{
    public class CategoryList
    {
        public string categoryID { get; set; }
        public string categoryName { get; set; }
    }

    public class Category
    {
        public int ParentID { get; set; }
        public string ParentName { get; set; }
        public List<CategoryList> CategoryList { get; set; }
    }

    public class CategorySource
    {
        public List<Category> Categories { get; set; }
    }

}
