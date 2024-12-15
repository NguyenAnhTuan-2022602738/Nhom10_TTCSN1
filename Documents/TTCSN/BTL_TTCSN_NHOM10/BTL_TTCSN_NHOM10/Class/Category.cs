using BTL_TTCSN_NHOM10.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class Category
    {
        public int Category_id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Category() { }
        public Category(int categoryId, string name, string image, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Category_id = categoryId;
            Name = name;
            Image = image;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}