using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_TTCSN_NHOM10.Class
{
    public class Cart
    {
        public int Cart_id { get; set; }
        public int Quantity { get; set; }
        public int User_id { get; set; }
        public int Product_id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public Cart() { }
        public Cart(int cartId, int quantity, int userId, int productId, DateTime createdDate, DateTime? updatedDate, string updatedBy)
        {
            Cart_id = cartId;
            Quantity = quantity;
            User_id = userId;
            Product_id = productId;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UpdatedBy = updatedBy;
        }
    }
}