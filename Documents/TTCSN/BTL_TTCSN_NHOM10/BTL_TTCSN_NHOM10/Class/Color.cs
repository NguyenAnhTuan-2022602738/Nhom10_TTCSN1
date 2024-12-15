using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class Color
    {
        public int Color_id { get; set; }
        public string Color_name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Color() { }
        public Color(int colorId, string colorName, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Color_id = colorId;
            Color_name = colorName;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}