using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class SubCategory
    {
        public int SubCategory_id { get; set; }
        public int Category_id { get; set; }
        public int? ParentCategoryId { get; set; }// Nullable, since root categories won't have a parent
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string LevelIndicator { get; set; } // Used for displaying nested leve
        public SubCategory() { }
        public SubCategory(int subCategory_id, int category_id, int? parentCategoryId, string name, string image, DateTime? createdDate, DateTime? updatedDate, string updatedBy, string levelIndicator)
        {
            SubCategory_id = subCategory_id;
            Category_id = category_id;
            ParentCategoryId = parentCategoryId;
            Name = name;
            Image = image;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
            LevelIndicator = levelIndicator;
        }
    }
}