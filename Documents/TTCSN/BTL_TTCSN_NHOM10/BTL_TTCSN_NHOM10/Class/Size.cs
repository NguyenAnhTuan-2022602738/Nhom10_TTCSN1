using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class Size
    {
        public int Size_id { get; set; }
        public string Size_name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Size() { }
        public Size(int sizeId, string sizeName, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Size_id = sizeId;
            Size_name = sizeName;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}