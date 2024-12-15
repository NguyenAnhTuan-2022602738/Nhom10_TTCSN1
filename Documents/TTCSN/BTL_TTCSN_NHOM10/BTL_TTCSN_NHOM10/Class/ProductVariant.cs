using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class ProductVariant
    {
        public int Variant_id { get; set; }
        public int Product_id { get; set; }
        public int Color_id { get; set; }
        public int Size_id { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public ProductVariant() { }
        public ProductVariant(int variantId, int productId, int colorId, int sizeId, int quantity, decimal? price, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Variant_id = variantId;
            Product_id = productId;
            Color_id = colorId;
            Size_id = sizeId;
            Quantity = quantity;
            Price = price;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}