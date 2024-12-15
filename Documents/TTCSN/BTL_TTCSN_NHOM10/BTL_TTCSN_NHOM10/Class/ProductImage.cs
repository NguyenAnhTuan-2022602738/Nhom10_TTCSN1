using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class ProductImage
    {
        public int Image_id { get; set; }
        public string Image { get; set; }
        public int Product_id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public ProductImage() { }
        public ProductImage(int imageId, string image, int productId, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Image_id = imageId;
            Image = image;
            Product_id = productId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}